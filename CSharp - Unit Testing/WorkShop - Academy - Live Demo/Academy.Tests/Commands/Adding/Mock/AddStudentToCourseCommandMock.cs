using Academy.Commands.Adding;
using Academy.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Commands.Adding.Mock
{
    internal class AddStudentToCourseCommandMock : AddStudentToCourseCommand
    {
        public AddStudentToCourseCommandMock(IAcademyFactory factory, IEngine engine) : base(factory, engine)
        {
        }
    }
}
