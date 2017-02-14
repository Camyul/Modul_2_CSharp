using IntergalacticTravel.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests.UnitFactoryTests
{
    [TestFixture]
    public class CreateUnit_Throw
    {
        [TestCase("Create unit Pesho Tosho 3")]
        [TestCase("Create unit Labrador Pesho 3")]
        public void CreateUnitThrowInvalidUnitCreationCommandException_WhenPassedValueIsInvalid(string command)
        {
            //Arrange
            var commandProcyon = command;
            var factory = new UnitsFactory();

            //Act & Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit(commandProcyon));
        }
    }
}
