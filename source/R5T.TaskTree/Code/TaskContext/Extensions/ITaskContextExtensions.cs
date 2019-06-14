using System;
using System.Collections.Generic;


namespace R5T.TaskTree
{
    public static class ITaskContextExtensions
    {
        public static TTaskContext AddTask<TTaskContext, TContext>(this TTaskContext taskContext, ITaskTreeNode<TContext> task)
            where TTaskContext : ITaskContext<TContext>
        {
            taskContext.Branch.AddChild(task);

            return taskContext;
        }

        public static TTaskContext AddTasks<TTaskContext, TContext>(this TTaskContext taskContext, IEnumerable<ITaskTreeNode<TContext>> tasks)
            where TTaskContext : ITaskContext<TContext>
        {
            taskContext.Branch.AddChildren(tasks);

            return taskContext;
        }
    }
}
