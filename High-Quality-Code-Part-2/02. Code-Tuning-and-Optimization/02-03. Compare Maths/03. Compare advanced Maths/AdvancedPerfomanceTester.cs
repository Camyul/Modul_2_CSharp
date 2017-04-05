using System;
using System.Diagnostics;
using Compare_simple_Maths;

namespace Compare_advanced_Maths
{
    public static class AdvancedPerfomanceTester
    {
        private const int INTEGER = 1;
        private const long LONG = 1L;
        private const float FLOAT = 1.0F;
        private const double DOUBLE = 1.0;
        private const decimal DECIMAL = 1.0M;
        private const int COUNT = 50000000;
        private const int OPERAND = 2;

        public static void AdvancedTimeMeasurer(DataType dataType, Operation operation)
        {
            dynamic result;

            switch (dataType)
            {
                case DataType.Int:
                    result = INTEGER;
                    break;
                case DataType.Long:
                    result = LONG;
                    break;
                case DataType.Float:
                    result = FLOAT;
                    break;
                case DataType.Double:
                    result = DOUBLE;
                    break;
                case DataType.Decimal:
                    result = DECIMAL;
                    break;
                default:
                    throw new ArgumentException("Invalid data type");
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < COUNT; i++)
            {
                switch (operation)
                {
                    case Operation.SquareRoot: result = Math.Sqrt(OPERAND);
                        break;
                    case Operation.Sinus: result = Math.Sin(OPERAND);
                        break;
                    case Operation.NaturalLogarithm: result = Math.Log(OPERAND);
                        break;
                    default:
                        throw new ArgumentException("Invalid operation");
                }
            }

            var elapsedTime = sw.Elapsed;
            sw.Stop();

            Console.WriteLine("Datatype: {0,-8} - Opearation: {1, -17} Time: {2}", dataType, operation, elapsedTime);
        }
    }
}
