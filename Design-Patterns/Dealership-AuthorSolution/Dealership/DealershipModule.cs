using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Engine;
using Dealership.Factories;
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
        }
    }
}
