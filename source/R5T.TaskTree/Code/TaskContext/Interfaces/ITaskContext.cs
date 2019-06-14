using System;


namespace R5T.TaskTree
{
    /// <summary>
    /// Allows strong-typing of the context in which tasks can be added to the task-tree.
    /// </summary>
    public interface ITaskContext<TContext>
    {
        /// <summary>
        /// Allows any level of task-context to access the root task-node for running.
        /// </summary>
        ITaskTreeNode<TContext> Root { get; }
        /// <summary>
        /// The aggregation task-node to which task-nodes should be added to be executed in the task-context.
        /// </summary>
        ITaskTreeBranchNode<TContext> Branch { get; }
        /// <summary>
        /// The parent context, of general-interface type.
        /// </summary>
        ITaskContext<TContext> Parent { get; }
    }


    /// <summary>
    /// Allows specific-typing of the task-context's parent task-context.
    /// </summary>
    public interface ITaskContext<TParentTaskContext, TContext> : ITaskContext<TContext>
        where TParentTaskContext : ITaskContext<TContext>
    {
        /// <summary>
        /// The parent context, of specific-interface type.
        /// </summary>
        new TParentTaskContext Parent { get; }
    }
}
