using System;

namespace Matrix
{
    public class WalkInMatrica
    {
        internal static void Main()
        {
            Console.Write("Enter a size of Matrix(between 0 and 100): ");
            int size = int.Parse(Console.ReadLine());

            if (size <= 0 || size > 99)
            {
                throw new ArgumentOutOfRangeException("Size of Matrix must be between 0 and 100");
            }

            int[,] matrica = new int[size, size];
            int step = size;
            int numberInCell = 1;
            int row = 0;
            int col = 0;
            int dx = 1;
            int dy = 1;

            ////break works 100% 
            while (true)
            {
                matrica[row, col] = numberInCell;

                if (!MovesInMatrix.IsVisited(matrica, row, col))
                {
                    ////if no moves, in any directions
                    break;
                }

                while (row + dx >= size || row + dx < 0 || col + dy >= size || col + dy < 0 || matrica[row + dx, col + dy] != 0)
                {
                    MovesInMatrix.ChangeDirection(ref dx, ref dy);
                }

                row += dx;
                col += dy;
                numberInCell++;
            }

            int[] emptyCell = MovesInMatrix.FindEmptyCell(matrica);
            row = emptyCell[0];
            col = emptyCell[1];

            if (row != 0 && col != 0)
            { 
                dx = 1;
                dy = 1;

                while (true)
                { 
                    matrica[row, col] = numberInCell + 1;

                    if (!MovesInMatrix.IsVisited(matrica, row, col))
                    {
                        break;
                    }

                    while (row + dx >= size || row + dx < 0 || col + dy >= size || col + dy < 0 || matrica[row + dx, col + dy] != 0)
                    {
                        MovesInMatrix.ChangeDirection(ref dx, ref dy);
                    }

                    row += dx;
                    col += dy;
                    numberInCell++;
                }
            }

            MovesInMatrix.PrintMatrix(size, matrica);
        }
    }
}
