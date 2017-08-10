using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._3D_Labyrinth
{
    class Program
    {
        static void Main()
        {
            int[] startPosition = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var startCell = new Cell<int>(startPosition[0], startPosition[1],startPosition[2], 0);

            int[] dimensionParts = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int l = dimensionParts[0];
            int r = dimensionParts[1];
            int c = dimensionParts[2];

            HashSet<Cell<int>> visited = new HashSet<Cell<int>>();
            Queue<Cell<int>> queue = new Queue<Cell<int>>();

            // Create 3 dimensions char array and fill them
            char[,,] labyrint = new char[l, r, c];
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    string line = Console.ReadLine();
                    for (int k = 0; k < c; k++)
                    {
                        labyrint[i, j, k] = line[k];
                        if (labyrint[i, j, k] == '#')
                        {
                            visited.Add(new Cell<int>(i, j, k, -1));
                        }
                    }
                }
            }

            // Start BFS
            queue.Enqueue(startCell);
            visited.Add(startCell);

            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();

                // Console.WriteLine($"l: {currentCell.Level} r: {currentCell.Row} c: {currentCell.Col} count: {currentCell.stepCount} sym: {labyrint[currentCell.Level, currentCell.Row, currentCell.Col]}");
                
                // Left
                if (currentCell.Col > 0)
                {
                    var newCell = new Cell<int>(currentCell.Level, currentCell.Row, currentCell.Col - 1, currentCell.stepCount + 1);

                    if (!visited.Contains(newCell))
                    {
                        visited.Add(newCell);
                        queue.Enqueue(newCell);
                    }
                }
                // Right
                if (currentCell.Col < c - 1)
                {
                    var newCell = new Cell<int>(currentCell.Level, currentCell.Row, currentCell.Col + 1, currentCell.stepCount + 1);

                    if (!visited.Contains(newCell))
                    {
                        visited.Add(newCell);
                        queue.Enqueue(newCell);
                    }
                }
                // Forward
                if (currentCell.Row > 0)
                {
                    var newCell = new Cell<int>(currentCell.Level, currentCell.Row - 1, currentCell.Col, currentCell.stepCount + 1);

                    if (!visited.Contains(newCell))
                    {
                        visited.Add(newCell);
                        queue.Enqueue(newCell);
                    }
                }
                // Backward
                if (currentCell.Row < r - 1)
                {
                    var newCell = new Cell<int>(currentCell.Level, currentCell.Row + 1, currentCell.Col, currentCell.stepCount + 1);

                    if (!visited.Contains(newCell))
                    {
                        visited.Add(newCell);
                        queue.Enqueue(newCell);
                    }
                }
                // Up
                if (labyrint[currentCell.Level, currentCell.Row, currentCell.Col] == 'U')
                {
                    if (currentCell.Level == l - 1)
                    {
                        Console.WriteLine(currentCell.stepCount + 1);
                        return;
                    }
                    var newCell = new Cell<int>(currentCell.Level + 1, currentCell.Row, currentCell.Col, currentCell.stepCount + 1);

                    if (!visited.Contains(newCell))
                    {
                        visited.Add(newCell);
                        queue.Enqueue(newCell);
                    }
                }
                // Down
                if (labyrint[currentCell.Level, currentCell.Row, currentCell.Col] == 'D')
                {
                    if (currentCell.Level == 0)
                    {
                        Console.WriteLine(currentCell.stepCount + 1);
                        return;
                    }
                    var newCell = new Cell<int>(currentCell.Level - 1, currentCell.Row, currentCell.Col, currentCell.stepCount + 1);

                    if (!visited.Contains(newCell))
                    {
                        visited.Add(newCell);
                        queue.Enqueue(newCell);
                    }
                }
            }
        }
    }

    public class Cell<T>
    {
        public Cell(T level, T row, T col, int stepCount)
        {
            this.Level = level;
            this.Row = row;
            this.Col = col;
            this.stepCount = stepCount;
        }

        public T Level { get; set; }
        public T Row { get; set; }
        public T Col { get; set; }

        public int stepCount { get; set; }

        // Важно за да сравнява клетките в hashset-a, ако записвам посетените в булев масив е излишно
        public override bool Equals(object obj)
        {
            var otherCell = obj as Cell<T>;
            if (otherCell == null)
            {
                return false;
            }
            return this.Level.Equals(otherCell.Level)
                && this.Row.Equals(otherCell.Row)
                && this.Col.Equals(otherCell.Col);
        }

        public override int GetHashCode()
        {
            return this.Level.GetHashCode() ^
                    this.Row.GetHashCode() ^
                    this.Col.GetHashCode();
        }
    }
}
