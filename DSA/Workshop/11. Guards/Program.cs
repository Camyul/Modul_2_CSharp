using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Guards
{
    
   
    

    class Program
    {
        

        static void Main()
        {
            int[] rc = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = rc[0];
            int cols = rc[1];
            int[,] field = new int[rows, cols];
            
            int numberSecurity = int.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    field[i, j] = 1;
                }
            }

            for (int i = 0; i < numberSecurity; i++)
            {
                string[] position = Console.ReadLine().Split(' ').ToArray();
                int r = int.Parse(position[0]);
                int c = int.Parse(position[1]);
                string watch = position[2];

                field[r, c] = -1;

                if (watch == "L")
                {
                    if (c - 1 >= 0)
                    {
                        field[r, c - 1] = 3;
                    }
                }
                else if (watch == "R")
                {
                    if (c + 1 < cols)
                    {
                        field[r, c + 1] = 3;
                    }
                }
                else if (watch == "U")
                {
                    if (r - 1 >= 0)
                    {
                        field[r - 1, c] = 3;
                    }
                }
                else if (watch == "D")
                {
                    if (r + 1 < rows)
                    {
                        field[r + 1, c] = 3;
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (field[i, j] == -1)
                    {
                        continue;
                    }

                    int up = 0;
                    int left = 0;
                    if (i > 0 && j > 0)
                    {
                        if (field[i, j - 1] != -1 && field[i - 1, j] != -1)
                        {
                            left = field[i, j - 1];
                            up = field[i - 1, j];
                            field[i, j] += Math.Min(up, left);
                            PrintMatrix(field);
                            continue;
                        }

                        if (field[i - 1, j] == -1)
                        {
                            field[i, j] += field[i, j - 1];
                        }
                        else
                        {
                            field[i, j] += field[i - 1, j];
                        }
                    }
                    else if (j > 0)
                    {
                        if (field[i, j - 1] != -1)
                        {
                            field[i, j] += field[i, j - 1];
                        }
                        else
                        {
                            field[i, j] += 1;
                        }
                    }
                    else if (i > 0)
                    {
                        if (field[i - 1, j] != -1)
                        {
                            field[i, j] += field[i - 1, j];
                        }
                        else
                        {
                            field[i, j] += 1;
                        }
                    }
                    PrintMatrix(field);
                }
            }

            PrintMatrix(field);

            if (field[rows - 1, cols - 1] == 1)
            {
                Console.WriteLine("Meow");
            }
            else
            {
                Console.WriteLine(field[rows - 1, cols - 1]);
            }
        }

        public static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

    }
}
