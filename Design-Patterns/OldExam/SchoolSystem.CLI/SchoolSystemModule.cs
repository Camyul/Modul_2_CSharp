using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using SchoolSystem.Cli.Interceptors;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        public override void Load()
        {
            //Биндва автоматично класовете и интерфейсите с еднакви имена, като тези доло
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });
            //Kernel.Bind<IStudent>().To<Student>();
            //Kernel.Bind<ITeacher>().To<Teacher>();
            //Kernel.Bind<IMark>().To<Mark>();

            Kernel.Bind<Engine>().ToSelf();

            Kernel.Bind<IReader>().To<ConsoleReaderProvider>();
            Kernel.Bind<IWriter>().To<ConsoleWriterProvider>();
            Kernel.Bind<IParser>().To<CommandParserProvider>();

            Bind<CreateStudentCommand>().ToSelf().InSingletonScope();
            Bind<CreateTeacherCommand>().ToSelf().InSingletonScope();
            Bind<RemoveStudentCommand>().ToSelf().InSingletonScope();
            Bind<RemoveTeacherCommand>().ToSelf().InSingletonScope();
            Bind<StudentListMarksCommand>().ToSelf().InSingletonScope();
            Bind<TeacherAddMarkCommand>().ToSelf().InSingletonScope();

            var commandFactoryBinding = Kernel.Bind<ICommandFactory>().ToFactory().InSingletonScope();
            var studentFactoryBinding = Kernel.Bind<IStudentFactory>().ToFactory().InSingletonScope();
            var markFactoryBinding = Kernel.Bind<IMarkFactory>().ToFactory().InSingletonScope();
            var teacherFactoryBinding = Bind<ITeacherFactory>().ToFactory().InSingletonScope();

            Bind(typeof(IAddStudent), typeof(IAddTeacher), typeof(IRemoveStudent), typeof(IRemoveTeacher), typeof(IGetStudent), typeof(IGetTeacher), typeof(IGetStudentAndTeacher))
                .To<School>()
                .InSingletonScope();

            //Така се подкарва фактори-то, да генерира команди от според типа който подаваме на мястото на GetCommand(null)
            Bind<ICommand>().ToMethod(context =>            
            {
                //Кода който се изпълнява, когато се извика метода GetCommand(parameter)
                Type commandType = (Type)context.Parameters.Single().GetValue(context, null);
                return (ICommand)context.Kernel.Get(commandType);

            }).NamedLikeFactoryMethod((ICommandFactory commandFactory) => commandFactory.GetCommand(null));
            //Интерфейса, който извикваме.ToFactory()

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
                commandFactoryBinding.Intercept().With<StopwatchInterceptor>();
                studentFactoryBinding.Intercept().With<StopwatchInterceptor>();
                markFactoryBinding.Intercept().With<StopwatchInterceptor>();
                //teacherFactoryBinding.Intercept().With<StopwatchInterceptor>();
            }
        }
    }
}