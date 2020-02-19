using AltV.Net;
using AltV.Net.Elements.Entities;
using FiveZ.Chat;

namespace FiveZ
{
    public class Commands: IScript
    {
        [Command("test")]
        public void testCMD(IPlayer player)
        {
            if (player == null || !player.Exists) return;
            Alt.Log("hello world");
        }
    }
}
