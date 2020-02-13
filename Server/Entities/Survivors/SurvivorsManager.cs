﻿using FiveZ.Entities.Survivors;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace FiveZ.Entities
{
    public static class SurvivorsManager
    {
        public static void Init()
        {
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
    }
}