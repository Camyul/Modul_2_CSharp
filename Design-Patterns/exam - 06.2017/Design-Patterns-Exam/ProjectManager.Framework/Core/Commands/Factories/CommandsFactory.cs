using Bytes2you.Validation;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Contracts;

namespace ProjectManager.Framework.Core.Commands.Factories
{
    public class CommandsFactory : ICommandsFactory
    {
        private readonly IServiceLocator serviceLocator;

        public CommandsFactory(IServiceLocator serviceLocator)
        {
            Guard.WhenArgument(serviceLocator, "serviceLocator").IsNull().Throw();

            this.serviceLocator = serviceLocator;
        }

        public ICommand GetCommandFromString(string fullCommand)
        {
            Guard.WhenArgument(fullCommand, "fullCommand").IsNull().Throw();

            string commandName = fullCommand.Split(' ')[0];

            return this.serviceLocator.GetCommand(commandName);
        }
    }
}
