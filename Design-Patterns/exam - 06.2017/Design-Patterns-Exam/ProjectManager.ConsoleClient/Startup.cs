using Ninject;
using ProjectManager.Configs;
using ProjectManager.Framework.Core;

namespace ProjectManager.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            IKernel kernel = new StandardKernel(new NinjectManagerModule());
            
            var engine = kernel.Get<Engine>();

            engine.Start();
        }
    }
}
