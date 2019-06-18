using System;
using System.Collections.Generic;

using R5T.NetStandard;
using R5T.NetStandard.Extensions;


namespace R5T.TaskTree
{
    public static class ITaskContextExtensions
    {
        public static TTaskContext AddTask<TTaskContext, TContext>(this TTaskContext taskContext, ITaskTreeNode<TContext> taskTreeNode)
            where TTaskContext : ITaskContext<TContext>
        {
            taskContext.Branch.AddChild(taskTreeNode);

            return taskContext;
        }

        public static TTaskContext AddTasks<TTaskContext, TContext>(this TTaskContext taskContext, IEnumerable<ITaskTreeNode<TContext>> taskTreeNodes)
            where TTaskContext : ITaskContext<TContext>
        {
            taskContext.Branch.AddChildren(taskTreeNodes);

            return taskContext;
        }

        public static TTaskContext AddTask<TTaskContext, TContext>(this TTaskContext taskContext, IConsumer<TContext> task, string name, string description)
            where TTaskContext : ITaskContext<TContext>
        {
            var taskTreeNode = new TaskTreeLeaf<TContext>(name, description, task);

            taskContext.AddTask(taskTreeNode);

            return taskContext;
        }

        public static TTaskContext AddTask<TTaskContext, TContext>(this TTaskContext taskContext, IConsumer<TContext> task, string name)
            where TTaskContext : ITaskContext<TContext>
        {
            taskContext.AddTask(task, name, TaskTreeNode.DefaultDescription);

            return taskContext;
        }

        public static TTaskContext AddTask<TTaskContext, TContext>(this TTaskContext taskContext, IConsumer<TContext> task)
            where TTaskContext : ITaskContext<TContext>
        {
            taskContext.AddTask(task, TaskTreeNode.DefaultName, TaskTreeNode.DefaultDescription);

            return taskContext;
        }

        public static TTaskContext AddTasks<TTaskContext, TContext>(this TTaskContext taskContext, IEnumerable<IConsumer<TContext>> tasks)
            where TTaskContext : ITaskContext<TContext>
        {
            var taskTreeNodes = tasks.ForEach(x => new TaskTreeLeaf<TContext>(x));

            taskContext.AddTasks(taskTreeNodes);

            return taskContext;
        }
    }
}
