using NUnit.Framework;
using ProjectManager.Framework.Services;
using System;

namespace ProjectManager.Tests.ProjectManager.Framework.Tests.Services.CachingServiceTests
{
    [TestFixture]
    public class CtorTests_Should
    {
        [Test]
        public void CtorShouldThrow_WhenParameterIsInvalid()
        {
            TimeSpan time = new TimeSpan(0, 0, 1);

            Assert.Throws<ArgumentOutOfRangeException>(() => new CachingService(TimeSpan.Zero - time));
        }

        [Test]
        public void CtorShouldDoNotThrow_WhenParameterIsValid()
        {
            TimeSpan time = new TimeSpan(0, 0, 1);

            Assert.DoesNotThrow(() => new CachingService(time));
        }

        [Test]
        public void CtorShouldCreateInstance_WhenParameterIsValid()
        {
            TimeSpan time = new TimeSpan(0, 0, 1);

            var cachingService = new CachingService(time);

            Assert.IsInstanceOf<CachingService>(cachingService);
        }
    }
}
