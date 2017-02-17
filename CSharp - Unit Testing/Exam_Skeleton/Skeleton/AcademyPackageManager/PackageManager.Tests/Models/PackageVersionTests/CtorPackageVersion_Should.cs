using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using System;

namespace PackageManager.Tests.Models.PackageVersionTests
{
    [TestFixture]
    public class CtorPackageVersion_Should
    {
        [Test]
        public void CreateTheVersionPackage_WhenTheObjectIsConstructedwithPassedValues()
        {
            //Arrange
            var major = 7;
            var minor = 3;
            var patch = 4;
            var type = VersionType.beta;

            //Act
            var packageVersionTest = new PackageVersion(major, minor, patch, type);

            //Assert
            Assert.IsInstanceOf<PackageVersion>(packageVersionTest);
        }

        [Test]
        public void SetTheMajor_WhenTheObjectIsConstructedwithPassedValue()
        {
            //Arrange
            var major = 7;
            var minor = 3;
            var patch = 4;
            var type = VersionType.beta;

            //Act
            var packageVersionTest = new PackageVersion(major, minor, patch, type);

            //Assert
            Assert.AreEqual(major, packageVersionTest.Major);
        }

        [Test]
        public void SetTheMinor_WhenTheObjectIsConstructedwithPassedValue()
        {
            //Arrange
            var major = 7;
            var minor = 3;
            var patch = 4;
            var type = VersionType.beta;

            //Act
            var packageVersionTest = new PackageVersion(major, minor, patch, type);

            //Assert
            Assert.AreEqual(minor, packageVersionTest.Minor);
        }

        [Test]
        public void SetThePatch_WhenTheObjectIsConstructedwithPassedValue()
        {
            //Arrange
            var major = 7;
            var minor = 3;
            var patch = 4;
            var type = VersionType.beta;

            //Act
            var packageVersionTest = new PackageVersion(major, minor, patch, type);

            //Assert
            Assert.AreEqual(patch, packageVersionTest.Patch);
        }

        [Test]
        public void SetTheType_WhenTheObjectIsConstructedwithPassedValue()
        {
            //Arrange
            var major = 7;
            var minor = 3;
            var patch = 4;
            var type = VersionType.beta;

            //Act
            var packageVersionTest = new PackageVersion(major, minor, patch, type);

            //Assert
            Assert.AreEqual(type, packageVersionTest.VersionType);
        }

        [Test]
        public void ThrowArgumentException_WhenTheMajorSetWithInValidValue()
        {
            //Arrange
            var notValidValuemajor = -7;
            var minor = 3;
            var patch = 4;
            var type = VersionType.beta;
            

            //Act & Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(notValidValuemajor, minor, patch, type));
        }

        [Test]
        public void ThrowArgumentException_WhenTheMinorSetWithInValidValue()
        {
            //Arrange
            var major = 7;
            var notValidValueminor = -3;
            var patch = 4;
            var type = VersionType.beta;


            //Act & Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, notValidValueminor, patch, type));
        }

        [Test]
        public void ThrowArgumentException_WhenThePatchSetWithInValidValue()
        {
            //Arrange
            var major = 7;
            var minor = 3;
            var notValidValuepatch = -4;
            var type = VersionType.beta;


            //Act & Assert
            Assert.Throws<ArgumentException>(() => new PackageVersion(major, minor, notValidValuepatch, type));
        }
        
    }
}
