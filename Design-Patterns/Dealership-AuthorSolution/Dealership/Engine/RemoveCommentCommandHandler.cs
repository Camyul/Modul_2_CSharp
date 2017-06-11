using Dealership.Contracts;
using System;
using System.Linq;

namespace Dealership.Engine
{
    public class RemoveCommentCommandHandler : CommandHandler
    {
        private readonly IUser userProvider;
        private readonly IUserProvider usersProvider;

        public RemoveCommentCommandHandler(IUser userProvider, IUserProvider usersProvider)
        {
            this.userProvider = userProvider;
            this.usersProvider = usersProvider;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "RemoveComment";
        }

        protected override string HandleInternal(ICommand command)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;
            var commentIndex = int.Parse(command.Parameters[1]) - 1;
            var username = command.Parameters[2];

            return this.RemoveComment(vehicleIndex, commentIndex, username);
        }

        private string RemoveComment(int vehicleIndex, int commentIndex, string username)
        {
            var user = this.usersProvider.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return string.Format(DealershipEngine.NoSuchUser, username);
            }

            ValidateRange(vehicleIndex, 0, user.Vehicles.Count, DealershipEngine.RemovedVehicleDoesNotExist);
            ValidateRange(commentIndex, 0, user.Vehicles[vehicleIndex].Comments.Count, DealershipEngine.RemovedCommentDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];
            var comment = user.Vehicles[vehicleIndex].Comments[commentIndex];

            this.userProvider.RemoveComment(comment, vehicle);

            return string.Format(DealershipEngine.CommentRemovedSuccessfully, this.userProvider.Username);
        }

        private static void ValidateRange(int? value, int min, int max, string message)
        {
            if (value < min || value >= max)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
