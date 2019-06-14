using System;


namespace R5T.TaskTree
{
    public interface ITaskTreeRunner
    {
        void Run<TContext>(ITaskTreeNode<TContext> taskTreeNode, TContext context);
    }
}
