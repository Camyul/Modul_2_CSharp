using Moq;
using NUnit.Framework;
using System;
using Tasker.Core;
using Tasker.Core.Contracts;
using Tasker.Models.Contracts;

namespace Tasker.Tests.Core
{
    [TestFixture]
    public class TestManagerTests
    {
        [Test]
        public void Add_ShouldLogSuccessfulMessage_WhenPassedValidTask()
        {
            //Arrange
            var idProviderStub = new Mock<IIdProvider>();
            var loggerMock = new Mock<ILogger>();
            var taskStub = new Mock<ITask>();

            //idProviderStub.Setup(x => x.NextId()).Returns(0); - При извикване на NextID(), винаги връща "0".
            //idProviderStub.SetupGet(x => x.Property).Returns(null); - При извикване на get на проперти връща "null" или  каквото му кажем.

            var manager = new TaskManager(idProviderStub.Object, loggerMock.Object);
            

            //Act
            manager.Add(taskStub.Object);

            //Assert
            loggerMock.Verify(x => x.Log(It.IsAny< String>()), Times.Exactly(1));
        }

        [Test]  //Not Work
        public void Add_ShouldCorrectlyAssignTaskIds_WhenValidTaskIsProvided()
        {
            //Arrange
            var expectedId = 0;
            var loggerStub = new Mock<ILogger>();
            var idProviderStub = new Mock<IIdProvider>();
            var taskMock = new Mock<ITask>();
            
            idProviderStub.Setup(x => x.NextId()).Returns(expectedId);

            var manager = new TaskManager(idProviderStub.Object, loggerStub.Object);

            //Act
            manager.Add(taskMock.Object);

            //Assert
            taskMock.Verify(x => x.Id == expectedId);

        }
    }
}
