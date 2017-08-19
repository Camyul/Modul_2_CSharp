using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public class Point
        {
            public Point(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            public double X { get; set; }
            public double Y { get; set; }

            public double DistanceTo(Point other)
            {
                var dx = this.X - other.X;
                var dy = this.Y - other.Y;

                return Math.Sqrt(dx * dx + dy * dy);
            }
        }
        static void Main()
        {
            Point[] lines = new Point[6];
            for (int i = 0; i < 6; i += 2)
            {
                var line = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
                lines[i] = new Point(line[0], line[1]);
                lines[i + 1] = new Point(line[2], line[3]);
            }

            var pointA = LineIntersectionPoint(lines[0], lines[1], lines[2], lines[3]);
            var pointB = LineIntersectionPoint(lines[2], lines[3], lines[4], lines[5]);
            var pointC = LineIntersectionPoint(lines[0], lines[1], lines[4], lines[5]);


            var face = AreaOfTriangle(pointA, pointB, pointC);
            //var face = ((pointA.X * (pointB.Y - pointC.Y)) + (pointB.X * (pointC.Y - pointA.Y)) + (pointC.X * (pointA.Y - pointA.Y))) / 2;

            Console.WriteLine("{0:F3}", face);
        }
        public static double AreaOfTriangle(Point pt1, Point pt2, Point pt3)
        {
            double a = pt1.DistanceTo(pt2);
            double b = pt2.DistanceTo(pt3);
            double c = pt3.DistanceTo(pt1);
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        private static Point LineIntersectionPoint(Point ps1, Point pe1, Point ps2,
   Point pe2)
        {
            // Get A,B,C of first line - points : ps1 to pe1
            double A1 = pe1.Y - ps1.Y;
            double B1 = ps1.X - pe1.X;
            double C1 = A1 * ps1.X + B1 * ps1.Y;

            // Get A,B,C of second line - points : ps2 to pe2
            double A2 = pe2.Y - ps2.Y;
            double B2 = ps2.X - pe2.X;
            double C2 = A2 * ps2.X + B2 * ps2.Y;

            // Get delta and check if the lines are parallel
            double delta = A1 * B2 - A2 * B1;

            // now return the Vector2 intersection point
            return new Point(
                (B2 * C1 - B1 * C2) / delta,
                (A1 * C2 - A2 * C1) / delta
            );
        }
    }
}
