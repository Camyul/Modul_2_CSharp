using Academy.Commands.Adding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Core.Contracts;

namespace Academy.Tests.Commands.Adding.Mock
{
    internal class AddStudentToSeasonCommandMock : AddStudentToSeasonCommand
    {
        public AddStudentToSeasonCommandMock(IAcademyFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        //Експозваме полетата с публични пропъртита, за да може да се тестват.
        public IAcademyFactory AcademyFactory
        {
            get
            {
                return this.factory;
            }
        }

        public IEngine Engine
        {
            get
            {
                return this.engine;
            }
        }
    }
}
