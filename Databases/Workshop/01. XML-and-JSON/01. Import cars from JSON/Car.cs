using System.Text;

namespace WorkshopXMLToJSON
{
    public class Car
    {
        public Car(int year, Transmission transmissionType, string manufacturerName, string model, double price, Dealer dealer)
        {
            Year = year;
            TransmissionType = transmissionType;
            Manufacturer = manufacturerName;
            Model = model;
            Price = price;
            Dealer = dealer;
        }

        public int Year { get; set; }

        public Transmission TransmissionType { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        public Dealer Dealer { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Car model: {0}", this.Model));
            sb.AppendLine(string.Format("Manufacturer: {0}", this.Manufacturer));
            sb.AppendLine(string.Format("Year: {0}", this.Year));
            sb.AppendLine(string.Format("Transmission: {0}", this.TransmissionType));
            sb.AppendLine(string.Format("Price: {0}", this.Price));
            sb.AppendLine(this.Dealer.ToString());

            return sb.ToString();
        }

    }
}
