using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WorkshopXMLToJSON.Contract;

namespace WorkshopXMLToJSON
{
    public class StaxXmlCarsService : ICarService
    {
        private const string CarElementName = "car";

        private const string CarElementYear = "year";

        private const string TransmissionElementName = "transmission";

        private const string ManufacturerElementName = "manufacturer";

        private const string ModelElementName = "model";

        private const string PriceElementName = "price";

        private const string DealerElementName = "dealer";

        private const string NameDealerElementName = "name";

        private const string CityDealerElementName = "city";

        public StaxXmlCarsService(string xmlFileLocation)
        {
            this.XmlFileLocation = xmlFileLocation;
        }

        public string XmlFileLocation { get; set; }

        ////Read XML from file 
        public IEnumerable<Car> GetAll()
        {
            var reader = XmlReader.Create(this.XmlFileLocation);

            var cars = new List<Car>();

            using(reader)
            {
                var car = this.ReadNextCar(reader);
                while (car != null)
                {
                    //cars.Add(car);
                    car = this.ReadNextCar(reader);
                }
            }

            return cars;
        }

        private object ReadNextCar(XmlReader reader)
        {
            const int carPropertiesToRead = 6;
            var propertiesRead = 0;
            var isInCar = false;

            var year = -1;
            Transmission transmission;
            var manufacturer = "";
            var model = "";
            double price;
            Dealer dealer;

            return propertiesRead < carPropertiesToRead 
                ? null 
                : new Car(year, transmission, manufacturer, model, price, dealer)
        }


        ////Create cars.xml from array
        public void Save(IEnumerable<Car> cars)
        {
            var writer = XmlWriter.Create(this.XmlFileLocation);
            using (writer)
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("cars");

                foreach (var car in cars)
                {
                    this.SaveCarTo(car, writer);
                }

                writer.WriteEndDocument();
            }
        }

        private void SaveCarTo(Car car, XmlWriter writer)
        {
            writer.WriteStartElement(CarElementName);

            writer.WriteElementString(CarElementYear, car.Year.ToString());
            writer.WriteElementString(TransmissionElementName, car.TransmissionType.ToString());
            writer.WriteElementString(ManufacturerElementName, car.Manufacturer.ToString());
            writer.WriteElementString(ModelElementName, car.Model.ToString());
            writer.WriteElementString(PriceElementName, car.Price.ToString());

            writer.WriteStartElement(DealerElementName);
            writer.WriteElementString(NameDealerElementName, car.Dealer.Name.ToString());
            writer.WriteElementString(CityDealerElementName, car.Dealer.City.ToString());
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
    }
}
