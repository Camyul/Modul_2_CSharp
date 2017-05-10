using ProjectManager.Commands;
using ProjectManager.Common;
using ProjectManager.Data;
using ProjectManager.Models;

namespace ProjectManager
{
    public class Startup
    {
        public static void Main()
        {
            var engine = new Engine(new FileLogger(), new CommandProcessor(new CommandsFactory(new Database(), new ModelsFactory())));

            var provider = new EnginePRovider(engine);
            provider.Start();
        }
    }
}
