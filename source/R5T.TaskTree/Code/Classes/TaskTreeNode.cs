using System;
using System.Collections.Generic;
using System.Linq;


namespace R5T.TaskTree
{
    public static class TaskTreeNode
    {
        public static string DefaultName { get; } = String.Empty;
        public static string DefaultDescription { get; } = String.Empty;


        public static bool IsLeaf<TContext>(ITaskTreeNode<TContext> taskTreeNode)
        {
            var isLeaf = Object.ReferenceEquals(taskTreeNode.Children, TaskTreeNode<TContext>.LeafChildren);
            return isLeaf;
        }

        public static IEnumerable<ITaskTreeNode<TContext>> EnumerateAll<TContext>(ITaskTreeNode<TContext> taskTreeNode)
        {
            yield return taskTreeNode;

            if (!taskTreeNode.IsLeaf())
            {
                foreach (var child in taskTreeNode.Children)
                {
                    var childTaskTreeNodes = TaskTreeNode.EnumerateAll(child);
                    foreach (var subChild in childTaskTreeNodes)
                    {
                        yield return subChild;
                    }
                }
            }
        }
    }


    public static class TaskTreeNode<TContext>
    {
        public static readonly IEnumerable<ITaskTreeNode<TContext>> LeafChildren = Enumerable.Empty<ITaskTreeNode<TContext>>();
    }
}
