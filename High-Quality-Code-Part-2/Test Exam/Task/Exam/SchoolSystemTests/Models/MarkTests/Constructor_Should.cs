using System;
using NUnit.Framework;
using SchoolSystem.Enums;
using SchoolSystem.Models;

namespace SchoolSystemTests.Models.MarkTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetPropertyValuation_WhenObjectIsConstructed()
        {
            //Arrange 
            float valuation = 3.2f;
            Subject subject = Subject.English;
            // Act

            var mark = new Mark(subject, valuation);

            //Assert
            Assert.AreEqual(valuation, mark.Valuation);

        }

        [Test]
        public void SetPropertySubject_WhenObjectIsConstructed()
        {
            //Arrange 
            float valuation = 3.5f;
            Subject subject = Subject.Bulgarian;

            // Act
            var mark = new Mark(subject, valuation);

            //Assert
            Assert.AreEqual(subject, mark.Subject);

        }
    }
}
