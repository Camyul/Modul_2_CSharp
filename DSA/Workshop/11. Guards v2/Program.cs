using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Guards_v2
{
    public class Cell
    {
        public Cell(int row, int coll, int distance)
        {
            this.Row = row;
            this.Col = coll;
            this.Distance = distance;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Distance { get; set; }
    }


    class Program
    {
        static void Main()
        {
            int[] rc = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int rows = rc[0];
            int cols = rc[1];
            
            string[,] matrix = new string[rows, cols];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = "0";
                }
            }

            int numberSecurity = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberSecurity; i++)
            {
                string[] guard = Console.ReadLine().Split(' ').ToArray();
                int r = int.Parse(guard[0]);
                int c = int.Parse(guard[1]);

                matrix[r, c] = "X";

                if (guard[2] == "L" && c - 1 >= 0)
                {
                    matrix[r, c - 1] = "3";
                }
                else if (guard[2] == "R" && c + 1 < cols - 1)
                {
                    matrix[r, c + 1] = "3";
                }
                else if (guard[2] == "U" && r - 1 >= 0)
                {
                    matrix[r - 1, c] = "3";
                }
                else if (guard[2] == "D" && r + 1 < rows - 1)
                {
                    matrix[r + 1, c] = "3";
                }

            }

            var labyrinth = new Labyrinth(matrix);
            var startCell = new Cell(0, 0, 1);

            labyrinth.FindPaths(startCell);
            // labyrinth.MarkUnreachableCells(startCell);

            //Console.WriteLine("All Paths");
            //labyrinth.PrintMatrix();

            if (matrix[rows - 1, cols - 1] == "0")
            {
                Console.WriteLine("Meow");
            }
            else
            {
                Console.WriteLine(matrix[rows - 1, cols - 1]);
            }
            
        }
    }

    public class Labyrinth
    {
        public Labyrinth(string[,] matrix)
        {
            this.Matrix = matrix;
            this.Queue = new Queue<Cell>();
        }

        public string[,] Matrix { get; set; }
        public Queue<Cell> Queue { get; set; }

        public void FindPaths(Cell startCell)
        {
            this.Queue.Enqueue(startCell);

            while (this.Queue.Count > 0)
            {
                Cell currentCell = this.Queue.Dequeue();
                int row = currentCell.Row;
                int col = currentCell.Col;
                int dist = currentCell.Distance;

                this.Matrix[row, col] = dist.ToString();

                Cell nextCell = new Cell(row + 1, col, dist + 1);
                if (IsValid(nextCell) && this.Matrix[row + 1, col] == "3")
                {
                    nextCell.Distance = dist + 3;
                }
                if (IsValid(nextCell))
                {
                    this.Queue.Enqueue(nextCell);
                }
                nextCell = new Cell(row, col + 1, dist + 1);
                if (IsValid(nextCell) && this.Matrix[row, col + 1] == "3")
                {
                    nextCell.Distance = dist + 3;
                }
                if (IsValid(nextCell))
                {
                    this.Queue.Enqueue(nextCell);
                }

            }
        }


        public void PrintMatrix()
        {
            for (int row = 0; row < this.Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.Matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", this.Matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        public void MarkUnreachableCells(Cell startCell)
        {
            for (int row = 0; row < Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < Matrix.GetLength(1); col++)
                {
                    if (this.Matrix[row, col] == "0")
                    {
                        this.Matrix[row, col] = "u";
                    }
                }
            }

            this.Matrix[startCell.Row, startCell.Col] = "*";
        }

        private bool IsValid(Cell nextCell)
        {
            return nextCell.Row < this.Matrix.GetLength(0) &&
                   nextCell.Row >= 0 &&
                   nextCell.Col < this.Matrix.GetLength(1) &&
                   nextCell.Col >= 0 &&
                   (this.Matrix[nextCell.Row, nextCell.Col] == "0" || this.Matrix[nextCell.Row, nextCell.Col] == "3");
        }
    }
}
