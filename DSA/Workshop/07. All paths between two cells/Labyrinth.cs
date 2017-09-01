using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.All_paths_between_two_cells
{
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
                int col = currentCell.Coll;
                int dist = currentCell.Distance;

                this.Matrix[row, col] = dist.ToString();

                Cell nextCell = new Cell(row + 1, col, dist + 1);
                if (IsValid(nextCell))
                {
                    this.Queue.Enqueue(nextCell);
                }
                nextCell = new Cell(row - 1, col, dist + 1);
                if (IsValid(nextCell))
                {
                    this.Queue.Enqueue(nextCell);
                }
                nextCell = new Cell(row, col + 1, dist + 1);
                if (IsValid(nextCell))
                {
                    this.Queue.Enqueue(nextCell);
                }
                nextCell = new Cell(row, col - 1, dist + 1);
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

            this.Matrix[startCell.Row, startCell.Coll] = "*";
        }

        private bool IsValid(Cell nextCell)
        {
            return nextCell.Row < this.Matrix.GetLength(0) &&
                   nextCell.Row >= 0 &&
                   nextCell.Coll < this.Matrix.GetLength(1) &&
                   nextCell.Coll >= 0 &&
                   this.Matrix[nextCell.Row, nextCell.Coll] == "0";
        }
    }
}
