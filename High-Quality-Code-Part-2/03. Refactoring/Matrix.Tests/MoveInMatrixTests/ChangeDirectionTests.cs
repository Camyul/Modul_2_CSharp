using System;
using Matrix;
using NUnit.Framework;

namespace Matrix.Tests.MoveInMatrixTests
{
    [TestFixture]
    internal class ChangeDirectionTests
    {
        [Test]
        public void ChangeDirection_ShouldBeThrowArgumentOutOfRangeException_WhenFirstArgumentPassedValueIsInvalid()
        {
            int directionX = -2;
            int directionY = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => MovesInMatrix.ChangeDirection(ref directionX, ref directionY));
        }

        [Test]
        public void ChangeDirection_ShouldBeThrowArgumentOutOfRangeException_WhenSecondArgumentPassedValueIsInvalid()
        {
            int directionX = -1;
            int directionY = -2;

            Assert.Throws<ArgumentOutOfRangeException>(() => MovesInMatrix.ChangeDirection(ref directionX, ref directionY));
        }

        [Test]
        public void ChangeDirection_ShouldDoNotThrow_WhenPassedValueIsValid()
        {
            int directionX = -1;
            int directionY = 0;

            Assert.DoesNotThrow(() => MovesInMatrix.ChangeDirection(ref directionX, ref directionY));
        }

        [Test]
        public void ChangeDirection_ShouldIncreaseFirstArgument_WhenPassedValueIsValid()
        {
            int directionX = 0;
            int directionY = 0;
            //// Second value is "1" dirX = { 1, 1, 1, 0, -1, -1, -1, 0 }
            int result = 1;

            MovesInMatrix.ChangeDirection(ref directionX, ref directionY);

            Assert.AreEqual(result, directionX);
        }

        [Test]
        public void ChangeDirection_ShouldIncreaseSecondArgument_WhenPassedValueIsValid()
        {
            int directionX = 0;
            int directionY = 0;
            //// Second value is "0" dirY = { 1, 0, -1, -1, -1, 0, 1, 1 }
            int result = 0;

            MovesInMatrix.ChangeDirection(ref directionX, ref directionY);

            Assert.AreEqual(result, directionY);
        }
    }
}