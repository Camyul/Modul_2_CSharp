using System;

namespace Task3
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
            int k = 1;
            int i = 0;
            int j = 0;
            int dx = 1;
            int dy = 1;

            ////break works 100% 
            while (true)
            {
                matrica[i, j] = k;

                if (!IsVisited(matrica, i, j))
                {
                    ////if no moves, in any directions
                    break;
                }

                while (i + dx >= size || i + dx < 0 || j + dy >= size || j + dy < 0 || matrica[i + dx, j + dy] != 0)
                {
                    ChangeDirection(ref dx, ref dy);
                }

                i += dx;
                j += dy;
                k++;
            }

            int[] emptyCell = FindEmptyCell(matrica);
            i = emptyCell[0];
            j = emptyCell[1];

            if (i != 0 && j != 0)
            { 
                dx = 1;
                dy = 1;

                while (true)
                { 
                    matrica[i, j] = k + 1;

                    if (!IsVisited(matrica, i, j))
                    {
                        break;
                    }

                    while (i + dx >= size || i + dx < 0 || j + dy >= size || j + dy < 0 || matrica[i + dx, j + dy] != 0)
                    {
                        ChangeDirection(ref dx, ref dy);
                    }

                    i += dx;
                    j += dy;
                    k++;
                }
            }

            PrintMatrix(size, matrica);
        }

        private static void ChangeDirection(ref int dx, ref int dy)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };
            int currentDirection = 0;

            for (int count = 0; count < 8; count++)
            {
                if (dirX[count] == dx && dirY[count] == dy)
                {
                    currentDirection = count;
                    break;
                }
            }

            if (currentDirection == 7)
            {
                dx = dirX[0];
                dy = dirY[0];
                return;
            }

            dx = dirX[currentDirection + 1];
            dy = dirY[currentDirection + 1];
        }

        private static bool IsVisited(int[,] arr, int x, int y)
        {
            int[] dirX = { 1, 1, 1, 0, -1, -1, -1, 0 };
            int[] dirY = { 1, 0, -1, -1, -1, 0, 1, 1 };

            for (int i = 0; i < 8; i++)
            {
                if (x + dirX[i] >= arr.GetLength(0) || x + dirX[i] < 0)
                {
                    dirX[i] = 0;
                }

                if (y + dirY[i] >= arr.GetLength(0) || y + dirY[i] < 0)
                {
                    dirY[i] = 0;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                if (arr[x + dirX[i], y + dirY[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static int[] FindEmptyCell(int[,] arr)
        {
            int[] emptyCell = new int[2];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        emptyCell[0] = i;
                        emptyCell[1] = j;
                    }
                }
            }

            return emptyCell;
        }

        private static void PrintMatrix(int size, int[,] matrica)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write("{0,3}", matrica[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
