using Dealership.Contracts;
using System.Linq;

namespace Dealership.Engine
{
    public class ShowVehiclesCommandHandler : CommandHandler
    {
        private readonly IUserProvider usersProvider;

        public ShowVehiclesCommandHandler(IUserProvider usersProvider)
        {
            this.usersProvider = usersProvider;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "ShowVehicles";
        }

        protected override string HandleInternal(ICommand command)
        {
            var username = command.Parameters[0];

            return this.ShowUserVehicles(username);
        }

        private string ShowUserVehicles(string username)
        {
            var user = this.usersProvider.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            if (user == null)
            {
                return string.Format(DealershipEngine.NoSuchUser, username);
            }

            return user.PrintVehicles();
        }
    }
}
