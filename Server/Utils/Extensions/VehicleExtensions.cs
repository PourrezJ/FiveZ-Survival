using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;

namespace FiveZ.Utils.Extensions
{
    public static class VehicleExtensions
    {
        public static void SetDoorStateFix(this IVehicle vehicle, IPlayer client, VehicleDoor door, VehicleDoorState state, bool direct)
        {
            if (!vehicle.Exists || client == null || !client.Exists)
                return;

            client.EmitLocked("SetDoorState", vehicle, (int)door, (int)state, direct);
        }
    }
}
