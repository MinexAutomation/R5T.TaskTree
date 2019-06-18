using System;


namespace R5T.TaskTree
{
    public class RootTaskContext<TContext> : ITaskContext<TContext>
    {
        protected TaskTreeBranch<TContext> TaskTreeBranch = new TaskTreeBranch<TContext>();
        public ITaskTreeBranchNode<TContext> Branch => this.TaskTreeBranch; 
        public ITaskTreeNode<TContext> Root => this.Branch;
        public ITaskContext<TContext> Parent => TaskContext<TContext>.RootTaskContextParent;
    }
}
