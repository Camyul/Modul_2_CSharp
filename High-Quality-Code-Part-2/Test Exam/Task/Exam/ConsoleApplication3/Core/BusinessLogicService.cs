using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Core
{



    // I am not sure if we need this, but too scared to delete. 
    class BusinessLogicService
    {
        public void Execute(ConsoleReaderProvider readedCommand)
        {
            var engine = new Engine(readedCommand);
            engine.BrumBrum();
        }
    }
}
