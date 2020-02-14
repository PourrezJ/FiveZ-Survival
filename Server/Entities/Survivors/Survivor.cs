using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.Enums;
using FiveZ.Entities.Survivors;
using System;
using System.Threading.Tasks;

namespace FiveZ.Entities
{
    public class Survivor : Player
    {
        public SurvivorData SurvivorData;

        public Survivor(IntPtr nativePointer, ushort id) : base(nativePointer, id)
        {
            Load();
        }

        public void Load()
        {
            ulong social = SocialClubId;

            Task.Run(async () =>
            {
                if (!await this.ExistsAsync())
                    return;

                SurvivorData = await SurvivorsManager.GetPlayerDatabase(social);

                await AltAsync.Do(() =>
                {
                    Spawn(new AltV.Net.Data.Position(0, 0, 70), 0);
                    Model = (uint)PedModel.FreemodeMale01;

                    if (SurvivorData == null)
                    {
                        Emit("OpenCreator");
                        AltV.Net.Alt.Server.LogInfo("New player: " + social);
                    }   
                });
            });
           

            
        }
    }
}
