using System;
using System.Collections.Generic;


namespace R5T.TaskTree
{
    public static class ITaskTreeBranchNodeExtensions
    {
        public static void AddChildren<TContext>(this ITaskTreeBranchNode<TContext> branchNode, IEnumerable<ITaskTreeNode<TContext>> children)
        {
            foreach (var child in children)
            {
                branchNode.AddChild(child);
            }
        }
    }
}
