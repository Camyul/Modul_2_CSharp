using System;

namespace SchoolSystem.Framework.Core.Commands.Contracts
{
    public interface ICommandFactory
    {
        ICommand GetCommand(Type type);
    }
}
