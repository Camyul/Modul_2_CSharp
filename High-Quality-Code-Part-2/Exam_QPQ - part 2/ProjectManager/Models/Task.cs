using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Models
{
    public class Task
    {
        [Required(ErrorMessage = "Task Name is required!")]
        private string name;

        [Required(ErrorMessage = "Task Owner is required")]
        private User owner; 

        private string state; 

        public Task(string name, User owner, string state)
        {
            this.Name = name;
            this.Owner = owner;
            this.State = state;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public User Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                this.owner = value;
            }
        }

        public string State
        {
            get
            {
                return this.state;
            }

            set
            {
                this.state = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.AppendLine("    Name: " + this.Name);
            builder.AppendLine("    Owner: " + this.Owner.UserName);
            builder.Append("    State: " + this.State);

            return builder.ToString();
        }
    }
}
