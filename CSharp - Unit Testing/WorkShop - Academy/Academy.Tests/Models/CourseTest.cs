namespace Academy.Tests.Models
{
    using Academy.Models;
    using Academy.Models.Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    [TestFixture]
    class CourseTest
    {
        [Test]
        public void Ctor_ShouldAssignName_WhenInvokedWithValidData()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            DateTime startDate = DateTime.Parse("11-05-2016");
            DateTime endDate = DateTime.Parse("11-06-2016");

            //Act
            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Assert
            Assert.AreEqual(name, testCourse.Name);
        }

        [Test]
        public void Ctor_ShouldAssignLecturesPerWeek_WhenInvokedWithValidData()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            DateTime startDate = DateTime.Parse("11-05-2016");
            DateTime endDate = DateTime.Parse("11-06-2016");

            //Act
            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Assert
            Assert.AreEqual(lecturesPerWeek, testCourse.LecturesPerWeek);
        }

        [Test]
        public void Ctor_ShouldAssignStartDate_WhenInvokedWithValidData()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            DateTime startDate = DateTime.Parse("11-05-2016");
            DateTime endDate = DateTime.Parse("11-06-2016");

            //Act
            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Assert
            Assert.AreEqual(startDate, testCourse.StartingDate);
        }

        [Test]
        public void Ctor_ShouldAssignEndDate_WhenInvokedWithValidData()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            DateTime startDate = DateTime.Parse("11-05-2016");
            DateTime endDate = DateTime.Parse("11-06-2016");

            //Act
            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Assert
            Assert.AreEqual(endDate, testCourse.EndingDate);
        }

        [Test]
        public void Ctor_ShouldCorectInitializeListOfOnlineStudents_WhenInvokedWithValidData()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            DateTime startDate = DateTime.Parse("11-05-2016");
            DateTime endDate = DateTime.Parse("11-06-2016");

            //Act
            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Assert
            Assert.IsInstanceOf<List<IStudent>>(testCourse.OnlineStudents);
        }

        [Test]
        public void Ctor_ShouldCorectInitializeListOfOnsiteStudents_WhenInvokedWithValidData()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            DateTime startDate = DateTime.Parse("11-05-2016");
            DateTime endDate = DateTime.Parse("11-06-2016");

            //Act
            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Assert
            Assert.IsInstanceOf<List<IStudent>>(testCourse.OnsiteStudents);
        }

        [Test]
        public void Ctor_ShouldCorectInitializeListOfLectures_WhenInvokedWithValidData()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            DateTime startDate = DateTime.Parse("11-05-2016");
            DateTime endDate = DateTime.Parse("11-06-2016");

            //Act
            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Assert
            Assert.IsInstanceOf<List<ILecture>>(testCourse.Lectures);
        }
    }
}
