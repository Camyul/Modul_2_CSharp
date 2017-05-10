using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    public class CreateUserCommand : ICommand
    {
        public string Execute(IList<string> listParametrers)
        {
            var db = new Database();

            var modelsFactory = new ModelsFactory();

            if (listParametrers.Count != 3)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (listParametrers.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            if (db.Projects[int.Parse(listParametrers[0])].Users.Any() && db.Projects[int.Parse(listParametrers[0])].Users.Any(x => x.UserName == listParametrers[1]))
            {
                throw new UserValidationException("A user with that username already exists!");
            }

            db.Projects[int.Parse(listParametrers[0])].Users.Add(modelsFactory.CreateUser(listParametrers[1], listParametrers[2]));

            return "Successfully created a new user!";
        }
    }
}
