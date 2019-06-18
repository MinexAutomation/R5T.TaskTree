using System;
using System.Collections.Generic;

using R5T.NetStandard;
using R5T.NetStandard.Extensions;


namespace R5T.TaskTree
{
    public static class ITaskContextExtensions
    {
        #region Tasks

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

        #endregion

        #region Contexts

        //public static TTaskContextParent AddContext<TTaskContextParent, TContext>(this TTaskContextParent taskContextParent, ITaskContext<TContext> taskContextChild)
        //    where TTaskContextParent : ITaskContext<TContext>
        //{
        //    taskContextParent.Branch.AddChild(taskContextChild.Branch);

        //    return taskContextParent;
        //}

        public static TTaskContextParent AddContext<TTaskContextParent, TTaskContextChild, TContext>(this TTaskContextParent taskContextParent, TTaskContextChild taskContextChild)
            where TTaskContextParent : ITaskContext<TContext>
            where TTaskContextChild : ITaskContext<TContext>
        {
            taskContextParent.Branch.AddChild(taskContextChild.Branch);

            return taskContextParent;
        }

        public static TTaskContextChild NewContext<TTaskContextParent, TTaskContextChild, TContext>(this TTaskContextParent taskContextParent, TTaskContextChild taskContextChild)
            where TTaskContextParent : ITaskContext<TContext>
            where TTaskContextChild : ITaskContext<TContext>
        {
            taskContextParent.Branch.AddChild(taskContextChild.Branch);

            return taskContextChild;
        }

        public static TTaskContextParent AddContext<TTaskContextParent, TTaskContextChild, TContext>(this TTaskContextParent taskContextParent, TTaskContextChild taskContextChild, out TTaskContextChild child)
            where TTaskContextParent : ITaskContext<TContext>
            where TTaskContextChild : ITaskContext<TContext>
        {
            taskContextParent.Branch.AddChild(taskContextChild.Branch);

            child = taskContextChild;

            return taskContextParent;
        }

        public static ITaskContext<TContext> AddContext<TTaskContextChild, TContext>(this ITaskContext<TContext> taskContextParent, TTaskContextChild taskContextChild)
            where TTaskContextChild : ITaskContext<TContext>
        {
            taskContextParent.Branch.AddChild(taskContextChild.Branch);

            return taskContextChild;
        }

        public static ITaskContext<TContext> AddContext<TTaskContextChild, TContext>(this ITaskContext<TContext> taskContextParent, TTaskContextChild taskContextChild, out TTaskContextChild child)
            where TTaskContextChild : ITaskContext<TContext>
        {
            taskContextParent.Branch.AddChild(taskContextChild.Branch);

            child = taskContextChild;

            return taskContextChild;
        }

        #endregion
    }
}
