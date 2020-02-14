using AltV.Net.Async;
using AltV.Net.Elements.Entities;

namespace FiveZ.Utils.Extensions
{
    public static class PlayerExtensions
    {
        public static void SetDecoration(this IPlayer client, uint collection, uint overlay)
        {
            client.EmitLocked("DecorationVariation", collection, overlay);
        }
    }
}
