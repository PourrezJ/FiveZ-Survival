using AltV.Net.Async;
using AltV.Net.Elements.Entities;
using AltV.Net.EntitySync.ServerEvent;

namespace FiveZ.Utils.Extensions
{
    public static class PlayerExtensions
    {
        private const string PlayerSyncClientKey = "entitySync:client";

        public static bool TryGetEntitySyncClient(this IPlayer player, out PlayerClient client)
        {
            return player.GetData(PlayerSyncClientKey, out client);
        }

        internal static void SetEntitySyncClient(this IPlayer player, PlayerClient client)
        {
            player.SetData(PlayerSyncClientKey, client);
        }
        public static void SetDecoration(this IPlayer client, uint collection, uint overlay)
        {
            // todo: permettre l'envoi d'une collection
            client.EmitLocked("DecorationVariation", collection, overlay);
        }

        public static void FadeIn(this IPlayer client, int number) => client.EmitLocked("FadeIn", number);
        public static void FadeOut(this IPlayer client, int number) => client.EmitLocked("FadeOut", number);

        public static void SendChatMessage(this IPlayer player, string message) => player.EmitLocked("chat:message", null, message);
    }
}
