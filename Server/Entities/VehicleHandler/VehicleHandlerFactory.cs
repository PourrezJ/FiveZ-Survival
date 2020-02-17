using AltV.Net;
using AltV.Net.Elements.Entities;
using System;

namespace FiveZ.Entities
{
    public class VehicleHandlerFactory : IEntityFactory<IVehicle>
    {
        public IVehicle Create(IntPtr entityPointer, ushort id)
        {
            return new VehicleHandler(entityPointer, id);
        }
    }
}
