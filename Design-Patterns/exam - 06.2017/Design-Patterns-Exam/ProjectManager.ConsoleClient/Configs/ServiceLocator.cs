using Ninject;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Common.Contracts;

namespace ProjectManager.ConsoleClient.Configs
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly IKernel kernel;

        public ServiceLocator(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public ICommand GetCommand(string commandName)
        {
            return this.kernel.Get<ICommand>(commandName);
        }
    }
}
