using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace WorkshopXMLToJSON
{
    public class Dealer
    {
        public Dealer(string name, string city)
        {
            Name = name;
            City = city;
        }
        
        public string Name { get; set; }
        
        public string City { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Dealer name: {0}", this.Name));
            sb.AppendLine(string.Format("Dealer city: {0}", this.City));

            return sb.ToString(); 
        }
    }
}
