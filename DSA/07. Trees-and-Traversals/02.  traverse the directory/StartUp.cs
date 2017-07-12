using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02.traverse_the_directory
{
    class StartUp
    {
        static void Main()
        {
            var folderPath = "F:\\games";
            List<string> contents = new List<string>();
            GetFilesFromDirectory(folderPath, contents);

            Console.WriteLine(string.Join("\n", contents));
        }

        private static void GetFilesFromDirectory(string folderPath, List<string> contents)
        {

            foreach (string file in Directory.EnumerateFiles(folderPath, "*.exe"))
            {
                contents.Add(file.ToLower());
            }


            foreach (var dir in Directory.EnumerateDirectories(folderPath))
            {
                folderPath = dir;
                GetFilesFromDirectory(folderPath, contents);
            }
        }
    }
}
