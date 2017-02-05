namespace Tasker.Tests.Models.TaskTest
{
    using NUnit.Framework;
    using Tasker.Models;
    [TestFixture]
    class CtorTest
    {
        [Test]
        public void Ctor_ShouldAssignDescription_WhenInvoked()
        {
            //Arrange & Act
            var expected = "Valid Description";
            var sut = new Task(expected);

            //Assert
            Assert.AreEqual(expected, sut.Description);
        }
    }
}
