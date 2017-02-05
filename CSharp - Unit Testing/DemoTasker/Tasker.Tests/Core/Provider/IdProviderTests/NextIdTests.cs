namespace Tasker.Tests.Core.Provider.IdProviderTests
{
    using NUnit.Framework;
    using Tasker.Core.Provider;
    [TestFixture]
    public class NextIdTests
    {
        [Test]
        public void NextId_ShouldReturnIncrementedValue_WhenInvoked()
        {
            var sut = new IdProvider();

            var resultOne = sut.NextId();
            var resultTwo = sut.NextId();

            Assert.AreEqual(0, resultOne);
            Assert.AreEqual(1, resultTwo);
        }
    }
}
