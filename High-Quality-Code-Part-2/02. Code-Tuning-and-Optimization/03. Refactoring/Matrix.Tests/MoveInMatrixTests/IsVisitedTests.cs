using NUnit.Framework;

namespace Matrix.Tests.MoveInMatrixTests
{
    [TestFixture]
    internal class IsVisitedTests
    {
        [Test]
        public void IsVisited_ShouldBeReturnFalse_WhenCellIsNotVisited()
        {
            int[,] matrixMock = new int[5, 5];
            for (int i = 0; i < matrixMock.GetLength(0); i++)
            {
                for (int j = 0; j < matrixMock.GetLength(1); j++)
                {
                    matrixMock[i, j] = i + j + 1;
                }
            }

            Assert.IsFalse(MovesInMatrix.IsVisited(matrixMock, 1, 1));
        }
        [Test]
        public void IsVisited_ShouldBeReturnTrue_WhenCellIsVisited()
        {
            int[,] matrixMock = new int[5, 5];
            for (int i = 0; i < matrixMock.GetLength(0); i++)
            {
                for (int j = 0; j < matrixMock.GetLength(1); j++)
                {
                    matrixMock[i, j] = 0;
                }
            }

            Assert.IsTrue(MovesInMatrix.IsVisited(matrixMock, 1, 1));
        }

    }
}