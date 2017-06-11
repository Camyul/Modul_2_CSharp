using Dealership.Engine;

namespace Dealership.Contracts
{
    public interface ICommandHandler : ICommandHandlerProcessor
    {
        void SerSuccessor(ICommandHandler commandHandler);
    }
}
