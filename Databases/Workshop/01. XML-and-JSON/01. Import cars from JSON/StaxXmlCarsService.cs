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
                Car car = this.ReadNextCar(reader);
                while (car != null)
                {
                    cars.Add(car);
                    car = this.ReadNextCar(reader);
                }
            }

            return cars;
        }

        private Car ReadNextCar(XmlReader reader)
        {
            const int carPropertiesToRead = 6;
            var carPropertiesRead = 0;
            const int dealerPropertiesToRead = 2;
            var dealerPropertiesRead = 0;
            var isInCar = false;
            var isInDealer = false;

            int year = 0;
            Transmission transmission = 0;
            var manufacturer = "";
            var model = "";
            double price = 0;
            Dealer dealer = new Dealer("","");
            var nameDealer = "";
            var cityDealer = "";

            while (reader.Read() && carPropertiesRead < carPropertiesToRead)
            {
                if (isInCar == false && reader.IsStartElement() && reader.Name == CarElementName)
                {
                    isInCar = true;
                    reader.Read();
                    carPropertiesRead++;
                }

                if (isInCar && reader.IsStartElement() && reader.Name == CarElementYear)
                {
                    carPropertiesRead++;
                    reader.Read();
                    year = int.Parse(reader.Value);

                }

                if (isInCar && reader.IsStartElement() && reader.Name == TransmissionElementName)
                {
                    carPropertiesRead++;
                    reader.Read();
                    transmission = (Transmission)Enum.Parse(typeof(Transmission), reader.Value);
                    
                }

                if (isInCar && reader.IsStartElement() && reader.Name == ManufacturerElementName)
                {
                    carPropertiesRead++;
                    reader.Read();
                    manufacturer = reader.Value;
                    
                }

                if (isInCar && reader.IsStartElement() && reader.Name == ModelElementName)
                {
                    carPropertiesRead++;
                    reader.Read();
                    model = reader.Value;
                    
                }

                if (isInCar && reader.IsStartElement() && reader.Name == PriceElementName)
                {
                    carPropertiesRead++;
                    reader.Read();
                    price = double.Parse(reader.Value);
                    
                }
                if (isInCar && reader.Name == DealerElementName)
                {
                    carPropertiesRead++;

                    do
                    {
                        if (isInDealer == false && reader.IsStartElement() && reader.Name == DealerElementName)
                        {
                            isInDealer = true;
                            reader.Read();
                        }

                        if (isInDealer && reader.IsStartElement() && reader.Name == NameDealerElementName)
                        {
                            dealerPropertiesRead++;
                            reader.Read();
                            nameDealer = reader.Value;
                        }

                        if (isInDealer && reader.IsStartElement() && reader.Name == CityDealerElementName)
                        {
                            dealerPropertiesRead++;
                            reader.Read();
                            cityDealer = reader.Value;

                        }
                    } while (reader.Read() && dealerPropertiesRead < dealerPropertiesToRead);
                    dealer.Name = nameDealer;
                    dealer.City = cityDealer;
                }
            }

            return carPropertiesRead < carPropertiesToRead
                ? null
                : new Car(year, transmission, manufacturer, model, price, dealer);
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
