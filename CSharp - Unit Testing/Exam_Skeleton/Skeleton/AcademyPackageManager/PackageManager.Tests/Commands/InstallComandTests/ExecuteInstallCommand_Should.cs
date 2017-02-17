using Moq;
using NUnit.Framework;
using PackageManager.Commands;
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

namespace PackageManager.Tests.Commands.InstallComandTests
{
    [TestFixture]
    class ExecuteInstallCommand_Should
    {
        [Test]
        public void Execute_ShouldCallingPerformOperation_WhenStartedExecute()
        {

            //Arrange
            var packetStub = new Mock<IPackage>();
            var packagesStub = new Mock<IRepository<IPackage>>();
            var projectStub = new Project("Pesho", "Bali", packagesStub.Object);

            var packageDownloaderStub = new Mock<IDownloader>();

            var packageInstallerStub = new Mock<PackageInstaller>(packageDownloaderStub.Object, projectStub);

            var command = new InstallCommand(packageInstallerStub.Object, packetStub.Object);
            //Act


            command.Execute();

            //Assert
            packageInstallerStub.Verify(x => x.PerformOperation(It.IsAny<IPackage>()), Times.Once);


        }
    }
}
