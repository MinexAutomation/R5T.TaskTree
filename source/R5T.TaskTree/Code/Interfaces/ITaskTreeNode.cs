using System;
using System.Collections.Generic;

using R5T.NetStandard;


namespace R5T.TaskTree
{
    public interface ITaskTreeNode<TContext>
    {
        string Name { get; }
        string Description { get; }
        IConsumer<TContext> Task { get; }

        IEnumerable<ITaskTreeNode<TContext>> Children { get; }
    }
}
