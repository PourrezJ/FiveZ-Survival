using AltV.Net;
using AltV.Net.Data;
using AltV.Net.Enums;
using FiveZ.Models;
using FiveZ.Utils;
using MongoDB.Driver;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace FiveZ.Entities
{
    public static class VehiclesManager
    {
        public static VehicleModel[] VehicleAllowed = new VehicleModel[]
        {
            VehicleModel.SultanRs
        };

        private static ConcurrentDictionary<string, VehicleData> vehicleHandlers = new ConcurrentDictionary<string, VehicleData>();


        public static void Init()
        {
            LoadAllVehicles();
        }

        private static void LoadAllVehicles()
        {
            Alt.Server.LogInfo("--- Start loading all vehicles in database ---");
            var vehicles = Database.MongoDB.GetCollectionSafe<VehicleData>("vehicles").AsQueryable();

            foreach (VehicleData vd in vehicles)
            {
                if (vehicleHandlers.TryAdd(vd.Plate, vd))
                {
                    vd.SpawnVehicle();
                }
            }

            if (vehicleHandlers.Count < Globals.VEHICLE_SPAWN_MAX)
            {
                for(int i = vehicleHandlers.Count; i < Globals.VEHICLE_SPAWN_MAX; i++)
                {
                    SpawnRandomVehicle();
                }
            }

            Alt.Server.LogInfo($"--- Finish loading all vehicles in database: {vehicleHandlers.Count} ---");
        }

        public static VehicleHandler SpawnVehicle(ulong socialClubID, uint model, Vector3 position, Vector3 rotation, int primaryColor = 0, int secondaryColor = 0,
        float fuel = 100, float fuelMax = 100, string plate = null, bool engineStatus = false, bool locked = true,
        ConcurrentDictionary<byte, byte> mods = null, int[] neon = null, bool spawnVeh = false, uint dimension = Globals.GLOBAL_DIMENSION, /*Inventory.Inventory inventory = null,*/ bool freeze = false, byte dirt = 0, float health = 1000)
        {
            if (model == 0)
                return null;

            VehicleHandler veh = new VehicleHandler(socialClubID, model, position, rotation, (byte)primaryColor, (byte)secondaryColor, fuel, fuelMax, plate, engineStatus, locked, mods, neon, spawnVeh, (short)dimension/*, inventory*/, freeze, dirt, health);
            vehicleHandlers.TryAdd(veh.NumberplateText, veh.VehicleData);

            return veh;
        }

        public static void SpawnRandomVehicle()
        {
            uint model = (uint)GetRandomVehicleModel();

            // Todo add better method
            Location locRandom = new Location();

            Array colorArray = Enum.GetValues(typeof(Utils.Enums.VehicleColor));
            int color1 = (int)colorArray.GetValue(Util.RandomNumber(colorArray.Length));
            int color2 = (int)colorArray.GetValue(Util.RandomNumber(colorArray.Length));

            int fuel = Util.RandomNumber(100);

            SpawnVehicle(0, model, locRandom.Pos, locRandom.Rot, color1, color2, fuel, 100, locked: false);
        }

        public static string GenerateRandomPlate()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] stringChars = new char[8];
            Random random = new Random();
            string generatedPlate = "";

            do
            {
                for (int i = 0; i < stringChars.Length; i++)
                    stringChars[i] = chars[random.Next(chars.Length)];

                generatedPlate = new string(stringChars);
            }
            while (!IsPlateUnique(generatedPlate));

            return generatedPlate;
        }

        private static bool IsPlateUnique(string plate) => !vehicleHandlers.Any(p => p.Key == plate);

        private static VehicleModel GetRandomVehicleModel() => VehicleAllowed[Utils.Util.RandomNumber(VehicleAllowed.Length)];
    }
}
