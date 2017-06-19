using ProjectManager.Framework.Core.Common.Contracts;
using System;

namespace ProjectManager.Framework.Core.Common.Providers
{
    public class ConsoleLogger : IWriter
    {
        public void Write(string value)
        {
            Console.Write(value);
        }

        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }
    }
}
