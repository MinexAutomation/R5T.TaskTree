using System;
using System.Collections.Generic;

using R5T.NetStandard;


namespace R5T.TaskTree
{
    public class TaskTreeLeaf<TContext> : ITaskTreeLeafNode<TContext>
    {
        public string Name { get; }
        public string Description { get; }
        public IConsumer<TContext> Task { get; }

        public IEnumerable<ITaskTreeNode<TContext>> Children => TaskTreeNode<TContext>.LeafChildren;


        public TaskTreeLeaf(string name, string description, IConsumer<TContext> task)
        {
            this.Name = name;
            this.Description = description;
            this.Task = task;
        }

        public TaskTreeLeaf(IConsumer<TContext> task)
            : this(TaskTreeNode.DefaultName, TaskTreeNode.DefaultDescription, task)
        {
        }
    }
}
