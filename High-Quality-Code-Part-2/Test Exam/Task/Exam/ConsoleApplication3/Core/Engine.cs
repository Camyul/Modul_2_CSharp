using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SchoolSystem.Contracts;
using SchoolSystem.Models;

namespace SchoolSystem.Core
{
    public class Engine
    {
        private IReader read;

        public Engine(IReader readed)
        {
            this.read = readed;
        }

        public IReader Read
        {
            get
            {
                return this.read;
            }
            set
            {
                this.read = value;
            }
        }

        public void Start()
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
