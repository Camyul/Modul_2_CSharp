using Dealership.Contracts;
using System;

namespace Dealership.Engine
{
    public abstract class CommandHandler : ICommandHandler
    {
        private ICommandHandler Successor { get; set; }

        public string Handle(ICommand command)
        {
            if (this.CanHandle(command))
            {
                return this.HandleInternal(command);
            }

            if (this.Successor != null)
            {
                return this.Successor.Handle(command);
            }

            return string.Format(DealershipEngine.InvalidCommand, command.Name);
        }

        public void SerSuccessor(ICommandHandler commandHandler)
        {
            this.Successor = commandHandler;
        }

        protected abstract bool CanHandle(ICommand command);
        protected abstract string HandleInternal(ICommand command);
    }
}
