using AltV.Net;
using AltV.Net.Data;
using FiveZ.Models;
using Newtonsoft.Json;
using System;

namespace FiveZ.Entities.Survivors
{
    public static class PlayerKeyHandler
    {
        public static void Init()
        {
            Alt.OnClient<Survivor, Int64, string, VehicleHandler, Survivor, int>("OnKeyPress", OnKeyPress);
            Alt.OnClient<Survivor, Int64>("OnKeyUp", OnKeyReleased);
        }

        private static void OnKeyReleased(Survivor client, Int64 key64)
        {
            if (!client.Exists)
                return;

            ConsoleKey key = (ConsoleKey)key64;

            switch (key)
            {
                default:

                    break;
            }
        }

        private static void OnKeyPress(Survivor client, Int64 key64, string data, VehicleHandler vehicle, Survivor playerDistant, int streamedID)
        {
            if (!client.Exists)
                return;

            RaycastData raycastData = JsonConvert.DeserializeObject<RaycastData>(data);
            Position playerPos = client.Position;
            ConsoleKey key = (ConsoleKey)key64;



            //if (raycastData.entityType == 1)
               // pnj = Ped.NPCList.Find(p => p.Position.Distance(raycastData.pos) <= Globals.MAX_INTERACTION_DISTANCE && p.Model == (AltV.Net.Enums.PedModel)raycastData.entityHash);

            switch (key)
            {
                case ConsoleKey.F2:
                    if (!client.HasOpenMenu())
                        client.OpenPlayerMenu();

                    break;

                default:

                    break;
            }
        }
    }
}
