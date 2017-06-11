using Dealership.Contracts;
using Dealership.Factories;
using System;
using System.Linq;

namespace Dealership.Engine
{
    public class LogginCommandHandler : CommandHandler
    {
        private readonly IGetUsers getUsers;

        private readonly ILoggedUser loggedUserProvider;

        public LogginCommandHandler(IGetUsers userProvider, ILoggedUser loggedUserProvider)
        {
            this.getUsers = userProvider;
            this.loggedUserProvider = loggedUserProvider;
        }
        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "Login";
        }

        protected override string HandleInternal(ICommand command)
        {
            var username = command.Parameters[0];
            var password = command.Parameters[1];

            return this.Login(username, password);
        }

        private string Login(string username, string password)
        {
            if (this.loggedUserProvider.LoggedUser != null)
            {
                return string.Format(DealershipEngine.UserLoggedInAlready, this.loggedUserProvider.LoggedUser.Username);
            }

            var userFound = this.getUsers.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            if (userFound != null && userFound.Password == password)
            {
                this.loggedUserProvider.LoggedUser = userFound;
                return string.Format(DealershipEngine.UserLoggedIn, username);
            }

            return DealershipEngine.WrongUsernameOrPassword;
        }
    }
}
