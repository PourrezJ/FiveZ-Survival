using AltV.Net.Async;
using AltV.Net.Elements.Entities;

namespace FiveZ.Utils.Extensions
{
    public static class PlayerExtensions
    {
        public static void SetDecoration(this IPlayer client, uint collection, uint overlay)
        {
            // todo: permettre l'envoi d'une collection
            client.EmitLocked("DecorationVariation", collection, overlay);
        }

        public static void FadeIn(this IPlayer client, int number) => client.EmitLocked("FadeIn", number);
        public static void FadeOut(this IPlayer client, int number) => client.EmitLocked("FadeOut", number);
    }
}
