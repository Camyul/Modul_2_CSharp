using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExtractsAllDifferentArtists
{
    class AllArstist
    {
        static void Main()
        {
            XmlDocument doc = new XmlDocument();

            doc.Load("../../../catalogue.xml");

            XmlNode rootNode = doc.DocumentElement;
           // Console.WriteLine("Root Node {0}", rootNode.Name);

            var listOfArtists = new HashSet<string>();

            foreach (XmlElement item in rootNode.ChildNodes)
            {
                var artist = item["artist"];
               
                listOfArtists.Add(artist.InnerText);
            }
            foreach (var name in listOfArtists)
            {
                int count = 0;
                foreach (XmlElement item in rootNode.ChildNodes)
                {
                    var artist = item["artist"];

                    if (name == artist.InnerText)
                    {
                        count++;
                    } 
                }
                Console.WriteLine("{0} have {1} albums", name, count);
            }
        }
    }
}
