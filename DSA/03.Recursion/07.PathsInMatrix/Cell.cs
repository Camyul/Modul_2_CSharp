namespace _07.PathsInMatrix
{
    public class Cell
    {
        public Cell(int row, int col, int distance)
        {
            this.Row = row;
            this.Col = col;
            this.Distance = distance;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Distance { get; set; }
    }
}
