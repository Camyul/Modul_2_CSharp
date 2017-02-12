using Academy.Models;
using Academy.Models.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.CourseTests
{
    [TestFixture]
    public class ToString_Should
    {
        [Test]
        public void IterateOverLecturesCollection_WhenTheCollectionIsNotEmpty()
        {
            //Arrange
            var course = new Course("Valid Name", 5, new DateTime(2017, 02, 10), new DateTime(2017, 03, 10));

            var lectureMock = new Mock<ILecture>();
            lectureMock.Setup(x => x.ToString());   //SetUp-ваме това, което ще тестваме

            course.Lectures.Add(lectureMock.Object);

            //Act
            course.ToString();

            //Assert
            lectureMock.Verify(x => x.ToString(), Times.Once); //Проверяваме, че ToString() е извикано точно 1 път

        }

        [Test]
        public void IterateOverLecturesCollection_WhenTheCollectionIsNotEmpty_JustMock() //With JustMock
        {
            //Arrange
            var course = new Course("Valid Name", 5, new DateTime(2017, 02, 10), new DateTime(2017, 03, 10));

            var lectureMock = Telerik.JustMock.Mock.Create<Lecture>(); //Мокваме директно обекта, не интерфейса
            Telerik.JustMock.Mock.Arrange(() => lectureMock.ToString());   

            course.Lectures.Add(lectureMock);

            //Act
            course.ToString();

            //Assert
            Telerik.JustMock.Mock.Assert(() => lectureMock.ToString(), Telerik.JustMock.Occurs.Once());

        }

        [Test]
        public void AddMessageToEndResult_WhenTheCollectionIsEmpty()
        {
            //Arrange
            var course = new Course("Valid Name", 5, new DateTime(2017, 02, 10), new DateTime(2017, 03, 10));

            
            //Act
            var result = course.ToString();

            //Assert
            StringAssert.Contains("no lectures", result);

        }
    }
}
