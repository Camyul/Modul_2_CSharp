using System;
using System.Collections.Generic;

namespace _08.MatrixPassChecker
{
    internal class Labyrinth
    {
        private const char UNPASSABLE = '0';
        private bool pathFound = false;


        private char[,] matrix;
        private int[,] dir = new int[,] { { 1, 0 }, { 0, 1 }, { -1, 0 }, { 0, -1 } };
        List<char> directions = new List<char>();
        private char[] charDir = new[] { 'D', 'R', 'U', 'L' };

        public Labyrinth(char[,] matrix)
        {
            this.matrix = matrix;
        }

        public void FindPaths(int row, int col, char direction)
        {
            if (pathFound)
            {
                return;
            }

            if (!InRange(row, col))
            {
                return;
            }

            if (matrix[row, col] == '*')
            {
                return;
            }

            if (matrix[row, col] == 'e')
            {
                directions.Add(direction);
                PrintMatrix();
                PrintPath();
                pathFound = true;
                directions.RemoveAt(this.directions.Count - 1);
                return;
            }

            directions.Add(direction);
            MarkCurrent(row, col, direction);
            for (int i = 0; i < dir.GetLength(0); i++)
            {
                FindPaths(row + dir[i, 0], col + dir[i, 1], charDir[i]);
            }
            directions.RemoveAt(this.directions.Count - 1);
        }

        private void MarkCurrent(int row, int col, char direction)
        {
            this.matrix[row, col] = direction;
        }

        private void PrintPath()
        {
            Console.Write("Path: ");
            Console.WriteLine(string.Join(">", directions));
        }

        private void PrintMatrix()
        {
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", this.matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < matrix.GetLength(0);
            bool colInRange = col >= 0 && col < matrix.GetLength(1);
            return rowInRange && colInRange;
        }
    }
}