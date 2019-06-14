using System;


namespace R5T.TaskTree
{
    public class TaskTreeRunner : ITaskTreeRunner
    {
        public void Run<TContext>(ITaskTreeNode<TContext> taskTreeNode, TContext context)
        {
            foreach (var currentTaskTreeNode in TaskTreeNode.EnumerateAll(taskTreeNode))
            {
                currentTaskTreeNode.Task.Consume(context);
            }
        }
    }
}
