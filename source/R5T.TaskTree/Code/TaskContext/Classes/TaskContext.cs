using System;


namespace R5T.TaskTree
{
    public static class TaskContext
    {
        public static bool IsRoot<TContext>(ITaskContext<TContext> taskContext)
        {
            var isRoot = taskContext.Parent == TaskContext<TContext>.RootTaskContextParent;
            return isRoot;
        }
    }


    public static class TaskContext<TContext>
    {
        public static ITaskContext<TContext> RootTaskContextParent { get; } = null;
    }
}
