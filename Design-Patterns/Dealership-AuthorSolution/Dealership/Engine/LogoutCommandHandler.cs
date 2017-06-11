using Dealership.Contracts;

namespace Dealership.Engine
{
    public class LogoutCommandHandler : CommandHandler
    {
        private readonly ILoggedUser loggedUserProvider;

        public LogoutCommandHandler(ILoggedUser loggedUserProvider)
        {
            this.loggedUserProvider = loggedUserProvider;
        }
        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "Logout";
        }

        protected override string HandleInternal(ICommand command)
        {
            return this.Logout();
        }

        private string Logout()
        {
            this.loggedUserProvider.LoggedUser = null;
            return DealershipEngine.UserLoggedOut;
        }
    }
}
