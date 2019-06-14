using System;


namespace R5T.TaskTree
{
    /// <summary>
    /// Abstract base-class for task-contexts.
    /// </summary>
    public abstract class TaskContextBase<TParentTaskContext, TContext> : ITaskContext<TParentTaskContext, TContext>
        where TParentTaskContext : ITaskContext<TContext>
    {
        public ITaskTreeNode<TContext> Root { get; }
        public ITaskTreeBranchNode<TContext> Branch { get; } = new TaskTreeBranch<TContext>();

        public TParentTaskContext Parent { get; }
        ITaskContext<TContext> ITaskContext<TContext>.Parent => this.Parent;


        protected TaskContextBase(TParentTaskContext parent)
        {
            this.Root = parent.Root;
            this.Parent = parent;

            parent.Branch.AddChild(this.Branch);
        }
    }
}
