using IntergalacticTravel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests.UnitFactoryTests
{
    [TestFixture]
    public class CreateUnit_Should
    {
        [Test]
        public void GetUnitCreateUnitProcyon_WhenPassedValueIsValid()
        {
            //Arrange
            var commandProcyon = "Create unit Procyon Gosho 1";

            //Act
            var factory = new UnitsFactory();
            var newUnit = factory.GetUnit(commandProcyon);

            //Assert
            Assert.IsInstanceOf<Procyon>(newUnit);

        }

        [Test]
        public void GetUnitCreateUnitLuyten_WhenPassedValueIsValid()
        {
            //Arrange
            var commandProcyon = "Create unit Luyten Pesho 2";

            //Act
            var factory = new UnitsFactory();
            var newUnit = factory.GetUnit(commandProcyon);

            //Assert
            Assert.IsInstanceOf<Luyten>(newUnit);

        }

        [Test]
        public void GetUnitCreateUnitLacaille_WhenPassedValueIsValid()
        {
            //Arrange
            var commandProcyon = "Create unit Lacaille Tosho 3";
            var factory = new UnitsFactory();

            //Act
            var newUnit = factory.GetUnit(commandProcyon);

            //Assert
            Assert.IsInstanceOf<Lacaille>(newUnit);

        }
    }
}
