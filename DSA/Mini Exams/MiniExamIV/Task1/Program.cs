using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Point
    {
        private const double Epsilon = 1e-12;

        public double X { get; set; }
        public double Y { get; set; }

        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public double DistanceToSquared(Point other)
        {
            var dx = this.X - other.X;
            var dy = this.Y - other.Y;
            return dx * dx + dy * dy;
        }

        public double DistanceTo(Point other)
        {
            return Math.Sqrt(this.DistanceToSquared(other));
        }
    }
    class Program
    {
        static void Main()
        {
            int[] steve = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] ellen = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var stevePoint = new Point(steve[0], steve[1]);
            var steveSpeedSands = steve[2];

            var ellenePoint = new Point(ellen[0], ellen[1]);
            var steveSpeedWotar = ellen[2];

            var distance = stevePoint.DistanceTo(ellenePoint);
            var tang = (double)(stevePoint.Y - ellenePoint.Y) / (double)(stevePoint.X - ellenePoint.X);
            var line1 = (double)(stevePoint.Y / tang);
            var line2 = distance - line1;

            var time = line1 / steveSpeedSands + line2 / steveSpeedWotar;
            Console.WriteLine("{0:F2}", time);
        }
    }
}
