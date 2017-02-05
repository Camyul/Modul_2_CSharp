namespace Tasker.Tests.Models.TaskTest
{
    using NUnit.Framework;
    using System;
    using Tasker.Models;
    [TestFixture]
    public class DescriptionTests
    {
        [TestCase(null)]
        [TestCase("")]
        [TestCase("    ")]
        public void Description_ShouldThrowArgumentNullExeption_WhenPassedNullOrEmptyValue(string value)
        {
            //Arrange
            var sut = new Task("Valid Description");


            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => sut.Description = value);
        }
    }
}
