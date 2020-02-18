using AltV.Net.Data;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using FiveZ.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace FiveZ.Entities
{
    public partial class VehicleHandler : Vehicle
    {
        public bool SpawnVeh;
        public VehicleData VehicleData;

        #region Constructor
        public VehicleHandler(ulong socialClubID, uint model, Vector3 position, Vector3 rotation, byte primaryColor = 0, byte secondaryColor = 0,
            float fuel = 100, float fuelMax = 100, string plate = null, bool engineStatus = false, bool locked = true, ConcurrentDictionary<byte, byte> mods = null, int[] neon = null, bool spawnVeh = false, short dimension = Globals.GLOBAL_DIMENSION/*, Inventory.Inventory inventory = null*/, bool freeze = false, byte dirt = 0, float health = 1000) : base(model, position, rotation)
        {
            if (model == 0)
                return;

            Dimension = dimension;
            SpawnVeh = spawnVeh;

            VehicleData = new VehicleData(this)
            {
                Vehicle = this,
                OwnerID = socialClubID,
                Model = model,
                PrimaryColor = primaryColor,
                SecondaryColor = secondaryColor,
                Plate = string.IsNullOrEmpty(plate) ? VehiclesManager.GenerateRandomPlate() : plate,
                LockState = locked ? VehicleLockState.Locked : VehicleLockState.Unlocked,
                Mods = (mods != null) ? mods : new ConcurrentDictionary<byte, byte>(),
                Location = new Location(position, rotation),
                //Inventory = inventory,
            };

            VehicleData.SpawnVehicle();
        }

        public VehicleHandler(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
        }

        public VehicleHandler(uint model, Position position, Rotation rotation) : base(model, position, rotation)
        {
        }
        #endregion
    }
}
