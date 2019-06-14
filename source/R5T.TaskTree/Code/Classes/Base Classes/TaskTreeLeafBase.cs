using System;
using System.Collections.Generic;

using R5T.NetStandard;


namespace R5T.TaskTree
{
    public abstract class TaskTreeLeafBase<TContext> : ITaskTreeLeafNode<TContext>
    {
        public string Name { get; }
        public string Description { get; }
        public IConsumer<TContext> Task { get; }

        public IEnumerable<ITaskTreeNode<TContext>> Children => TaskTreeNode<TContext>.LeafChildren;


        public TaskTreeLeafBase(string name, string description, IConsumer<TContext> task)
        {
            this.Name = name;
            this.Description = description;
            this.Task = task;
        }

        public TaskTreeLeafBase(IConsumer<TContext> task)
            : this(TaskTreeNode.DefaultName, TaskTreeNode.DefaultDescription, task)
        {
        }
    }
}
