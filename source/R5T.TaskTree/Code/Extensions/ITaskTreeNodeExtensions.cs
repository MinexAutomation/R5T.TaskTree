using System;


namespace R5T.TaskTree
{
    public static class ITaskTreeNodeExtensions
    {
        public static bool IsLeaf<TContext>(this ITaskTreeNode<TContext> taskTreeNode)
        {
            var isLeaf = TaskTreeNode.IsLeaf(taskTreeNode);
            return isLeaf;
        }
    }
}
