using IntergalacticTravel.Contracts;
using IntergalacticTravel.Tests.Mock;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    [TestFixture]
    public class TeleportUnit_Should
    {
        [Test]
        public void TeleportUnitThrowArgumentNullException_WhenUnitToTeleportIsNull()
        {
            //Arrange
            var targetLocation = new Mock<ILocation>();
            //var teleportStationMock = new TeleportStationMock(ownerStub.Object, galacticMapStub.Object, locationStub.Object);targetLocation.SetupGet(x => x.Planet.Name).Returns("Protos");

            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new Mock<IEnumerable<IPath>>();
            var locationStub = new Mock<ILocation>();

            var teleportStationMock = new TeleportStationMock(ownerStub.Object, galacticMapStub.Object, locationStub.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => teleportStationMock.TeleportUnit(null, targetLocation.Object));
        }

        [Test]
        public void TeleportUnitThrowArgumentNullException_WhenDestinationIsNull()
        {
            //Arrange
            var unitToTeleport = new Unit(123, "BattleShip Galaktica");

            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new Mock<IEnumerable<IPath>>();
            var locationStub = new Mock<ILocation>();

            var teleportStationMock = new TeleportStationMock(ownerStub.Object, galacticMapStub.Object, locationStub.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => teleportStationMock.TeleportUnit(unitToTeleport, null));
        }
    }
}
