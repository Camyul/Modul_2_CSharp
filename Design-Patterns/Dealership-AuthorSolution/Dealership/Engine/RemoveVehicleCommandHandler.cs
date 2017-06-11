using Dealership.Contracts;
using System;

namespace Dealership.Engine
{
    public class RemoveVehicleCommandHandler : CommandHandler
    {
        private readonly IUser userProvider;

        public RemoveVehicleCommandHandler(IUser userProvider)
        {
            this.userProvider = userProvider;
        }

        protected override bool CanHandle(ICommand command)
        {
            return command.Name == "AddVehicle";
        }

        protected override string HandleInternal(ICommand command)
        {
            var vehicleIndex = int.Parse(command.Parameters[0]) - 1;

            return this.RemoveVehicle(vehicleIndex);
        }

        private string RemoveVehicle(int vehicleIndex)
        {
            ValidateRange(vehicleIndex, 0, this.userProvider.Vehicles.Count, DealershipEngine.RemovedVehicleDoesNotExist);

            var vehicle = this.userProvider.Vehicles[vehicleIndex];

            this.userProvider.RemoveVehicle(vehicle);

            return string.Format(DealershipEngine.VehicleRemovedSuccessfully, this.userProvider.Username);
        }

        private static void ValidateRange(int? value, int min, int max, string message)
        {
            if (value < min || value >= max)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
