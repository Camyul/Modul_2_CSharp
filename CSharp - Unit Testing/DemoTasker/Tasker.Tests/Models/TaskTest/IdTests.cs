namespace Tasker.Tests.Models.TaskTest
{
    using NUnit.Framework;

    [TestFixture]
    public class IdTests
    {
        [TestCase(-1)]
        [TestCase(-10)]
        public void Id_ShouldThrowArgumentExeption_WhenPassedValueInInvalidRange(int value)
        {
            //Arrange
            var sut = new Tasker();

            
            //Act & Assert
            Assert.Throws<AssertionException>(() => sut.Id = value);
        }
    }
}
