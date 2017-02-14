using Academy.Tests.Models.Abstractions.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Tests.Models.Abstractions.UserTests
{
    [TestFixture]
    public class Ctor_Should        //Az 
    {
        [TestCase("We")]
        [TestCase(" ")]
        [TestCase(null)]
        [TestCase("Very very very very very very very very very very very very very big String")]
        public void ThrowArgumentException_WhenInvalidValuePassedToCtor(string username)
        {
            //Arrange
            var userMock = new UserMock("Pesho");

            //Act & Assert
            Assert.Throws<ArgumentException>(() => userMock.Username = username);
        }

        [Test]
        public void CtorDoNotThrow_WhenValidValuePassedToCtor()
        {
            //Arrange
            var userName = "Pesho";

            //Act & Assert
            Assert.DoesNotThrow(() => new UserMock(userName));
        }

        [Test]
        public void CorrectlyAssignUsername_WhenValidValuePassedToCtor()
        {
            //Arrange & Act
            var userName = new UserMock("Pesho");

            //Assert
            Assert.AreEqual("Pesho", userName.Username);

        }
    }
}
