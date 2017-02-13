using Academy.Core.Contracts;
using Moq;
using NUnit.Framework;
using System;
using Academy.Commands.Adding;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Tests.Commands.Adding.Mock;

namespace Academy.Tests.Commands.Adding.AddingToSeasonCommandsTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenThePassedFactoryIsNull()
        {
            //Arrange
            var engineMock = new Mock<IEngine>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(null, engineMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenThePassedEngineIsNull()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(factoryMock.Object, null));
        }

        //За да тестваме привате филдовете, ги правим протектед, правим наследник на класа и го слагаме в тест асемблито, за да можем да тестваме 
        //полетата и те да не се виждат от вън.

        [Test]
        public void SetFactory_WhenThePassedFactoryIsValid()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            //Act 
            var command = new AddStudentToSeasonCommandMock(factoryMock.Object, engineMock.Object);

            //Assert
            Assert.AreEqual(factoryMock.Object, command.AcademyFactory);
        }

        [Test]
        public void SetEngine_WhenThePassedFactoryIsValid()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            //Act 
            var command = new AddStudentToSeasonCommandMock(factoryMock.Object, engineMock.Object);

            //Assert
            Assert.AreEqual(engineMock.Object, command.Engine);
        }
    }
}
