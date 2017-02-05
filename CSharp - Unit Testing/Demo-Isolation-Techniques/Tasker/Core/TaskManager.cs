using System;
using System.Collections.Generic;
using System.Linq;
using Tasker.Models;

namespace Tasker.Core
{
    public class TaskManager
    {
        private ICollection<Task> tasks;

        public TaskManager()
        {
            this.tasks = new List<Task>();
        }
        public void Add(Task task)
        {
            if (task == null)
            {
                throw new ArgumentNullException();
            }
            this.tasks.Add(task);
            Console.WriteLine("New Task was Added");
        }

        public void Remove(int id)
        {
            var task = this.tasks.SingleOrDefault(x => x.Id == id);
            this.tasks.Remove(task);
            Console.WriteLine($"The Task with ID {id} was removed");
        }
    }
}
