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
    public class CompareTo_Should
    {

        [Test]
        public void CompareToDoNotThrowArgumentNullException_WhenPassedValuesIsValid()
        {
            //Arrange

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);
            var otherPackageVersionStub = new PackageVersion(7, 3, 5, VersionType.alpha);

            var otherPackageStub = new Package("NUnit", otherPackageVersionStub);
            var packageMock = new Package("NUnit", packageVersionStub);


            //Act & Assert
            Assert.DoesNotThrow(() => packageMock.CompareTo(otherPackageStub));
        }

        [Test]
        public void CompareToThrowsArgumentNullException_WhenPassedValuesIsNull()
        {
            //Arrange

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);
            
            var packageMock = new Package("NUnit", packageVersionStub);


            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => packageMock.CompareTo(null));
        }

        [Test]
        public void CompareToThrowsArgumentException_WhenPassedNameOfOtherPackageIsDifferent()
        {
            //Arrange

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);
            var otherPackageVersionStub = new PackageVersion(7, 3, 5, VersionType.alpha);

            var otherPackageStub = new Package("NUnit", otherPackageVersionStub);
            var packageMock = new Package("Pesho", packageVersionStub);


            //Act & Assert
            Assert.Throws<ArgumentException>(() => packageMock.CompareTo(otherPackageStub));
        }

        [Test]
        public void CompareToDoNotThrowArgumentException_WhenPassedNameOfOtherPackageIsEquals()
        {
            //Arrange

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);
            var otherPackageVersionStub = new PackageVersion(7, 3, 5, VersionType.alpha);

            var otherPackageStub = new Package("NUnit", otherPackageVersionStub);
            var packageMock = new Package("NUnit", packageVersionStub);


            //Act & Assert
            Assert.DoesNotThrow(() => packageMock.CompareTo(otherPackageStub));
        }

        [Test]
        public void CompareToReturnsNegativOne_WhenPassedPackageVersionIsHighest()
        {
            //Arrange

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);
            var otherPackageVersionStub = new PackageVersion(7, 3, 5, VersionType.alpha);

            var otherPackageStub = new Package("NUnit", otherPackageVersionStub);
            var packageMock = new Package("NUnit", packageVersionStub);

            //Act
            var result = packageMock.CompareTo(otherPackageStub);


            //Assert
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void CompareToReturnsOne_WhenPassedPackageVersionIsLowest()
        {
            //Arrange

            var packageVersionStub = new PackageVersion(7, 3, 5, VersionType.alpha);
            var otherPackageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);

            var otherPackageStub = new Package("NUnit", otherPackageVersionStub);
            var packageMock = new Package("NUnit", packageVersionStub);

            //Act
            var result = packageMock.CompareTo(otherPackageStub);


            //Assert
            Assert.AreEqual(1, result);
        }

        [Test]
        public void CompareToReturnsZero_WhenPassedPackageVersionIsEqual()
        {
            //Arrange

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);
            var otherPackageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);

            var otherPackageStub = new Package("NUnit", otherPackageVersionStub);
            var packageMock = new Package("NUnit", packageVersionStub);

            //Act
            var result = packageMock.CompareTo(otherPackageStub);


            //Assert
            Assert.AreEqual(0, result);
        }
    }
}
