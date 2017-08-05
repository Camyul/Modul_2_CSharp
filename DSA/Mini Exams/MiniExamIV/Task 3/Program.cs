using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static decimal Line(decimal ax, decimal bx, decimal ay, decimal by)
        {
            decimal dx = ax - bx;
            decimal dy = ay - by;

            return (decimal)Math.Sqrt((double)dx * (double)dx + (double)dy * (double)dy);
        }
        static void Main(string[] args)
        {
            decimal[] numbersA = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
            decimal ax = numbersA[0];
            decimal ay = numbersA[1];
            decimal[] numbersB = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
            decimal bx = numbersB[0];
            decimal by = numbersB[1];
            decimal[] numbersC = Console.ReadLine().Split(' ').Select(decimal.Parse).ToArray();
            decimal cx = numbersC[0];
            decimal cy = numbersC[1];

            decimal faceTr = Math.Abs((ax * (by - cy) + bx * (cy - ay) + cx * (ay - by)) / 2);

            decimal ab = Line(ax, bx, ay, by);
            decimal bc = Line(bx, cx, by, cy);
            decimal ca = Line(cx, ax, cy, ay);
            decimal doubleFace = 2 * faceTr;

            decimal ha = (doubleFace / ab);
            decimal hb = (doubleFace / bc);
            decimal hc = (doubleFace / ca);

            Console.WriteLine("{0:F2}", hb);
            Console.WriteLine("{0:F2}", hc);
            Console.WriteLine("{0:F2}", ha);
        }
    }
}
