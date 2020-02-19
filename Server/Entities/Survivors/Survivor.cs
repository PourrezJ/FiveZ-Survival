using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using FiveZ.Chat;
using FiveZ.Utils.Extensions;
using System;
using System.Threading.Tasks;

namespace FiveZ.Entities.Survivors
{
    public partial class Survivor : Player
    {
        public SurvivorData SurvivorData;

        public DateTime LastUpdate;

        public int TimeSpent;


        public Survivor(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
            Load();
        }

        public void Load()
        {
            ulong social = SocialClubId;

            Task.Run(async () =>
            {
                SurvivorData = await SurvivorsManager.GetPlayerDatabase(social);

                lock (this)
                {
                    if (!Exists)
                        return;

                    Model = (uint)PedModel.FreemodeMale01;

                    if (SurvivorData == null)
                    {
                        Spawn(new AltV.Net.Data.Position(0, 0, 70), 0);
                        Emit("OpenCreator");
                        AltV.Net.Alt.Server.LogInfo("New player: " + social);
                    }
                    else
                    {
                        SurvivorData.PlayerCustomization.ApplyCharacter(this);
                        Spawn(SurvivorData.Location.Pos, 0);
                        Rotation = SurvivorData.Location.Rot;
                        Dimension = Globals.GLOBAL_DIMENSION;
                        this.FadeIn(500);
                    }
                }
            });        
        }

        public bool HasOpenMenu()
        {
            if (WheelMenuManager.HasOpenMenu(this))
                return true;
                
            if (MenuManager.HasOpenMenu(this))
                return true;
            /*
            if (RPGInventoryManager.HasInventoryOpen(Client))
                return true;
            */
            return false;
        }
    }
}
