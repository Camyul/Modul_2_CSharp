using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare_simple_Maths
{
    public static class PerfomanceTester
    {
        private const int INTEGER = 1;
        private const long LONG = 1L;
        private const float FLOAT = 1.0F;
        private const double DOUBLE = 1.0;
        private const decimal DECIMAL = 1.0M;
        private const int COUNT = 10000000;
        private const int OPERAND = 1;

        public static void TimeMeasurer(DataType dataType, Operation operation)
        {
            dynamic result;

            switch (dataType)
            {
                case DataType.Int: result = INTEGER;
                    break;
                case DataType.Long: result = LONG;
                    break;
                case DataType.Float: result = FLOAT;
                    break;
                case DataType.Double: result = DOUBLE;
                    break;
                case DataType.Decimal: result = DECIMAL;
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
                    case Operation.Add: result += OPERAND;
                        break;
                    case Operation.Subtract: result -= OPERAND;
                        break;
                    case Operation.Increment: result++;
                        break;
                    case Operation.Multiply: result *= OPERAND;
                        break;
                    case Operation.Divide: result /= OPERAND;
                        break;
                    default:
                        throw new ArgumentException("Invalid operation");
                }
            }

            var elapsedTime = sw.Elapsed;
            sw.Stop();

            Console.WriteLine("Datatype: {0,-8} - Opearation: {1, -10} Time: {2}", dataType, operation, elapsedTime);

        }

    }
}
