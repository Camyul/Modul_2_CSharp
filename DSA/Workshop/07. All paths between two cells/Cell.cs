using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.All_paths_between_two_cells
{
    public class Cell
    {
        public Cell(int row, int coll, int distance)
        {
            this.Row = row;
            this.Coll = coll;
            this.Distance = distance;
        }

        public int Row { get; set; }
        public int Coll { get; set; }
        public int Distance { get; set; }
    }
}
