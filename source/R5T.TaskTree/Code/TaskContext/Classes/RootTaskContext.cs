using System;


namespace R5T.TaskTree
{
    public class RootTaskContext<TContext> : ITaskContext<TContext>
    {
        public ITaskTreeBranchNode<TContext> Branch { get; } = new TaskTreeBranch<TContext>();
        public ITaskTreeNode<TContext> Root => this.Branch;
        public ITaskContext<TContext> Parent => TaskContext<TContext>.RootTaskContextParent;
    }
}
