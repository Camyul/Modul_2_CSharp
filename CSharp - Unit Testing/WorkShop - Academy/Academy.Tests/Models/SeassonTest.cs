namespace Academy.Tests.Models
{
    using Academy.Models;
    using Academy.Models.Contracts;
    using Academy.Models.Enums;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    [TestFixture]
    class SeassonTest
    {
        [Test]
        public void ListUsers_ShouldBeReturnListOfUsers()
        {
            //Arrange
            ISeason testSeasson = new Season(2016, 2017, Initiative.SoftwareAcademy);
            IStudent testStudent = new Student("Ivanov", Track.Dev);

            //Act 
            testSeasson.Students.Add(testStudent);

            //Assert
            Assert.True(testSeasson.ListUsers().Any());

        }

        [Test]
        public void ListUsers_ShouldBeReturnAListOfUsers()
        {
            //Arrange
            ISeason testSeasson = new Season(2016, 2017, Initiative.SoftwareAcademy);
            ITrainer cuki = new Trainer("Cuki",
               new List<string>(new string[] { "HTML", "CSS", "JavaScript" }));

            //Act
            testSeasson.Trainers.Add(cuki);

            //Assert
            Assert.True(testSeasson.ListUsers().Any());
        }

        [Test]
        public void ListUsers_ShouldBeReturnMessage_WhenListOfUsersIsEmpty()
        {
            //Arrange
            ISeason testSeasson = new Season(2016, 2017, Initiative.SoftwareAcademy);
            IStudent testStudent = new Student("Ivanov", Track.Dev);

            //Act & Assert
            Assert.True(testSeasson.ListUsers().Contains("There are no users in this season!"));
        }

        public void ListCourses_ShouldBeReturnListCourses()
        {
            ISeason testSeasson = new Season(2016, 2017, Initiative.SoftwareAcademy);

            string name = "JavaScript";
            int lecturesPerWeek = 4;
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Act
            testSeasson.Courses.Add(testCourse);

            //Assert

            Assert.True(testSeasson.ListCourses().Any());
        }

        [Test]
        public void ListCourses_ShouldBeReturnMessage_WhenListCoursesIsEmpty()
        {
            //Arrange
            ISeason testSeasson = new Season(2016, 2017, Initiative.SoftwareAcademy);

            //Act & Assert
            Assert.True(testSeasson.ListCourses().Contains("There are no courses in this season!"));
        }
    }
}
