using System;
using System.Collections.Generic;

using R5T.NetStandard;
using R5T.NetStandard.Types;


namespace R5T.TaskTree
{
    public class TaskTreeBranch<TContext> : ITaskTreeBranchNode<TContext>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IConsumer<TContext> Task { get; } = DoNothingConsumer<TContext>.Instance;

        private List<ITaskTreeNode<TContext>> Children { get; } = new List<ITaskTreeNode<TContext>>();
        IEnumerable<ITaskTreeNode<TContext>> ITaskTreeNode<TContext>.Children => this.Children;


        public TaskTreeBranch(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public TaskTreeBranch()
            : this(TaskTreeNode.DefaultName, TaskTreeNode.DefaultDescription)
        {
        }

        public void AddChild(ITaskTreeNode<TContext> child)
        {
            this.Children.Add(child);
        }
    }
}
