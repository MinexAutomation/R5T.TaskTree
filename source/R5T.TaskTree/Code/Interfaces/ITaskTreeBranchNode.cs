using System;


namespace R5T.TaskTree
{
    public interface ITaskTreeBranchNode<TContext> : ITaskTreeNode<TContext>
    {
        void AddChild(ITaskTreeNode<TContext> child);
    }
}
