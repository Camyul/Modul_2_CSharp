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
            Console.WriteLine("Root Node {0}", rootNode.Name);
        }
    }
}
