using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Jedi_Meditation
{
    internal class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[] separ = { " " };
            //int[] jadis = Console.ReadLine().Split(separ, StringSplitOptions.None).Select(int.Parse).ToArray();
            IList<string> jadis = Console.ReadLine().Split(separ, StringSplitOptions.None).ToList();

            var sw = new Stopwatch();
            sw.Start();

            IList<string> jadiMasters = jadis.GetByRole('m');
            IList<string> jadiKnights = jadis.GetByRole('k');
            IList<string> jadiPaduans = jadis.GetByRole('p');

            Console.WriteLine(String.Join(" ", jadiMasters));
            Console.WriteLine(String.Join(" ", jadiKnights));
            Console.WriteLine(String.Join(" ", jadiPaduans));

            IList<int> jadiMastersNumbers = jadiMasters.Select(int.Parse).ToList();
            IList<int> jadiKnightsNumbers = jadiKnights.Select(int.Parse).ToList();
            IList<int> jadiPaduansNumbers = jadiPaduans.Select(int.Parse).ToList();

            jadiMastersNumbers.RadixLeftToRight(5, 10);
            jadiKnightsNumbers.RadixLeftToRight(5, 10);
            jadiPaduansNumbers.RadixLeftToRight(5, 10);

            jadiMasters.Clear();
            jadiKnights.Clear();
            jadiPaduans.Clear();
            jadis.Clear();

            jadiMasters = jadiMastersNumbers.ConvertToString('m');
            jadiKnights = jadiKnightsNumbers.ConvertToString('k');
            jadiPaduans = jadiPaduansNumbers.ConvertToString('p');

            jadiMasters.ToList().ForEach(x => jadis.Add(x));
            jadiKnights.ToList().ForEach(x => jadis.Add(x));
            jadiPaduans.ToList().ForEach(x => jadis.Add(x));

            sw.Stop();

            Console.WriteLine(String.Join(" ", jadis));
            Console.WriteLine(sw.Elapsed);

        }
    }
}
