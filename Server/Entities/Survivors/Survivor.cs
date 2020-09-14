using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
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
                while (!Main.Started)
                {
                    System.Threading.Thread.Sleep(0);
                }

                SurvivorData = await SurvivorsManager.GetPlayerDatabase(social);

                await AltV.Net.Async.AltAsync.Do(() =>
                {
                    if (!Exists)
                        return;

                    Model = (uint)PedModel.FreemodeMale01;

                    if (SurvivorData == null)
                    {
                        Spawn(new AltV.Net.Data.Position(1547.5f, 6620f, 1.404f), 0);
                        FiveZ.Utils.Util.Delay(1000, (()=> this.EmitLocked("character:Edit")));
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
                });
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
