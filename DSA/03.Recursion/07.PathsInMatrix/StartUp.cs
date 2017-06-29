using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PathsInMatrix
{
    internal static class StartUp
    {
        static void Main()
        {
            string[,] matrix =
           {
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "e", "0" }
            };

            var lab = new Labyrinth(matrix);
            Cell startCell = new Cell(2, 1, 0);
            lab.FindPathsQ(startCell);
            lab.MarkUnreachableCells(startCell);
            Console.WriteLine("All Paths");
            lab.PrintMatrix();
        }
    }
}
