using Bytes2you.Validation;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Exceptions;
using System.Linq;

namespace ProjectManager.Framework.Core.Common.Providers
{
    public class CommandProcessor
    {
        private ICommandsFactory commandFactory;

        public CommandProcessor(ICommandsFactory commandFactory)
        {
            this.commandFactory = commandFactory;
        }

        public ICommandsFactory CommandFactory
        {
            get
            {
                return this.commandFactory;
            }

            set
            {
                Guard.WhenArgument(value, "CommandProcessor CommandsFactory").IsNull().Throw();
                this.commandFactory = value;
            }
        }

        public string ProcessCommand(string commandLine)
        {
            if (string.IsNullOrWhiteSpace(commandLine))
            {
                throw new UserValidationException("No command has been provided!");
            }

            var commandName = commandLine.Split(' ')[0];
            var commandParameters = commandLine
                .Split(' ')
                .Skip(1)
                .ToList();

            var command = this.CommandFactory.GetCommandFromString(commandName);

            return command.Execute(commandParameters);
        }
    }
}
