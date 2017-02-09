namespace Academy.Tests.Models.Abstractions
{
    using Academy.Models.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class UserAbstractClassTesting : User
    {
        public UserAbstractClassTesting(string username) : base(username)
        {
        }
    }
}
