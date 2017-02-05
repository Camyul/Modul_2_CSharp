namespace Tasker.Tests.Models.TaskTest
{
    using NUnit.Framework;
    using System;
    using Tasker.Models;
    [TestFixture]
    public class IdTests
    {
        [TestCase(-1)]
        [TestCase(-10)]
        public void Id_ShouldThrowArgumentExeption_WhenPassedValueInInvalidRange(int value)
        {
            //Arrange
            var sut = new Task("Valid Description");


            
            //Act & Assert
            Assert.Throws<ArgumentException>(() => sut.Id = value);
        }

        [TestCase(1)]
        [TestCase(10)]      //Test prez property(prez get)
        public void Id_ShouldSetPassedValue_WhenPassedValueIsValid(int value)
        {
            //Arrange
            var sut = new Task("Valid Description");

            //Act
            sut.Id = value;

            //Assert
            Assert.AreEqual(value, sut.Id);
        }

        [TestCase(1)]
        [TestCase(10)]      
        public void Id_ShouldNotThrow_WhenPassedPositiveValue(int value)
        {
            //Arrange
            var sut = new Task("Valid Description");


            //Act & Assert
            Assert.DoesNotThrow(() => sut.Id = value);
            
        }
    }
}
