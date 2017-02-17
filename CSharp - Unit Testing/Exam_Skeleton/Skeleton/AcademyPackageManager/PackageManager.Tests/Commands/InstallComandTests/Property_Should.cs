using Moq;
using NUnit.Framework;
using PackageManager.Commands;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Commands.InstallComandTests
{
    [TestFixture]
    class Property_Should
    {
        [Test]
        public void Ctor_ShoudThrowArgumentNullException_WhenIPackageValueIsNull()
        {
            //Arrange
            var packetStub = new Mock<IPackage>();
            var packagesStub = new Mock<IRepository<IPackage>>();
            var projectStub = new Project("Pesho", "Bali", packagesStub.Object);

            var packageDownloaderStub = new Mock<IDownloader>();

            var packageInstallerStub = new Mock<PackageInstaller>(packageDownloaderStub.Object, projectStub);


            //Act
            var command = new InstallCommand(packageInstallerStub.Object, packetStub.Object);

            //Assert
            Assert.AreEqual(InstallerOperation.Install, packageInstallerStub.Object.Operation);
        }

    }
}
