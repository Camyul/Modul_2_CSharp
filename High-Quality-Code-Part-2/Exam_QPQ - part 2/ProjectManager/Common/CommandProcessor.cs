using ProjectManager.Commands;
using System.Linq;

namespace ProjectManager.Common
{
    internal class CommandProcessor
    {
        private CommandsFactory commandFactory;

        public CommandProcessor(CommandsFactory factory)
        {
            this.CommandFactory = factory;
        }

        public CommandsFactory CommandFactory
        {
            get
            {
                return this.commandFactory;
            }

            private set
            {
                this.commandFactory = value;
            }
        }

        public string Process(string stringCommand)
        {
            if (string.IsNullOrWhiteSpace(stringCommand))
            {
                throw new Exceptions.UserValidationException("No command has been provided!");
            }

            var command = this.CommandFactory.CreateCommandFromString(stringCommand.Split(' ')[0]);
            return command.Execute(stringCommand.Split(' ')
                .Skip(1)
                .ToList());
        }
    }
}
