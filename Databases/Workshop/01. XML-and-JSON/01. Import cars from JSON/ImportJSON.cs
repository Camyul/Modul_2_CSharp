using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WorkshopXMLToJSON
{
    class ImportJSON
    {
        static void Main()
        {
            var json = File.ReadAllText("../../data.number.json");

            var carsModelList = JsonConvert.DeserializeObject<List<CarJsonModel>>(json);


            IList<Car> cars = new List<Car>();

            foreach (var carJson in carsModelList)
            {
                
                 cars.Add(CarJsonModel.FromJsonModel(carJson));
            }
            cars.ToArray();

            Console.WriteLine(string.Join("\n", cars));
        }
    }
}
