using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.LargestConnetedArea
{
    internal static class StartUp
    {
        private static int currentCount = 0;
        private static int maxCount = 0;
        private static char[,] matrix;

        static void Main()
        {
            matrix = new char[,]
            {
                { ' ', ' ', ' ', '*', ' ', ' ', ' '},
                { '*', '*', ' ', '*', ' ', '*', ' '},
                { ' ', ' ', ' ', '*', ' ', ' ', ' '},
                { '*', '*', '*', '*', '*', '*', ' '},
                { ' ', ' ', ' ', ' ', '*', '*', ' '},
                { ' ', ' ', ' ', ' ', ' ', ' ', ' '}
            };

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == '*')
                    {
                        continue;
                    }

                    currentCount = 0;
                    FindPath(row, col);
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                    }
                }
            }

            Console.WriteLine(maxCount);
        }

        private static void FindPath(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == '*' || matrix[row, col] == '0')
            {
                return;
            }

            matrix[row, col] = '0';
            currentCount++;
            FindPath(row + 1, col);
            FindPath(row - 1, col);
            FindPath(row, col + 1);
            FindPath(row, col - 1);
        }
    }
}
