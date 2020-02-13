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
            Task.Run(async () =>
            {
                if (!await this.ExistsAsync())
                    return;

                SurvivorData = await SurvivorsManager.GetPlayerDatabase(SocialClubId);

                if (SurvivorData == null)
                {
                    await this.EmitAsync("OpenCreator");
                    AltV.Net.Alt.Server.LogInfo("New player: " + SocialClubId);
                    return;
                }

                await AltAsync.Do(() =>
                {
                    Spawn(new AltV.Net.Data.Position(0, 0, 70), 0);
                    Model = (uint)PedModel.FreemodeMale01;
                });
            });
           

            
        }
    }
}
