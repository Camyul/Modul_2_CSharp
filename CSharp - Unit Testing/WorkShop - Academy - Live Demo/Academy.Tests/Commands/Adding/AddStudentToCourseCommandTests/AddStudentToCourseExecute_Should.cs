using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Academy.Tests.Commands.Adding.AddStudentToCourseCommandTests
{
    [TestFixture]
    public class AddStudentToCourseExecute_Should   //Az
    {
        [Test]
        public void ThrowArgumentException_WhenFormValueIsInValid()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            var courseMock = new Mock<ICourse>();
            //courseMock.SetupGet(x => x.Name).Returns("CSharp");

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(x => x.Username).Returns("Pesho");
            engineMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });
            seasonMock.SetupGet(x => x.Courses).Returns(new List<ICourse>() { courseMock.Object });

            engineMock.SetupGet(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => command.Execute(new List<string>() { "Pesho", "0", "0", "greda" }));
        }

        [Test]
        public void ExecuteAddStudentToCourseOnsiteForm_WhenCommandValueIsValid()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            var courseMock = new Mock<ICourse>();
            //courseMock.SetupGet(x => x.Name).Returns("CSharp");


            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(x => x.Username).Returns("Pesho");
            engineMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

            //courseMock.SetupGet(x => x.OnlineStudents).Returns(new List<IStudent>() { studentMock.Object });
            courseMock.SetupGet(x => x.OnsiteStudents).Returns(new List<IStudent>() { studentMock.Object });

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });
            seasonMock.SetupGet(x => x.Courses).Returns(new List<ICourse>() { courseMock.Object });

            engineMock.SetupGet(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            //Act
            command.Execute(new List<string>() { "Pesho", "0", "0", "onsite" });

            //Assert
            Assert.AreEqual(2, courseMock.Object.OnsiteStudents.Count);
        }

        [Test]
        public void ExecuteAddStudentToCourseOnlineForm_WhenCommandValueIsValid()
        {
            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            var courseMock = new Mock<ICourse>();
            //courseMock.SetupGet(x => x.Name).Returns("CSharp");


            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(x => x.Username).Returns("Pesho");
            engineMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

            courseMock.SetupGet(x => x.OnlineStudents).Returns(new List<IStudent>() { studentMock.Object });
            //courseMock.SetupGet(x => x.OnsiteStudents).Returns(new List<IStudent>() { studentMock.Object });

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });
            seasonMock.SetupGet(x => x.Courses).Returns(new List<ICourse>() { courseMock.Object });

            engineMock.SetupGet(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            var command = new AddStudentToCourseCommand(factoryMock.Object, engineMock.Object);

            //Act
            command.Execute(new List<string>() { "Pesho", "0", "0", "online" });

            //Assert
            Assert.AreEqual(2, courseMock.Object.OnlineStudents.Count);
        }

        [Test]
        public void ReturnCorrectMessage_ThatContainUsernameAndStudentId()
        {
            //Arrange
            var factoriMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(x => x.Username).Returns("Pesho");

            var courseMock = new Mock<ICourse>();
            courseMock.SetupGet(x => x.Name).Returns("CSS");
            //courseMock.SetupGet(x => x.OnsiteStudents).Returns(new List<IStudent> { studentMock.Object });
            courseMock.SetupGet(x => x.OnlineStudents).Returns(new List<IStudent> { studentMock.Object });

            var seasonMock = new Mock<ISeason>();
            //seasonMock.SetupGet(x => x.Students).Returns(new List<IStudent> { studentMock.Object });
            seasonMock.SetupGet(x => x.Courses).Returns(new List<ICourse> { courseMock.Object });

            engineMock.SetupGet(x => x.Students).Returns(new List<IStudent> { studentMock.Object });
            engineMock.SetupGet(x => x.Seasons).Returns(new List<ISeason> { seasonMock.Object });
            

            var command = new AddStudentToCourseCommand(factoriMock.Object, engineMock.Object);

            //Act
            var result = command.Execute(new List<string>() {"Pesho", "0", "0", "online" });

            //Assert
            StringAssert.Contains("Student Pesho", result);
            StringAssert.Contains("Course 0.CSS", result);
        }
    }
}
