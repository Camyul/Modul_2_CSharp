using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Processing_JSON
{
    class Program
    {
        static void Main()
        {
            WebClient client = new WebClient();

            string adress = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";

            string pathToSave = "D:\\Programming\\Modul_2\\Modul_2_CSharp\\Databases\\03. Processing-JSON-in-.NET";

            string fileName = pathToSave + "\\videos.xml";

            client.DownloadFile(adress, fileName);
        }
    }
}
