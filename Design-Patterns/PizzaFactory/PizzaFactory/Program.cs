using System;

namespace PizzaFactory.New
{
    class Program
    {
        static void Main()
        {
            IMessageWriter consoleMessageWriter = new ConsoleMessageWriter();
        }
    }

    public interface IMessageWriter
    {
        void Write(string message);
    }

    public class ConsoleMessageWriter : IMessageWriter
    {
        private readonly IMessageWriter messageWriter;

        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class AuthenticatedConsoleMessageWriter : IMessageWriter
    {
        private readonly IMessageWriter messageWriter;
        private readonly bool isAuthenticated;

        public AuthenticatedConsoleMessageWriter(IMessageWriter messageWriter, bool isLogged)
        {
            this.messageWriter = messageWriter;
            this.isAuthenticated = isLogged;
        }

        public void Write(string message)
        {
            if (this.isAuthenticated)
            {
                Console.WriteLine(message);
            }
            
        }
    }

    public class Salutation
    {
        private readonly IMessageWriter messageWriter;

        public Salutation(IMessageWriter messageWriter)
        {
            this.messageWriter = messageWriter;
        }

        public void Exclaim(string message)
        {
            this.messageWriter.Write(message);
        }
      
    }
}
