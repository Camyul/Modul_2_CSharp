using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Commands.Adding.AddStudentToCourseCommandTests
{
    [TestFixture]
    public class CtorAddStudentToCourse_Should
    {
        [Test]
        public void CtorThrowArgumentNullException_WhenIAcademyFactoryPassedValueIsNull()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(factoryMock.Object, null));
        }


        [Test]
        public void CtorThrowArgumentNullException_WhenIEnginePassedValueIsNull()
        {
            //Arrange
            var engineMock = new Mock<IEngine>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(null, engineMock.Object));
        }

        [Test]
        public void CtorSetAcademyFactory_WhenAcademyFactoryPassedValueIsValid()
        {
            //Arrange
            var engineMock = new Mock<IEngine>();

            var factoryMock = new Mock<IAcademyFactory>();
            //Act 
            var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            //Assert
            Assert.AreEqual(factoryMock.Object, command.Factory);

        }

        [Test]
        public void CtorSetEngine_WhenAcademyIEnginePassedValueIsValid()
        {
            //Arrange
            var engineMock = new Mock<IEngine>();

            var factoryMock = new Mock<IAcademyFactory>();
            //Act 
            var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            //Assert
            Assert.AreEqual(engineMock.Object, command.Engine);

        }
    }
}
