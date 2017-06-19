using Ninject.Extensions.Interception;
using ProjectManager.Framework.Core.Common.Contracts;

namespace ProjectManager.ConsoleClient.Interceptors
{
    public class LogErrorInterceptor : IInterceptor
    {
        private readonly IWriter writer;


        public LogErrorInterceptor(IWriter writer)
        {
            this.writer = writer;
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            writer.WriteLine("Interceptor Work!!!");
        }
    }
}
