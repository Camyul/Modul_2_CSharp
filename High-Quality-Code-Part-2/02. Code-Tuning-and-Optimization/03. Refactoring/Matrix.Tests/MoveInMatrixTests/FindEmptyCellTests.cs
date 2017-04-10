using NUnit.Framework;

namespace Matrix.Tests.MoveInMatrixTests
{
    [TestFixture]
    internal class FindEmptyCellTests
    {
        [Test]
        public void FindEmptyCell_ShouldReturnEmptyCell_WhenEmptyCellExist()
        {
            int[,] matrixMock = new int[5, 5];
            for (int i = 0; i < matrixMock.GetLength(0); i++)
            {
                for (int j = 0; j < matrixMock.GetLength(1); j++)
                {
                    matrixMock[i, j] = 11;
                }
            }

            matrixMock[3, 3] = 0;

            Assert.AreNotSame(matrixMock[3, 3], MovesInMatrix.FindEmptyCell(matrixMock));
        }

        [Test]
        public void FindEmptyCell_ShouldReturnEmptyArray_WhenEmptyCellDontExist()
        {
            int[,] matrixMock = new int[5, 5];
            for (int i = 0; i < matrixMock.GetLength(0); i++)
            {
                for (int j = 0; j < matrixMock.GetLength(1); j++)
                {
                    matrixMock[i, j] = 11;
                }
            }

            int[] emptyArray = new int[2];

            Assert.AreEqual(emptyArray, MovesInMatrix.FindEmptyCell(matrixMock));
        }

    }
}
