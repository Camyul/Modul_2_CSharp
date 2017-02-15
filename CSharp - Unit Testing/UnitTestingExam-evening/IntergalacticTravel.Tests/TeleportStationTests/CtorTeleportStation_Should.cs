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
    public class CtorTeleportStation_Should
    {
        [Test]
        public void CtorSetOwner_WhenPassedValueIsValid()
        {
            //Arrange & Act
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new Mock<IEnumerable<IPath>>();
            var locationStub = new Mock<ILocation>();

            ownerStub.SetupGet(x => x.NickName).Returns("Pesho");

            var teleportStationMock = new TeleportStationMock(ownerStub.Object, galacticMapStub.Object, locationStub.Object);

            //Assert
            Assert.AreEqual("Pesho", teleportStationMock.Owner.NickName);


        }

        [Test]
        public void CtorSetgalacticMap_WhenPassedValueIsValid()
        {
            //Arrange
            var ownerStub = new Mock<IBusinessOwner>();
            
            var locationStub = new Mock<ILocation>();
            var pathStub = new Mock<IPath>();
            var goldStub = new Resources(0, 0, 50);
            var galacticMapStub = new List<IPath>() { pathStub.Object };

            pathStub.SetupGet(x => x.Cost).Returns(goldStub);

            //Act
            var teleportStation = new TeleportStationMock(ownerStub.Object, galacticMapStub, locationStub.Object);
            

            //Assert
            Assert.AreEqual(goldStub, teleportStation.GalacticMap.Single(x => x.Cost == goldStub).Cost);


        }

        [Test]
        public void CtorSetLocation_WhenPassedValueIsValid()
        {
            //Arrange & Act
            var ownerStub = new Mock<IBusinessOwner>();
            var galacticMapStub = new Mock<IEnumerable<IPath>>();
            var locationStub = new Mock<ILocation>();

            locationStub.SetupGet(x => x.Planet.Name).Returns("Asgard");

            var teleportStationMock = new TeleportStationMock(ownerStub.Object, galacticMapStub.Object, locationStub.Object);

            //Assert
            Assert.AreEqual("Asgard", teleportStationMock.Location.Planet.Name);


        }
    }
}
