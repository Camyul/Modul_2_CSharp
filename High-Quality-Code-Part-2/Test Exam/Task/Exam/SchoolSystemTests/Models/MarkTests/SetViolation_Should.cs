using NUnit.Framework;
using SchoolSystem.Enums;
using SchoolSystem.Models;
using System;

namespace SchoolSystemTests.Models.MarkTests
{
    [TestFixture]
    public class SetViolation_Should
    {
        [TestCase(1.2f)]
        [TestCase(888.2f)]
        public void ThrowArgumentOutOfRangeException_WhenPassedValueIsInvalid(float number)
        {
            //Arrange 
            Mark mark = new Mark(Subject.English, 3.3f);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => mark.Valuation = number);

            
        }
    }
}
