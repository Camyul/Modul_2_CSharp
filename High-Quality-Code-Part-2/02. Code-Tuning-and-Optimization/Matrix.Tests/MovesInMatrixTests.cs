using Matrix;
using NUnit.Framework;
using System;

namespace Matrix.Tests
{
    [TestFixture]
    public class MovesInMatrixTests
    {
        [Test]
        public void ChangeDirection_ShouldBeThrowArgumentOutOfRangeException_WhenPassedValueIsInvalid()
        {
            int directionX = -2;
            int directionY = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => MovesInMatrix.ChangeDirection(ref directionX, ref directionY));
        }
    }
}
