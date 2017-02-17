using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class CtorPackage_Should
    {
        [Test]
        public void CtorCreateThePackage_WhenTheObjectIsConstructedwithPassedValues()
        {
            //Arrange
            var namePackageStub = "NUnit";

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);

            //Act
            var packetMock = new Package(namePackageStub, packageVersionStub);

            Assert.IsInstanceOf<IPackage>(packetMock);
        }

        [Test]
        public void CtorCreateThePackage_WhenTheObjectIsConstructedwithPassedAndOptionalValues()
        {
            //Arrange
            var namePackageStub = "NUnit";

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);

            var packetStub = new Mock<IPackage>();
            var dependeciesStub = new Mock<ICollection<IPackage>>();
            dependeciesStub.Setup(x => x.Add(packetStub.Object));


            //Act
            var packetMock = new Package(namePackageStub, packageVersionStub, dependeciesStub.Object);


            Assert.AreEqual(0, packetMock.Dependencies.Count);
        }

        [Test]
        public void CtorSetPackagePropertyName_WhenPassedAndOptionalValuesIsValid()
        {
            //Arrange
            var namePackageStub = "NUnit";

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);

            //Act
            var packetMock = new Package(namePackageStub, packageVersionStub);

            //Assert
            Assert.AreEqual(namePackageStub, packetMock.Name);
        }

        [Test]
        public void CtorPackageThrowArgumentNullException_WhenPassedNameValueIsNull()
        {
            //Arrange

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);
            

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Package(null, packageVersionStub));
        }

        [Test]
        public void CtorSetPackagePropertyVersion_WhenPassedAndOptionalValuesIsValid()
        {
            //Arrange
            var namePackageStub = "NUnit";

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);

            //Act
            var packetMock = new Package(namePackageStub, packageVersionStub);

            //Assert
            Assert.AreEqual(packageVersionStub, packetMock.Version);
        }

        [Test]
        public void CtorPackageThrowArgumentNullException_WhenPassedVersionValueIsNull()
        {
            //Arrange

            var namePackageStub = "NUnit";


            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Package(namePackageStub, null));
        }

        [Test]
        public void CtorSetPackagePropertyURL_WhenPassedAndOptionalValuesIsValid()
        {
            //Arrange
            var namePackageStub = "NUnit";

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);

            //Act
            var packetMock = new Package(namePackageStub, packageVersionStub);

            //Assert
            StringAssert.Contains("7", packetMock.Url);
            StringAssert.Contains("3", packetMock.Url);
            StringAssert.Contains("4", packetMock.Url);
            StringAssert.Contains("alpha", packetMock.Url);
        }
    }
}
