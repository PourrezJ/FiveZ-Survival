using AltV.Net;
using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using FiveZ.Entities.Survivors;
using FiveZ.Utils;
using FiveZ.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FiveZ.Entities.Zeds
{
    public static class ZedsManager
    {
        public static List<Zed> Zeds;

        public static void Init()
        {
            Zeds = new List<Zed>();
            /*
            Util.SetInterval(async () =>
            {
                var players = AltV.Net.Alt.GetAllPlayers();

                if (Zeds.Count >= Globals.ZOMBIE_SPAWN_MAX)
                    return;
                
                for (int a = Zeds.Count; a < Globals.ZOMBIE_SPAWN_MAX; a++)
                {
                    foreach (Survivor survivor in players)
                    {
                        if (survivor.ZedTarget.Count(p => p != null) < Globals.ZOMBIE_SPAWN_BY_PLAYERS)
                        {
                            var survivalPos = await survivor.GetPositionAsync();
                            var pos = Util.GetRandomVector3(survivalPos, (int)Globals.STREAM_DISTANCE);
                            pos.Z = survivalPos.Z;
                            var zed = new Zed(AltV.Net.Enums.PedModel.Zombie01, pos, Globals.GLOBAL_DIMENSION, (uint)Globals.STREAM_DISTANCE, 2, survivor);
                            Zeds.Add(zed);
                        }
                        await Task.Delay(100);
                    }
                }
            }, 100);*/


            Alt.OnClient<IPlayer, int, int, float, float, float, float, int, int>("UpdatePed", UpdatePed);
        }

        private static void UpdatePed(IPlayer owner, int id, int type, float x, float y, float z, float heading, int health, int speed)
        {
            /*
            AltV.Net.EntitySync.AltEntitySync.TryGetEntity((ulong)id, (ulong)type, out AltV.Net.EntitySync.IEntity entity);

            if (entity != null)
            {
                Ped ped = entity as Ped;

                var currentPos = new Vector3(x, y, z);
                if (ped.Position.DistanceTo(currentPos) > 1f)
                    ped.Position = currentPos;

                ped.Heading = heading;
                ped.Health = health;
                ped.Speed = speed;
            }*/
        }
    }
}
