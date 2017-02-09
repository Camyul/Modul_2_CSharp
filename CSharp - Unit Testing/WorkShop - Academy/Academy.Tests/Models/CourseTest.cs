namespace Academy.Tests.Models
{
    using Academy.Models;
    using Academy.Models.Contracts;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    [TestFixture]
    class CourseTest
    {
        [Test]
        public void Ctor_ShouldAssignName_WhenInvokedWithValidData()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

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
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

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
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

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
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

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
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

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
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

            //Act
            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Assert
            Assert.IsInstanceOf<List<ILecture>>(testCourse.Lectures);
        }

        [Test]
        public void Name_ShouldBeThrowArgumentException_WhenValueIsInvalid()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => testCourse.Name = "W");
        }

        [Test]
        public void Name_ShouldBeDoesNotThrow_WhenValueIsValid()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Act & Assert
            Assert.DoesNotThrow(() => testCourse.Name = "Gosho");
        }

        [Test]
        public void Name_ShouldBeCorrectlyAssign_WhenPassedValueIsValid()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

            //Act
            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Assert
            Assert.AreEqual(name, testCourse.Name);
        }

        [Test]
        public void LecturesPerWeek_ShouldThrowArgumentException_WhenPassedValueIsInvalid()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => testCourse.LecturesPerWeek = 100);
        }

        [Test]
        public void LecturesPerWeek_ShouldDoesNotThrow_WhenPassedValueIsValid()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Act & Assert
            Assert.DoesNotThrow(() => testCourse.LecturesPerWeek = 5);
        }

        [Test]
        public void LecturesPerWeek_ShouldCorrectlyAssign_WhenPassedValueIsValid()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

            //Act
            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Assert
            Assert.AreEqual(lecturesPerWeek, testCourse.LecturesPerWeek);
        }

        [Test]
        public void StartingDate_ShouldThrowArgumentNullException_WhenPassedValueIsInvalid()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => testCourse.StartingDate = DateTime.Parse(null));
        }

        [Test]
        public void StartingDate_ShouldDoesNotThrow_WhenPassedValueIsValid()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Act & Assert
            Assert.DoesNotThrow(() => testCourse.StartingDate = DateTime.ParseExact("12-05-2015", stringFormat, CultureInfo.InvariantCulture));
        }

        [Test]
        public void StartingDate_ShouldCorrectlyAssign_WhenPassedValueIsValid()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

            //Act
            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Assert
            Assert.AreEqual(startDate, testCourse.StartingDate);
        }

        [Test]
        public void EndingDate_ShouldThrowArgumentNullException_WhenPassedValueIsInvalid()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => testCourse.EndingDate = DateTime.Parse(null));
        }

        [Test]
        public void EndingDate_ShouldDoesNotThrow_WhenPassedValueIsValid()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Act & Assert
            Assert.DoesNotThrow(() => testCourse.EndingDate = DateTime.ParseExact("12-09-2016", stringFormat, CultureInfo.InvariantCulture));
        }

        [Test]
        public void EndingDate_ShouldCorrectlyAssign_WhenPassedValueIsValid()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

            //Act
            Course testCourse = new Course(name, lecturesPerWeek, startDate, endDate);

            //Assert
            Assert.AreEqual(endDate, testCourse.EndingDate);
        }

        [Test]
        public void ToString_ShouldBeReturnPassedData_FromListOfLectures()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

            string lectureName = "HTML Fundamentals";
            DateTime lectureDate = DateTime.ParseExact("17-05-2016", stringFormat, CultureInfo.InvariantCulture);
            ITrainer cuki = new Trainer("Cuki",
                new List<string>(new string[]{ "HTML", "CSS", "JavaScript" }));
            
            ICourse testCourse = new Course(name, lecturesPerWeek, startDate, endDate);
            ILecture testLecture = new Lecture(lectureName, lectureDate, cuki);

            //Act
            testCourse.Lectures.Add(testLecture);

            //Assert
            Assert.AreEqual(1, testCourse.Lectures.Count);
        }

        [Test]
        public void ToString_ShouldBeReturnMessage_WhenListOfLecturesIsEmpty()
        {
            //Arrange
            string name = "Pesho";
            int lecturesPerWeek = 4;
            string stringFormat = "dd-MM-yyyy";
            DateTime startDate = DateTime.ParseExact("11-05-2016", stringFormat, CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact("11-06-2016", stringFormat, CultureInfo.InvariantCulture);

            ICourse testCourse = new Course(name, lecturesPerWeek, startDate, endDate);


            //Act & Assert
            Assert.AreNotEqual(-1, testCourse.ToString().IndexOf("  * There are no lectures in this course!"));
            //Assert.AreEqual(true, testCourse.ToString().Contains("  * There are no lectures in this course!")); //Също работи
        }
    }
}
