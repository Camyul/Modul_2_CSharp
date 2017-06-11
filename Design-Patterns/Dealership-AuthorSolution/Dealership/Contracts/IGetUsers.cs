using System.Collections.Generic;

namespace Dealership.Contracts
{
    public interface IGetUsers
    {
        IEnumerable<IUser> Users { get; }
    }
}
