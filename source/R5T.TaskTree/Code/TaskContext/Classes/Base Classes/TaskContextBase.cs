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
        protected TaskTreeBranch<TContext> TaskTreeBranch = new TaskTreeBranch<TContext>();
        public ITaskTreeBranchNode<TContext> Branch => this.TaskTreeBranch;

        public TParentTaskContext Parent { get; }
        ITaskContext<TContext> ITaskContext<TContext>.Parent => this.Parent;

        public string Name
        {
            get
            {
                var name = this.TaskTreeBranch.Name;
                return name;
            }
            set
            {
                this.TaskTreeBranch.Name = value;
            }
        }
        public string Description
        {
            get
            {
                var description = this.TaskTreeBranch.Description;
                return description;
            }
            set
            {
                this.TaskTreeBranch.Description = value;
            }
        }


        protected TaskContextBase(TParentTaskContext parentContext)
        {
            this.Root = parentContext.Root;
            this.Parent = parentContext;
        }
    }
}
