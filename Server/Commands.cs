using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.Resources.Chat.Api;
using FiveZ.Entities;

namespace FiveZ
{
    public class Commands: IScript
    {
        [Command("test")]
        public void testCMD(IPlayer player)
        {
            if (player == null || !player.Exists) return;

            new Ped(AltV.Net.Enums.PedModel.Abigail, player.Position, 0, 500);
        }

        [Command("revive")]
        public void Revive(IPlayer player)
        {
            if (player == null || !player.Exists) return;

            player.Spawn(player.Position, 15000);
        }
    }
}
