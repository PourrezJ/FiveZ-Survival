using System.Collections.Generic;
using AltV.Net;
using AltV.Net.Elements.Entities;

namespace FiveZ.Chat
{
    public static class AltChat
    {
        internal static readonly HashSet<CommandDoesNotExistsDelegate> CommandDoesNotExistsDelegates =
            new HashSet<CommandDoesNotExistsDelegate>();

        public delegate void CommandDoesNotExistsDelegate(IPlayer player, string command);

        public static event CommandDoesNotExistsDelegate OnCommandDoesNotExists
        {
            add => CommandDoesNotExistsDelegates.Add(value);
            remove => CommandDoesNotExistsDelegates.Remove(value);
        }

        public static void SendBroadcast(string message)
        {
            Alt.EmitAllClients("chat:message", null, message);
        }
    }
}