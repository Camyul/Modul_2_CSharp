using Moq;
using NUnit.Framework;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Core.PackageInstalerTests
{
    [TestFixture]
    public class CtorPackageInstaller_Should
    {
        [Test]
        public void Ctor_ShouldCreateObject_WhenPassedValueIsValid()
        {
            // Arrange
            var packetStub = new Mock<IPackage>();
            var packagesStub = new Mock<IRepository<IPackage>>();
            var projectStub = new Project("Pesho", "Bali", packagesStub.Object);

            var packageDownloaderStub = new Mock<IDownloader>();

            //Act
            var packageInstallerMock = new PackageInstaller(packageDownloaderStub.Object, projectStub);

            //Assert
            Assert.IsInstanceOf<PackageInstaller>(packageInstallerMock);
        }
    }
}
