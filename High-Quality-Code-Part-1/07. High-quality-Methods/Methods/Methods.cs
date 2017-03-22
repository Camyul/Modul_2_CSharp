using System;

namespace Methods
{
    public class Methods
    {
        internal static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToDigit(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsNumber(1.3, PrintAs.twoNumberPrecision);
            PrintAsNumber(0.75, PrintAs.percent);
            PrintAsNumber(2.30, PrintAs.totalDigits);
            
            Console.WriteLine(CalcDistance(3, 3, -1, 2.5));

            bool horizontal = Position(-1, 2.5),
                 vertical = Position(3, 3);
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student("Peter", "Ivanov");
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student("Stella", "Markova");
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }

        private static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive.");
            }

            double perimeter = (a + b + c) / 2;
            double area = Math.Sqrt(perimeter * (perimeter - a) * (perimeter - b) * (perimeter - c));
            return area;
        }

        private static string NumberToDigit(int number)
        {
            string numberToDigit = string.Empty;

            switch (number)
            {
                case 0:
                    numberToDigit = "zero";
                    break;
                case 1:
                    numberToDigit = "one";
                    break;
                case 2:
                    numberToDigit = "two";
                    break;
                case 3:
                    numberToDigit = "three";
                    break;
                case 4:
                    numberToDigit = "four";
                    break;
                case 5:
                    numberToDigit = "five";
                    break;
                case 6:
                    numberToDigit = "six";
                    break;
                case 7:
                    numberToDigit = "seven";
                    break;
                case 8:
                    numberToDigit = "eight";
                    break;
                case 9:
                    numberToDigit = "nine";
                    break;
                default:
                    numberToDigit = "Invalid number!";
                    break;
            }

            return numberToDigit;
        }

        private static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("Missing elements");
            }

            int maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        private static void PrintAsNumber(object number, PrintAs format)
        {
            if (format == PrintAs.twoNumberPrecision)
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == PrintAs.percent)
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == PrintAs.totalDigits)
            {
                Console.WriteLine("{0,8}", number);
            }
        }

        private static bool Position(double firstCoordinate, double secondCoordinate)
        {
            bool isEqual = false;
            if (firstCoordinate == secondCoordinate)
            {
                isEqual = true;
            }

            return isEqual;
        }

        private static double CalcDistance(double x1, double x2, double y1, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }
    }
}
