using Dealership.Common.Enums;
using Dealership.Contracts;
using System.Text;

namespace Dealership.Engine
{
    public class ShowUsersCommandHandler : CommandHandler
    {
        private readonly IUser userProvider;
        private readonly IUserProvider usersProvider;

        public ShowUsersCommandHandler(IUser userProvider, IUserProvider usersProvider)
        {
            this.userProvider = userProvider;
            this.usersProvider = usersProvider;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "ShowUsers";
        }

        protected override string HandleInternal(ICommand command)
        {
            return this.ShowAllUsers();
        }

        private string ShowAllUsers()
        {
            if (this.userProvider.Role != Role.Admin)
            {
                return DealershipEngine.YouAreNotAnAdmin;
            }

            var builder = new StringBuilder();
            builder.AppendLine("--USERS--");
            var counter = 1;
            foreach (var user in this.usersProvider.Users)
            {
                builder.AppendLine(string.Format("{0}. {1}", counter, user.ToString()));
                counter++;
            }

            return builder.ToString().Trim();
        }
    }
}
