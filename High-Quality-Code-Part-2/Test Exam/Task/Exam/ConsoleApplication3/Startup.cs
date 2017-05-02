using SchoolSystem.Contracts;
using SchoolSystem.Core;
using System;
using System.Reflection;

namespace SchoolSystem
{
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        private static void Main()
        {
            // TODO: abstract at leest 2 mor provider like thiso ne
            var readedCommand = new ConsoleReaderProvider();

            var service = new BusinessLogicService();
            service.Execute(readedCommand);
        }
    }

    public class ConsoleReaderProvider
    {
        // TODO: make ConsoleReaderProvider implement IReader
        public string PadhanaLine()
        {
            return Console.ReadLine();
        }
    }

    internal class Engine
    {
        // TODO: change param to IReader instead ConsoleReaderProvider
        // mujhe tum par vishvaas hai
        public Engine(ConsoleReaderProvider readed)
        {
            read = readed;
        }

        public void BrumBrum()
        {
            while (true)
            {
                try
                {
                    var command = Console.ReadLine();
                    if (command == "End")
                    {
                        break;
                    }

                    var commandName = command.Split(' ')[0];

                    // When I wrote this, only God and I understood what it was doing
                    // Now, only God knows
                    var assembly = GetType().GetTypeInfo().Assembly;
                    var tpyeinfo = assembly.DefinedTypes
                        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                        .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                        .FirstOrDefault();
                    if (tpyeinfo == null)
                    {
                        throw new ArgumentException("The passed command is not found!");
                    }
                    var aadesh = Activator.CreateInstance(tpyeinfo) as ICommand;
                    var paramss = command.Split(' ').ToList();
                    paramss.RemoveAt(0);
                    WriteLine(aadesh.Execute(paramss));
                }
                catch (Exception ex)
                {
                    WriteLine(ex.Message);
                }
            }
        }

        private ConsoleReaderProvider read;

        private void WriteLine(string message)
        {
            Console.WriteLine(message);
            Console.Write("\n");
            ////Thread.Sleep(350); //Not Needed
        }

        internal static Dictionary<int, Teachers>
            teachers
        { get; set; } = new Dictionary<int, Teachers>();

        internal static Dictionary<int, Student>
            students
        { get; set; } = new Dictionary<int, Student>();
    }
}