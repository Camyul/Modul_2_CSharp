namespace Academy.Tests.Models.Abstractions
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    class UserTest
    {
        [Test]
        public void Ctor_ShouldAssignUsername_WhenPassedValidValue()
        {
            //Arrange
            string userName = "Kolyo";

            //Act
            UserAbstractClassTesting testUser = new UserAbstractClassTesting(userName);

            //Assert
            Assert.AreEqual(userName, testUser.Username);
        }

        [Test]
        public void Username_ShouldThrowArgumentException_WhenPassedInvalidValue()
        {
            //Arrange
            string userName = "Kolyo";

            //Act
            UserAbstractClassTesting testUser = new UserAbstractClassTesting(userName);

            //Assert
            Assert.Throws<ArgumentException>(() => testUser.Username = "WW");
        }

        [Test]
        public void Username_ShouldDoesNotThrow_WhenPassedValidValue()
        {
            //Arrange
            string userName = "Kolyo";

            //Act
            UserAbstractClassTesting testUser = new UserAbstractClassTesting(userName);

            //Assert
            Assert.DoesNotThrow(() => testUser.Username = "Nikolay");
        }

        [Test]
        public void Username_ShouldCorrectlyAssign_WhenPassedValidValue()
        {
            //Arrange
            string userName = "Kolyo";
            UserAbstractClassTesting testUser = new UserAbstractClassTesting(userName);

            //Act
            userName = "Nikolay";
            testUser.Username = userName;


            //Assert
            Assert.AreEqual(userName, testUser.Username);
        }
    }
}
