using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Doge_Coin
{
    class Program
    {
        // static int count;

        static void Main()
        {
            int[] nm = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = nm[0];
            int m = nm[1];
            int[,] matrix = new int[n, m];
            int[,] result = new int[n, m];
            int count = 0;

            int k = int.Parse(Console.ReadLine());
            for (int i = 0; i < k; i++)
            {
                int[] coord = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                matrix[coord[0], coord[1]] = 1;
            }

            count += Move(matrix, result, count, 0, 1) + Move(matrix, result, count, 1, 0);

            Console.WriteLine(count);
        }

        private static int Move(int[,] matrix, int[,] result, int count, int row, int col)
        {
            if ((row == matrix.GetLength(0) - 1) && (col == matrix.GetLength(1) - 1))
            {
                result[row, col] = matrix[row, col];

                return result[row, col];
            }

            if (result[row, col] == 0)
            {
                if (col == matrix.GetLength(1) - 1)
                {
                    result[row, col] = Move(matrix, result, count, row + 1, col);
                }
                else if (row == matrix.GetLength(0) - 1)
                {
                    result[row, col] = Move(matrix, result, count, row, col + 1);
                }
                else
                {
                    result[row, col] = Move(matrix, result, count, row + 1, col) + Move(matrix, result, count, row, col + 1);
                }

                //result[row, col] = matrix[row, col];
                return result[row, col];
            }
            else
            {
                return result[row, col];
            }
        }
    }
}
