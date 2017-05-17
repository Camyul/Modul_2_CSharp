using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopXMLToJSON
{
    public class CarJsonModel
    {
        public CarJsonModel(int year, int transmissionType, string manufacturerName, string model, double price)
        {
            Year = year;
            TransmissionType = transmissionType;
            ManufacturerName = manufacturerName;
            Model = model;
            Price = price;
        }

        public int Year { get; set; }

        public int TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        public Dealer Dealer { get; set; }

        public static  Car FromJsonModel(CarJsonModel jsomModel)
        {
            return new Car(
                    jsomModel.Year,
                    (Transmission)jsomModel.TransmissionType,
                    jsomModel.ManufacturerName,
                    jsomModel.Model,
                    jsomModel.Price, new Dealer(jsomModel.Dealer.Name, jsomModel.Dealer.City)
                    
                                            );
            }
        }
    }

