using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Commands.Adding.AddingToSeasonCommandsTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void ThrowsArgumentException_WhenStudentsAlreadyInTheSeason()
        {

            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            var studentMock = new Mock<IStudent>(); //Правим студент с име което ние му задаваме
            studentMock.SetupGet(x => x.Username).Returns("Pesho"); //Getter-а винаги връща Пешо
            
            //Винаги връща лист от 1 студент Пешо
            engineMock.SetupGet(x => x.Students).Returns(new List<IStudent>() {studentMock.Object}); 


            var seasonMock = new Mock<ISeason>();

            //Винаги връща лист от 1 студент Пешо
            seasonMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });

            //Винаги връща лист от 1 сезон със лист от 1 студент Пешо
            engineMock.SetupGet(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => command.Execute(new List<string>() { "Pesho", "0" }));

        }

        [Test]
        public void AddStudentToCollection_WhenStudentsIsNotInTheSeason()
        {

            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            var studentMock = new Mock<IStudent>(); //Правим студент с име което ние му задаваме
            studentMock.SetupGet(x => x.Username).Returns("Pesho"); //Getter-а винаги връща Пешо

            //Винаги връща лист от 1 студент Пешо
            engineMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });


            var seasonMock = new Mock<ISeason>();

            var studentNoPeshoMock = new Mock<IStudent>(); //Правим студент с име което ние му задаваме
            studentNoPeshoMock.SetupGet(x => x.Username).Returns("Not Pesho"); //Ne e Pesho

            var studentsInSeason = new List<IStudent>() { studentNoPeshoMock.Object }; //Лист от 1 студент не е Пешо

            seasonMock.SetupGet(x => x.Students).Returns(studentsInSeason);//Подаваме като референция
            
            engineMock.SetupGet(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

            //Act 
            var result = command.Execute(new List<string>() { "Pesho", "0" });

            //Assert
            Assert.AreEqual(2, seasonMock.Object.Students.Count);

        }

        [Test]
        public void ReturnMessage_WhenStudentsIsAddedToCollection()
        {

            //Arrange
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();

            var studentMock = new Mock<IStudent>(); //Правим студент с име което ние му задаваме
            studentMock.SetupGet(x => x.Username).Returns("Pesho"); //Getter-а винаги връща Пешо

            //Винаги връща лист от 1 студент Пешо
            engineMock.SetupGet(x => x.Students).Returns(new List<IStudent>() { studentMock.Object });


            var seasonMock = new Mock<ISeason>();

            var studentNoPeshoMock = new Mock<IStudent>(); //Правим студент с име което ние му задаваме
            studentNoPeshoMock.SetupGet(x => x.Username).Returns("Not Pesho"); //Ne e Pesho

            var studentsInSeason = new List<IStudent>() { studentNoPeshoMock.Object }; //Лист от 1 студент не е Пешо

            seasonMock.SetupGet(x => x.Students).Returns(studentsInSeason);//Подаваме като референция

            engineMock.SetupGet(x => x.Seasons).Returns(new List<ISeason>() { seasonMock.Object });

            var command = new AddStudentToSeasonCommand(factoryMock.Object, engineMock.Object);

            //Act 
            var result = command.Execute(new List<string>() { "Pesho", "0" });

            //Assert
            StringAssert.Contains("Pesho", result);
            StringAssert.Contains("Season 0", result);

        }

    }
}
