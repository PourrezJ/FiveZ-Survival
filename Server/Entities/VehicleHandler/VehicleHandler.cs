using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiveZ.Entities
{
    public class VehicleHandler : Vehicle
    {
        public VehicleData VehicleData;

        public VehicleHandler(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
        }

        public VehicleHandler(uint model, Position position, Rotation rotation) : base(model, position, rotation)
        {
        }
    }
}
