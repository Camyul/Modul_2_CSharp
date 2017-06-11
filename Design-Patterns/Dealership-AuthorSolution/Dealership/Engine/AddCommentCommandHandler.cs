using Dealership.Contracts;
using Dealership.Factories;
using System;
using System.Linq;

namespace Dealership.Engine
{
    public class AddCommentCommandHandler : CommandHandler
    {
        private readonly IDealershipFactory dealershipFactory;
        private readonly IUser userProvider;
        private readonly IUserProvider usersProvider;
        

        public AddCommentCommandHandler(IDealershipFactory dealershipFactory, IUser userProvider, IUserProvider usersProvider)
        {
            this.dealershipFactory = dealershipFactory;
            this.userProvider = userProvider;
            this.usersProvider = usersProvider;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "AddComment";
        }

        protected override string HandleInternal(ICommand command)
        {
            var content = command.Parameters[0];
            var author = command.Parameters[1];
            var vehicleIndex = int.Parse(command.Parameters[2]) - 1;

            return this.AddComment(content, vehicleIndex, author);
        }

        private string AddComment(string content, int vehicleIndex, string author)
        {
            var comment = this.dealershipFactory.CreateComment(content);
            comment.Author = this.userProvider.Username;
            var user = this.usersProvider.Users.FirstOrDefault(u => u.Username == author);

            if (user == null)
            {
                return string.Format(DealershipEngine.NoSuchUser, author);
            }

            ValidateRange(vehicleIndex, 0, user.Vehicles.Count, DealershipEngine.VehicleDoesNotExist);

            var vehicle = user.Vehicles[vehicleIndex];

            this.userProvider.AddComment(comment, vehicle);

            return string.Format(DealershipEngine.CommentAddedSuccessfully, this.userProvider.Username);
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
