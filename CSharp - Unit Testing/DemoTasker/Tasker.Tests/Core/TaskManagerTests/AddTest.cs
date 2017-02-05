

namespace Tasker.Tests.Core.TaskManagerTests
{
    using Fakes;
    using Moq;
    using NUnit.Framework;
    using System;
    using Tasker.Core;
    using Tasker.Core.Contracts;
    using Tasker.Models.Contract;
    [TestFixture]
    public class AddTest
    {
        [Test]
        public void Add_ShouldThrowArgumentNullException_WhenPassedNullValue()
        {
            //Arrange
            var idProviderStub = new Mock<IIdProvider>();
            var consoleLoggerStub = new Mock<ILogger>();
            var sut = new TaskManager(idProviderStub.Object, consoleLoggerStub.Object);

            //Act & Assert

            Assert.Throws<ArgumentNullException>(() => sut.Add(null));
        }

       
        

        [TestCase(0)]
        [TestCase(5)]
        public void Add_ShouldAssignIdToProvidedTask_WhenValidTaskPassed(int expectedValue)
        {
            //Arrange
            var taskMock = new Mock<ITask>();
            var idProviderStub = new Mock<IIdProvider>();
            var consoleLoggerStub = new Mock<ILogger>();

            var sut = new TaskManager(idProviderStub.Object, consoleLoggerStub.Object);
            idProviderStub.Setup(x => x.NextId()).Returns(expectedValue);

            //Act
            sut.Add(taskMock.Object);

            //Assert
            taskMock.VerifySet(x => x.Id = expectedValue);

        }

        [Test]
        public void Add_ShouldLogMessage_WhenAddedProvidedTaskToCollection()
        {
            var taskStub = new Mock<ITask>();
            var idProvidedStub = new Mock<IIdProvider>();
            var consoleLoggerMock = new Mock<ILogger>();
            var sut = new TaskManager(idProvidedStub.Object, consoleLoggerMock.Object);

            sut.Add(taskStub.Object);

            consoleLoggerMock.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Add_ShouldAddTaskToCollection_WhenProvidedTaskIsValid()
        {
            var taskStub = new Mock<ITask>();
            var idProvidedStub = new Mock<IIdProvider>();
            var consoleLoggerMock = new Mock<ILogger>();
            var sut = new TaskManagerFake(idProvidedStub.Object, consoleLoggerMock.Object);

            sut.Add(taskStub.Object);

            Assert.That(() => sut.ExposedTasks.Contains(taskStub.Object));
        }
    }
}
