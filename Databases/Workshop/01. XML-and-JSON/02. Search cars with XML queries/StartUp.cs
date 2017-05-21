using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkshopXMLToJSON;
using WorkshopXMLToJSON.Contract;

namespace SearchCarsWithXMLQueries
{
    public class StartUp
    {
        static void Main()
        {
            ICarService carService;

            ////Read cars form cars.xml
            carService = new StaxXmlCarsService("../../../cars.xml");

            var cars = carService.GetAll().ToList();

            Console.WriteLine();
        }
    }
}
