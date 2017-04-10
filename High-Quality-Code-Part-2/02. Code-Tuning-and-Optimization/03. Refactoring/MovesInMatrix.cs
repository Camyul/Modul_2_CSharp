using System;

namespace Matrix
{
    public class MovesInMatrix
    {
        public static void ChangeDirection(ref int dx, ref int dy)
        {
            if (dx < -1 || dx > 1)
            {
                throw new ArgumentOutOfRangeException("dx must be between (-1, 1)");
            }

            if (dy < -1 || dy > 1)
            {
                throw new ArgumentOutOfRangeException("dy must be between (-1, 1)");
            }

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

        public static bool IsVisited(int[,] arr, int x, int y)
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

        public static int[] FindEmptyCell(int[,] arr)
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

        public static void PrintMatrix(int size, int[,] matrica)
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
