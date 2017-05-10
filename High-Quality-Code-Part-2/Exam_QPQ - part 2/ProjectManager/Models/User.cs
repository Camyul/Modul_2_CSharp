using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.Models
{
    public class User
    {
        [Required(ErrorMessage = "User Username is required!")]
        private string userName;
        [Required(ErrorMessage = "User Email is required!")]
        [EmailAddress(ErrorMessage = "User Email is not valid!")]
        private string email;

        public User(string username, string email)
        {
            this.UserName = username;
            this.Email = email;
        }

        public string UserName
        {
            get
            {
                return this.userName;
            }

            set
            {
                this.userName = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("    Username: " + this.UserName);
            stringBuilder.AppendLine("    Email: " + this.Email);
            return stringBuilder.ToString();
        }
    }
}
