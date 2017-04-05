using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compare_simple_Maths
{
    internal class StartUp
    {
        internal static void Main()
        {
            PerfomanceTester.TimeMeasurer(DataType.Int, Operation.Add);
            PerfomanceTester.TimeMeasurer(DataType.Long, Operation.Add);
            PerfomanceTester.TimeMeasurer(DataType.Float, Operation.Add);
            PerfomanceTester.TimeMeasurer(DataType.Double, Operation.Add);
            PerfomanceTester.TimeMeasurer(DataType.Decimal, Operation.Add);

            Console.WriteLine(new string('-', 77));

            PerfomanceTester.TimeMeasurer(DataType.Int, Operation.Subtract);
            PerfomanceTester.TimeMeasurer(DataType.Long, Operation.Subtract);
            PerfomanceTester.TimeMeasurer(DataType.Float, Operation.Subtract);
            PerfomanceTester.TimeMeasurer(DataType.Double, Operation.Subtract);
            PerfomanceTester.TimeMeasurer(DataType.Decimal, Operation.Subtract);

            Console.WriteLine(new string('-', 77));

            PerfomanceTester.TimeMeasurer(DataType.Int, Operation.Increment);
            PerfomanceTester.TimeMeasurer(DataType.Long, Operation.Increment);
            PerfomanceTester.TimeMeasurer(DataType.Float, Operation.Increment);
            PerfomanceTester.TimeMeasurer(DataType.Double, Operation.Increment);
            PerfomanceTester.TimeMeasurer(DataType.Decimal, Operation.Increment);

            Console.WriteLine(new string('-', 77));

            PerfomanceTester.TimeMeasurer(DataType.Int, Operation.Multiply);
            PerfomanceTester.TimeMeasurer(DataType.Long, Operation.Multiply);
            PerfomanceTester.TimeMeasurer(DataType.Float, Operation.Multiply);
            PerfomanceTester.TimeMeasurer(DataType.Double, Operation.Multiply);
            PerfomanceTester.TimeMeasurer(DataType.Decimal, Operation.Multiply);

            Console.WriteLine(new string('-', 77));

            PerfomanceTester.TimeMeasurer(DataType.Int, Operation.Divide);
            PerfomanceTester.TimeMeasurer(DataType.Long, Operation.Divide);
            PerfomanceTester.TimeMeasurer(DataType.Float, Operation.Divide);
            PerfomanceTester.TimeMeasurer(DataType.Double, Operation.Divide);
            PerfomanceTester.TimeMeasurer(DataType.Decimal, Operation.Divide);

            Console.WriteLine(new string('-', 77));
        }
    }
}
