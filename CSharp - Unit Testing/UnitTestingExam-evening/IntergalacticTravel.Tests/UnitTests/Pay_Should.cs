using Castle.Core.Resource;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests.UnitTests
{
    [TestFixture]
    public class Pay_Should
    {
        [Test]
        public void Pay_ShouldReturnResourceObject_WhenPassedValueIsValid()
        {
            //Arrange
            var testUnit = new Unit(123, "Unvisible");
            var testResource = new Resources(1000, 1000, 1000);
            var testResourceTwo = new Resources(100, 100, 100);

            testUnit.Resources.Add(testResource);
            
            //Act & Assert
            
            Assert.AreEqual(testResource.GetType(), testUnit.Pay(testResourceTwo).GetType());

        }

        [Test]
        public void Pay_ShouldDecreaseOwnerResourceByAmountOfTheCost_WhenPassedValueIsValid()
        {
            //Arrange
            var testUnit = new Unit(123, "Unvisible");
            var testResource = new Resources(0, 0, 1000);
            var testResourceTwo = new Resources(0, 0, 100);

            //Act
            testUnit.Resources.Add(testResource);
            testUnit.Pay(testResourceTwo);

            //Assert

            Assert.AreEqual(new Resources(0,0,900).GoldCoins, testUnit.Resources.GoldCoins);

        }

        [Test]
        public void Pay_ThrowNullReferenceException_WhenPassedValueIsNull()
        {
            //Arrange
            var testUnit = new Unit(123, "Unvisible");
                     

            //Act & Assert

            Assert.Throws<NullReferenceException>(() => testUnit.Pay(null));

        }
    }
}
