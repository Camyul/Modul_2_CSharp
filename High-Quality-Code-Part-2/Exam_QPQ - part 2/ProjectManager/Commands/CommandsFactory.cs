using ProjectManager.Commands.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Common.Providers;
using ProjectManager.Data;
using ProjectManager.Models;
using System;

namespace ProjectManager.Commands
{
    public class CommandsFactory : ICommandsFactory
    {
        private ModelsFactory modelsFactory;
        private Database db;

        public CommandsFactory(Database db, ModelsFactory factory)
        {
            this.Db = db;
            this.ModelsFactory = factory;
        }

        public ModelsFactory ModelsFactory
        {
            get
            {
                return this.modelsFactory;
            }

            set
            {
                this.modelsFactory = value;
            }
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

        public ICommand CreateCommandFromString(string commandName)
        {
            var command = this.ToLowerCase(commandName);

            switch (command)
            {
                case "createproject": return new CreateProjectCommand(this.Db, this.ModelsFactory);
                case "createuser": return new CreateUserCommand();
                case "createtask": return new CreateTaskCommand();
                case "listprojects": return new ListProjectsCommand(this.Db);
                default: throw new UserValidationException("The passed command is not valid!");
            }
        }

        private string ToLowerCase(string parameters)
        {
            var command = parameters.ToLower();

            return command;
        }
    }
}