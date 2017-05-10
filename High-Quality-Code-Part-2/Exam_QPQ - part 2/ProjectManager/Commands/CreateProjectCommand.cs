using Bytes2you.Validation;
using ProjectManager.Common.Exceptions;
using ProjectManager.Data;
using ProjectManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManager.Commands
{
    public class CreateProjectCommand : ICommand
    {
        private Database db;
        private ModelsFactory factory;

        public CreateProjectCommand(Database database, ModelsFactory factory)
        {
            Guard.WhenArgument(database, "CreateProjectCommand Database")
                .IsNull()
                .Throw();

            Guard.WhenArgument(factory, "CreateProjectCommand ModelsFactory")
                .IsNull()
                .Throw();

            this.Db = database;
            this.Factory = factory;
        }

        public Database Db
        {
            get
            {
                return this.db;
            }

            set
            {
                this.db = value;
            }
        }

        public ModelsFactory Factory
        {
            get
            {
                return this.factory;
            }

            set
            {
                this.factory = value;
            }
        }

        public string Execute(IList<string> parameters)
        {
            if (parameters.Count != 4)
            {
                throw new UserValidationException("Invalid command parameters count!");
            }

            if (parameters.Any(x => x == string.Empty))
            {
                throw new UserValidationException("Some of the passed parameters are empty!");
            }

            if (this.Db.Projects.Any(x => x.Name == parameters[0]))
            {
                throw new UserValidationException("A project with that name already exists!");
            }

            var project = this.Factory.CreateProject(parameters[0], parameters[1], parameters[2], parameters[3]);
            this.Db.Projects.Add(project);

            return "Successfully created a new project!";
        }
    }
}
