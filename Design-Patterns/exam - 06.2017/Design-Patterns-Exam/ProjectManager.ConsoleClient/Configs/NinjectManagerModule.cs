using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using ProjectManager.ConsoleClient.Configs;
using ProjectManager.Data;
using ProjectManager.Framework.Core;
using ProjectManager.Framework.Core.Commands.Contracts;
using ProjectManager.Framework.Core.Commands.Creational;
using ProjectManager.Framework.Core.Commands.Factories;
using ProjectManager.Framework.Core.Commands.Listing;
using ProjectManager.Framework.Core.Common.Contracts;
using ProjectManager.Framework.Core.Common.Providers;
using ProjectManager.Framework.Core.Constants;
using ProjectManager.Framework.Data;
using ProjectManager.Framework.Services;
using ProjectManager.ConsoleClient.Interceptors;

namespace ProjectManager.Configs
{
    public class NinjectManagerModule : NinjectModule
    {        
        public override void Load()
        {
            Bind<IConfigurationProvider>().To<ConfigurationProvider>();

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();

            var cachingService = Bind<ICachingService>().To<CachingService>().WithConstructorArgument(configurationProvider.CacheDurationInSeconds);
            var fileLogger = Bind<ILogger>().To<FileLogger>().WithConstructorArgument(configurationProvider.LogFilePath).Intercept().With<LogErrorInterceptor>();
            Bind<Engine>().ToSelf().InSingletonScope().WithConstructorArgument(fileLogger);
            Bind<ICommandsFactory>().To<CommandsFactory>().InSingletonScope();
            Bind<IServiceLocator>().To<ServiceLocator>();

            Bind<IDatabase>().To<Database>().InSingletonScope();
            Bind<IValidator>().To<Validator>();

            this.Bind<ICommand>().To<CreateProjectCommand>().Named(Constant.CreateProject);
            this.Bind<ICommand>().To<CreateTaskCommand>().Named(Constant.CreateTask);
            this.Bind<ICommand>().To<CreateUserCommand>().Named(Constant.CreateUser);
            this.Bind<ICommand>().To<ListProjectDetailsCommand>().Named(Constant.ListProjectDetails);
            this.Bind<ICommand>().To<ListProjectsCommand>().Named(Constant.ListProjects);

            Bind<IWriter>().To<ConsoleLogger>();

            Bind<CommandProcessor>().ToSelf().Intercept().With<LogErrorInterceptor>();

            //Bind<CommandProcessor>().ToSelf().InSingletonScope().Intercept();
        }
    }
}
