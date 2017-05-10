using System.Collections.Generic;

namespace ProjectManager.Commands.Contracts
{
    public interface ICreateTaskCommand
    {
        string Execute(List<string> parameters);
    }
}
