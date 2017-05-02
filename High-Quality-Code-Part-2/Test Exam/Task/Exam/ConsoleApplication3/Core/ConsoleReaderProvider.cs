using SchoolSystem.Contracts;
using System;

namespace SchoolSystem.Core
{
    public class ConsoleReaderProvider : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
