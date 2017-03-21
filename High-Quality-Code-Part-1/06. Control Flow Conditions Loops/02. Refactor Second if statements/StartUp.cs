using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactor_Second_if_statements
{
    public class StartUp
    {
        public static void Main()
        {
            int maxCoord_Y = 220;
            int minCoord_Y = 180;

            int maxCoord_X = 220;
            int minCoord_X = 180;

            bool[,] shouldVisitCell = new bool[maxCoord_X, maxCoord_Y];

            ResetVisitedSell(minCoord_X, maxCoord_X, minCoord_Y, maxCoord_Y, shouldVisitCell);

            Coord coord = new Coord();

            for (coord.X = minCoord_X; coord.X < maxCoord_X; coord.X++)
            {
                for (coord.Y = minCoord_Y; coord.Y < maxCoord_Y; coord.Y++)
                {
                    if (shouldVisitCell[coord.X, coord.Y])
                    {
                        if ((minCoord_X < coord.X && coord.X <= maxCoord_X) && (minCoord_Y <= coord.Y && coord.Y < maxCoord_Y))
                        {
                            VisitCell(coord.X, coord.Y, shouldVisitCell);
                        }
                    }
                }
            }
        }

        private static void ResetVisitedSell(int minCoord_X, int maxCoord_X, int minCoord_Y, int maxCoord_Y, bool[,] shouldVisitCell)
        {
            for (int i = minCoord_X; i < maxCoord_X; i++)
            {
                for (int j = minCoord_Y; j < maxCoord_Y; j++)
                {
                    shouldVisitCell[i, j] = false;
                }
            }
        }

        private static void VisitCell(int coordX, int coordY, bool[,] shouldVisitCell)
        {
            shouldVisitCell[coordX, coordY] = true;
        }
    }
}