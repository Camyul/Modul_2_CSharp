using SchoolSystem.Contracts;
using SchoolSystem.Core;
using SchoolSystem.Models;
using System;
using System.Reflection;

namespace SchoolSystem
{
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static void Main()
        {
            // TODO: abstract at leest 2 mor provider like this one
            var readedCommand = new ConsoleReaderProvider();

            var service = new BusinessLogicService();
            service.Execute(readedCommand);
        }
    }
}