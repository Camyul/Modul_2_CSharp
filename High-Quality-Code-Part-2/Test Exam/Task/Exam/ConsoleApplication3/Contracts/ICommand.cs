using System.Collections.Generic;

namespace SchoolSystem.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
