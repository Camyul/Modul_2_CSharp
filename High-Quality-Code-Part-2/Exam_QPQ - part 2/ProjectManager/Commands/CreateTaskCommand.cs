using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    public sealed class CreateTaskCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            var db = new Database();

            var factory = new ModelsFactory();

            if (parameters.Count != 4)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }
            
            var project = db.Projects[int.Parse(parameters[0])];

            var owner = project.Users[int.Parse(parameters[1])];

            var task = factory.CreateTask(owner, parameters[2], parameters[3]);
            project.Tasks.Add(task);

            return "Successfully created a new task!";
        }
    }
}
