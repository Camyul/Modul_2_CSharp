using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.All_paths_between_two_cells
{
    class StartUp
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

            var labyrinth = new Labyrinth(matrix);
            var startCell = new Cell(2, 1, 0);

            labyrinth.FindPaths(startCell);
            labyrinth.MarkUnreachableCells(startCell);

            Console.WriteLine("All Paths");
            labyrinth.PrintMatrix();
        }


    }
}
