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
    public class CtorInstallCommand_Should
    {
        [Test]
        public void Ctor_ShoudThrowArgumentNullException_WhenInstallerValueIsNull()
        {
            //Arrange

            var packageVersionStub = new PackageVersion(7, 3, 4, VersionType.alpha);

            var packageStub = new Package("NUnit", packageVersionStub);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommand(null, packageStub));
        }

        [Test]
        public void Ctor_ShoudThrowArgumentNullException_WhenIPackageValueIsNull()
        {
            //Arrange
            var packetStub = new Mock<IPackage>();
            var packagesStub = new Mock<IRepository<IPackage>>();
            var projectStub = new Project("Pesho", "Bali", packagesStub.Object);

            var packageDownloaderStub = new Mock<IDownloader>();

            var packageInstallerStub = new PackageInstaller(packageDownloaderStub.Object, projectStub);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => new InstallCommand(packageInstallerStub, null));
        }


    }
}
