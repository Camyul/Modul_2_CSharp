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
    public class GetUser_Should
    {
        [Test]
        public void ReturnProperUsername_WhenTheGetMethodIsCalled()
        {
            //Arrange
            var user = new UserMock("Pesho");

            //Act
            var foundUsername = user.Username;

            //Assert
            Assert.AreEqual("Pesho", foundUsername);
        }
    }
}
