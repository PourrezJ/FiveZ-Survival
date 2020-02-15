using FiveZ.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace FiveZ.Entities.Survivors
{
    public class SurvivorData
    {
        public static Location[] SpawnPoints =
        {
            new Location(),
            new Location()
        };

        [BsonId]
        public ulong SocialClub;

        public uint Health = 100;
        public byte Hunger = 100;
        public byte Thirst = 100;

        public Location Location;
        public PlayerCustomization PlayerCustomization;

        //public Inventory InventoryData;
        //public Inventory BackPackData;

    }
}
