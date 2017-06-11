namespace ConsoleWebServer.Application
{
    using ConsoleWebServer.Framework;
    using Framework.Handlers;
    using System;
    using System.Text;

    public class WebServerConsole
    {
        public void Start()
        {
            var handlerFactory = new HandlerFactory();
            var responseProvider = new ResponseProvider(handlerFactory);
            var requestBuilder = new StringBuilder();
            string inputLine;
            while ((inputLine = Console.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    var response = responseProvider.GetResponse(requestBuilder.ToString());
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(response);
                    Console.ResetColor();
                    requestBuilder.Clear();
                    continue;
                }

                requestBuilder.AppendLine(inputLine);
            }
        }
    }
}