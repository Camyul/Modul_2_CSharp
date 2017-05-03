using System;
using NUnit.Framework;
using SchoolSystem.Enums;
using SchoolSystem.Models;

namespace SchoolSystemTests.Models.MarkTests
{
    [TestFixture]
    public class GetViolation_Should
    {
        [Test]
        public void ReturnTheProperValue_When()
        {
            //Arrange 
            Mark mark = new Mark(Subject.English, 3.3f);

            //Act
            var result = mark.Valuation;

            //Assert
            Assert.AreEqual(3.3f, result);

        }
    }
}
