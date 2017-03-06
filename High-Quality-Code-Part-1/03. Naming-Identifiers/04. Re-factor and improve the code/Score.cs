using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minesweeper
{
    public class Scores
    {
        string name;
        int score;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public Scores() { }

        public Scores(string name, int scores)
        {
            this.name = name;
            this.score = scores;
        }
    }
}
