using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Jedi_Meditation
{
    public static class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[] separ = { " " };
            IList<string> jadis = Console.ReadLine().Split(separ, StringSplitOptions.None).ToList();

            IList<string> jadiMasters = jadis.GetByRole('M');
            IList<string> jadiKnights = jadis.GetByRole('K');
            IList<string> jadiPaduans = jadis.GetByRole('P');
            jadis.Clear();

            foreach (var item in jadiMasters)
            {
                jadis.Add(item);
            }

            foreach (var item in jadiKnights)
            {
                jadis.Add(item);
            }

            foreach (var item in jadiPaduans)
            {
                jadis.Add(item);
            }

            Console.WriteLine(String.Join(" ", jadis));
        }
       
        public static IList<string> GetByRole(this IList<string> listToSort, char name)
        {
            var jediByRole = new List<string>();

            foreach (var jedi in listToSort)
            {
                if (jedi[0] == name)
                {
                    jediByRole.Add(jedi);
                }
            }

            return jediByRole;
        }

        
    }

}
