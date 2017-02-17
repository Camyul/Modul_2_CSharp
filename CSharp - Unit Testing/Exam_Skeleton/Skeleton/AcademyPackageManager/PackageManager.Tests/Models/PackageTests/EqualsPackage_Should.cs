using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.PackageTests
{
    [TestFixture]
    public class EqualsPackage_Should
    {
        [Test]
        public void Equals_ShouldThrowArgumentNullException_WhenPassedValueIsNull()
        {
            //Arrange

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);

            var packageMock = new Package("NUnit", packageVersionStub);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => packageMock.Equals(null));
        }

        [Test]
        public void Equals_DoNotThrow_WhenPassedValueIsNotNull()
        {
            //Arrange

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);
            var otherPackageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);

            var otherPackageStub = new Package("NUnit", otherPackageVersionStub);
            var packageMock = new Package("NUnit", packageVersionStub);

            //Act & Assert
           Assert.DoesNotThrow(() => packageMock.Equals(otherPackageStub));
        }

        [Test]
        public void Equals_ShouldThrowArgumentException_WhenPassedValueIsNotIPackage()
        {
            //Arrange

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);

            var packageMock = new Package("NUnit", packageVersionStub);

            //Act & Assert
            Assert.Throws<ArgumentException>(() => packageMock.Equals("Not a IPackage"));
        }

        [Test]
        public void Equals_DoNotThrow_WhenPassedValueIsIPackage()
        {
            //Arrange

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);
            var otherPackageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);

            var otherPackageStub = new Package("NUnit", otherPackageVersionStub);
            var packageMock = new Package("NUnit", packageVersionStub);

            //Act & Assert
            Assert.DoesNotThrow(() => packageMock.Equals(otherPackageStub));
        }

        [Test]
        public void Equals_ShouldReturnTrue_WhenPassedPackageIsEqual()
        {
            //Arrange

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);
            var otherPackageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);

            var otherPackageStub = new Package("NUnit", otherPackageVersionStub);
            var packageMock = new Package("NUnit", packageVersionStub);

            //Act & Assert
            Assert.IsTrue(packageMock.Equals(otherPackageStub));
        }

        [Test]
        public void Equals_ShouldReturnFalse_WhenPassedPackageIsNotEqual()
        {
            //Arrange

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);
            var otherPackageVersionStub = new PackageVersion(8, 3, 4, VersionType.alpha);

            var otherPackageStub = new Package("NUnit", otherPackageVersionStub);
            var packageMock = new Package("NUnit", packageVersionStub);

            //Act & Assert
            Assert.IsFalse(packageMock.Equals(otherPackageStub));
        }
    }
}
