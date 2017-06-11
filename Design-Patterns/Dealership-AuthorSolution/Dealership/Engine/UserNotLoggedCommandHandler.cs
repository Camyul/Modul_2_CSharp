using Dealership.Contracts;
using System;

namespace Dealership.Engine
{
    public class UserNotLoggedCommandHandler : CommandHandler
    {
        private readonly ILoggedUser loggedUserProvider;

        public UserNotLoggedCommandHandler(ILoggedUser loggedUserProvider)
        {
            this.loggedUserProvider = loggedUserProvider;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name != "RegisterUser" && command.Name != "Login" && this.loggedUserProvider.LoggedUser == null;
        }

        protected override string HandleInternal(ICommand command)
        {
            return DealershipEngine.UserNotLogged;
        }
    }
}
