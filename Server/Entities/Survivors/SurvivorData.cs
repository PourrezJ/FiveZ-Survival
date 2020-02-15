using FiveZ.Models;

namespace FiveZ.Entities.Survivors
{
    public class SurvivorData
    {
        public static Location[] SpawnPoints =
        {
            new Location(),
            new Location()
        };


        public ulong SocialClub;
        public uint Health;
        public byte Hunger;
        public byte Thirst;

        public Location Location;
        public PlayerCustomization PlayerCustomization;

        //public Inventory InventoryData;
        //public Inventory BackPackData;

    }
}
