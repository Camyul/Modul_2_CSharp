using System;

namespace Tasker.Models
{
    public class Task
    {
        public Task(string description)
        {
            this.Description = description;
            this.IsDone = false;
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsDone { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
