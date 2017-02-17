using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.ProjectTests
{
    [TestFixture]
    public class CtorProject_Should
    {
        [Test]
        public void CtorCreateTheProject_WhenTheObjectIsConstructedwithPassedValues()
        {
            //Arrange
            var validName = "Pesho";
            var validLocation = "Bali";


            //Act
            var projectTest = new Project(validName, validLocation);

            //Assert
            Assert.IsInstanceOf<Project>(projectTest);
        }

        [Test]
        public void CtorCreateTheProject_WhenTheObjectIsConstructedwithPassedAndOptionalValues()
        {
            //Arrange
            var validName = "Pesho";
            var validLocation = "Bali";
            var packetStub = new Mock<IPackage>();
            var packagesStub = new Mock<IRepository<IPackage>>();
            packagesStub.Setup(x => x.Add(packetStub.Object));
            
            //Act
            var projectTest = new Project(validName, validLocation, packagesStub.Object);

            //Assert
            Assert.IsInstanceOf<Project>(projectTest);
        }

        [Test]
        public void CtorSetPropertyName_WhenPassedAndOptionalValuesIsValid()
        {
            //Arrange
            var validName = "Pesho";
            var validLocation = "Bali";
            var packetStub = new Mock<IPackage>();
            var packagesStub = new Mock<IRepository<IPackage>>();
            packagesStub.Setup(x => x.Add(packetStub.Object));

            //Act
            var projectTest = new Project(validName, validLocation, packagesStub.Object);

            //Assert
            Assert.AreEqual(validName, projectTest.Name);
        }

        [Test]
        public void ThrowArgumentNullException_WhenValueOfNameIsNull()
        {
            //Arrange
            var validLocation = "Bali";
            var packetStub = new Mock<IPackage>();
            var packagesStub = new Mock<IRepository<IPackage>>();
            packagesStub.Setup(x => x.Add(packetStub.Object));
            
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Project(null, validLocation, packagesStub.Object));
        }

        [Test]
        public void CtorSetPropertyLocation_WhenPassedAndOptionalValuesIsValid()
        {
            //Arrange
            var validName = "Pesho";
            var validLocation = "Bali";
            var packetStub = new Mock<IPackage>();
            var packagesStub = new Mock<IRepository<IPackage>>();
            packagesStub.Setup(x => x.Add(packetStub.Object));

            //Act
            var projectTest = new Project(validName, validLocation, packagesStub.Object);

            //Assert
            Assert.AreEqual(validLocation, projectTest.Location);
        }

        [Test]
        public void ThrowArgumentNullException_WhenValueOfLocationIsNull()
        {
            //Arrange
            var validName = "Pesho";
            var packetStub = new Mock<IPackage>();
            var packagesStub = new Mock<IRepository<IPackage>>();
            packagesStub.Setup(x => x.Add(packetStub.Object));

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Project(validName, null, packagesStub.Object));
        }
    }
}
