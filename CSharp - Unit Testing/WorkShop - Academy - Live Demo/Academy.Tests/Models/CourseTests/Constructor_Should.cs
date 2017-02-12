using Academy.Models;
using Academy.Models.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.CourseTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetProperName_WhenTheObjectIsConstructed()
        {
            //Arrange & Act
            var course = new Course("Valid Name", 5, new DateTime(2017, 02, 10), new DateTime(2017, 03, 10));

            //Assert
            Assert.AreEqual("Valid Name", course.Name);
        }

        [Test]
        public void SetProperLecturesPerWeek_WhenTheObjectIsConstructed()
        {
            //Arrange & Act
            var course = new Course("Valid Name", 5, new DateTime(2017, 02, 10), new DateTime(2017, 03, 10));

            //Assert
            Assert.AreEqual(5, course.LecturesPerWeek);
        }

        [Test]
        public void InitializeLecturesCollection_WhenTheObjectIsConstructed()
        {
            //Arrange & Act
            var course = new Course("Valid Name", 5, new DateTime(2017, 02, 10), new DateTime(2017, 03, 10));

            //Assert
            Assert.IsInstanceOf(typeof(List<ILecture>), course.Lectures);
            //Assert.AreEqual(0, course.Lectures.Count); //Variant 2
            //Assert.IsNotNull(course.Lectures); // V3
        }
    }
}
