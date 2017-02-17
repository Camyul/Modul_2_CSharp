using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Info.Contracts;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestFixture]
    public class AddPackageRepository_Should
    {
        [Test]
        public void AddThrowArgumentNullException_WhenPassedValueIsNull()
        {
            //Arrange
            var loggerStub = new Mock<ILogger>();
            var packageRepositoryMock = new PackageRepository(loggerStub.Object);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => packageRepositoryMock.Add(null));
        }

        [Test]
        public void AddDoNotThrow_WhenPassedValueIsValid()
        {
            //Arrange
            var packetStub = new Mock<IPackage>();
            var loggerStub = new Mock<ILogger>();
            var packageRepositoryMock = new PackageRepository(loggerStub.Object);

            //Act & Assert
            Assert.DoesNotThrow(() => packageRepositoryMock.Add(packetStub.Object));
        }

       
    }
}
