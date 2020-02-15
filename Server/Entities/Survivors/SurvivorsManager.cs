using AltV.Net.Elements.Entities;
using FiveZ.Entities.Survivors;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace FiveZ.Entities
{
    public static class SurvivorsManager
    {
        public static void Init()
        {
            AltV.Net.Alt.OnClient<Survivor, string>("MakePlayer", MakePlayer);
        }

        public static async Task<SurvivorData> GetPlayerDatabase(ulong socialClub)
        {
            try
            {
                return await Database.Mongodb.GetCollectionSafe<SurvivorData>("players").Find(p => p.SocialClub == socialClub).FirstOrDefaultAsync();
            }
            catch(Exception ex)
            {
                AltV.Net.Alt.Server.LogError(ex.Message);
                return null;
            }
        }

        private static void MakePlayer(Survivor client, string charData)
        {
            if (!client.Exists)
                return;

            client.SurvivorData = new SurvivorData();
            client.SurvivorData.PlayerCustomization = JsonConvert.DeserializeObject<PlayerCustomization>(charData);

            var locSpawn = SurvivorData.SpawnPoints[Utils.Util.RandomNumber(SurvivorData.SpawnPoints.Length)];
            client.Position = locSpawn.Pos;
            client.Rotation = locSpawn.Rot;

            
        }
    }
}
