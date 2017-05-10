using Moq;
using NUnit.Framework;
using ProjectManager.Commands;
using ProjectManager.Common.Exceptions;
using System.Collections.Generic;

namespace ProjectManagerTests.CreateTaskCommandTests
{
    [TestFixture]
    public class CreateTaskCommand_Should
    {
        [TestCase(3)]
        [TestCase(6)]
        public void ThrowUserValidationException_WhenCountIsInvalid(int number)
        {
            var parametersStub = new Mock<IList<string>>();
            parametersStub.SetupGet(x => x.Count).Returns(number);

            var classCommandMock = new CreateTaskCommand();

            Assert.Throws<UserValidationException>(() => classCommandMock.Execute(parametersStub.Object));
        }
    }
}
