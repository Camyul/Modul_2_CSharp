using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Size_in_CSharp
{
    public class Size
    {
        public double width;
        public double height;
      
        public Size(double width, double height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException("Width cannot be negative or zero");
            }
            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException("Hidht cannot be negative or zero");
            }

            this.width = width;
            this.height = height;
        }

        public static Size GetRotatedSize(Size triangle, double angleOfTriangle)
        {
            double newWidth = Math.Abs(Math.Cos(angleOfTriangle)) * triangle.width +
                    Math.Abs(Math.Sin(angleOfTriangle)) * triangle.height;
            double newHeight = Math.Abs(Math.Sin(angleOfTriangle)) * triangle.width +
                    Math.Abs(Math.Cos(angleOfTriangle)) * triangle.height;

            Size rotatedTriangle = new Size(newWidth, newHeight);

            return rotatedTriangle;
                
        }
    }
}
