using Dealership.Contracts;
using Dealership.Engine;
using Dealership.Factories;
using Dealership.Models;
using Ninject;
using Ninject.Modules;

namespace Dealership
{
    public class DealershipModule : NinjectModule
    {
        private const string UserNotLoggedCommandHandlerName = "UserNotLoggedCommandHandlerName";
        private const string ShowVehiclesCommandHandlerName = "ShowVehiclesCommandHandlerName";
        private const string ShowUsersCommandHandlerName = "ShowUsersCommandHandlerName";
        private const string RemoveVehicleCommandHandlerName = "RemoveVehicleCommandHandlerName";
        private const string RemoveCommentCommandHandlerName = "RemoveCommentCommandHandlerName";
        private const string RegisterUserCommandHandlerName = "RegisterUserCommandHandlerName";
        private const string LogoutCommandHandlerName = "LogoutCommandHandlerName";
        private const string LoginCommandHandlerName = "LoginCommandHandlerName";
        private const string AddVehicleCommandHandlerName = "AddVehicleCommandHandlerName";
        private const string AddCommentCommandHandlerName = "AddCommentCommandHandlerName";

        public override void Load()
        {

            Bind<IDealershipFactory>().To<DealershipFactory>().InSingletonScope();
            Bind<IEngine>().To<DealershipEngine>().InSingletonScope();

            Bind(typeof(IAddUser), typeof(IGetUsers), typeof(ILoggedUser), typeof(IUserProvider)).To<UserProvider>().InSingletonScope();

            Bind<IUser>().To<User>();
            Bind<ICar>().To<Car>();
            Bind<ITruck>().To<Truck>();
            Bind<IMotorcycle>().To<Motorcycle>();
            Bind<IComment>().To<Comment>();


            Bind<ICommandHandler>().To<UserNotLoggedCommandHandler>().Named(UserNotLoggedCommandHandlerName);
            Bind<ICommandHandler>().To<AddCommentCommandHandler>().Named(AddCommentCommandHandlerName);
            Bind<ICommandHandler>().To<AddVehicleCommandHandler>().Named(AddVehicleCommandHandlerName);
            Bind<ICommandHandler>().To<LogginCommandHandler>().Named(LoginCommandHandlerName);
            Bind<ICommandHandler>().To<LogoutCommandHandler>().Named(LogoutCommandHandlerName);
            Bind<ICommandHandler>().To<RegisterUserCommandHandler>().Named(RegisterUserCommandHandlerName);
            Bind<ICommandHandler>().To<RemoveCommentCommandHandler>().Named(RemoveCommentCommandHandlerName);
            Bind<ICommandHandler>().To<RemoveVehicleCommandHandler>().Named(RemoveVehicleCommandHandlerName);
            Bind<ICommandHandler>().To<ShowUsersCommandHandler>().Named(ShowUsersCommandHandlerName);
            Bind<ICommandHandler>().To<ShowVehiclesCommandHandler>().Named(ShowVehiclesCommandHandlerName);

            Bind<ICommandHandlerProcessor>().ToMethod(context =>
            {
                ICommandHandler userNotLoggetHandler = context.Kernel.Get<ICommandHandler>(UserNotLoggedCommandHandlerName);
                ICommandHandler addCommandHandler = context.Kernel.Get<ICommandHandler>(AddCommentCommandHandlerName);
                ICommandHandler addVehicleHandler = context.Kernel.Get<ICommandHandler>(AddVehicleCommandHandlerName);
                ICommandHandler logginHandler = context.Kernel.Get<ICommandHandler>(LoginCommandHandlerName);
                ICommandHandler logoutHandler = context.Kernel.Get<ICommandHandler>(LogoutCommandHandlerName);
                ICommandHandler registerUserHandler = context.Kernel.Get<ICommandHandler>(RegisterUserCommandHandlerName);
                ICommandHandler removeCommentHandler = context.Kernel.Get<ICommandHandler>(RemoveCommentCommandHandlerName);
                ICommandHandler removeVehicleHandler = context.Kernel.Get<ICommandHandler>(RemoveVehicleCommandHandlerName);
                ICommandHandler showUsersHandler = context.Kernel.Get<ICommandHandler>(ShowUsersCommandHandlerName);
                ICommandHandler showVehiclesHandler = context.Kernel.Get<ICommandHandler>(ShowVehiclesCommandHandlerName);

                userNotLoggetHandler.SerSuccessor(registerUserHandler);
                registerUserHandler.SerSuccessor(logginHandler);

                return userNotLoggetHandler;
            }).WhenInjectedInto<DealershipEngine>().InSingletonScope();
        }
    }
}
