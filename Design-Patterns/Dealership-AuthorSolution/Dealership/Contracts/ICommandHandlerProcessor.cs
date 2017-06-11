using Dealership.Engine;

namespace Dealership.Contracts
{
    public interface ICommandHandlerProcessor
    {
        string Handle(ICommand command);
    }
}
