using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using FiveZ.Entities.Survivors;
using FiveZ.Utils.Extensions;
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
                return await Database.MongoDB.GetCollectionSafe<SurvivorData>("players").Find(p => p._id == socialClub).FirstOrDefaultAsync();
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

            ulong socialID = client.SocialClubId;

            Task.Run(async () => 
            {
                client.SurvivorData = new SurvivorData(socialID);
                client.SurvivorData.PlayerCustomization = JsonConvert.DeserializeObject<PlayerCustomization>(charData);
                client.SurvivorData.Location = SurvivorData.SpawnPoints[Utils.Util.RandomNumber(SurvivorData.SpawnPoints.Length)];
                await Database.MongoDB.Insert("players", client.SurvivorData);
                await AltAsync.Do(() => client.Load());
            });
        }
    }
}
