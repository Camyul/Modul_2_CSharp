using System;
using Compare_simple_Maths;

namespace Compare_advanced_Maths
{
    internal class StartUp
    {
       internal static void Main()
        {
            AdvancedPerfomanceTester.AdvancedTimeMeasurer(DataType.Int, Operation.SquareRoot);
            AdvancedPerfomanceTester.AdvancedTimeMeasurer(DataType.Long, Operation.SquareRoot);
            AdvancedPerfomanceTester.AdvancedTimeMeasurer(DataType.Float, Operation.SquareRoot);
            AdvancedPerfomanceTester.AdvancedTimeMeasurer(DataType.Double, Operation.SquareRoot);
            AdvancedPerfomanceTester.AdvancedTimeMeasurer(DataType.Decimal, Operation.SquareRoot);

            Console.WriteLine(new string('-', 77));

            AdvancedPerfomanceTester.AdvancedTimeMeasurer(DataType.Int, Operation.Sinus);
            AdvancedPerfomanceTester.AdvancedTimeMeasurer(DataType.Long, Operation.Sinus);
            AdvancedPerfomanceTester.AdvancedTimeMeasurer(DataType.Float, Operation.Sinus);
            AdvancedPerfomanceTester.AdvancedTimeMeasurer(DataType.Double, Operation.Sinus);
            AdvancedPerfomanceTester.AdvancedTimeMeasurer(DataType.Decimal, Operation.Sinus);

            Console.WriteLine(new string('-', 77));

            AdvancedPerfomanceTester.AdvancedTimeMeasurer(DataType.Int, Operation.NaturalLogarithm);
            AdvancedPerfomanceTester.AdvancedTimeMeasurer(DataType.Long, Operation.NaturalLogarithm);
            AdvancedPerfomanceTester.AdvancedTimeMeasurer(DataType.Float, Operation.NaturalLogarithm);
            AdvancedPerfomanceTester.AdvancedTimeMeasurer(DataType.Double, Operation.NaturalLogarithm);
            AdvancedPerfomanceTester.AdvancedTimeMeasurer(DataType.Decimal, Operation.NaturalLogarithm);

            Console.WriteLine(new string('-', 77));
        }
    }
}
