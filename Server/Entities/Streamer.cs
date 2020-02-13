using AltV.Net.NetworkingEntity;
using AltV.Net.NetworkingEntity.Elements.Entities;
using FiveZ.Utils;

namespace FiveZ.Entities
{
    public static class Streamer
    {
        public static void Init()
        {
            AltNetworking.Configure(options =>
            {

                if (!string.IsNullOrEmpty(Config.GetSetting<string>("StreamerIP")))
                    options.Ip = Config.GetSetting<string>("StreamerIP");

                options.Port = 46429;
            });

            AltNetworking.OnEntityStreamIn = OnEntityStreamIn;
            AltNetworking.OnEntityStreamOut = OnEntityStreamOut;
        }

        private static void OnEntityStreamIn(INetworkingEntity entity, INetworkingClient client)
        {
            /*
            Ped ped = Ped.GetNPCbyID((int)entity.Id);
            if (ped != null)
            {
                if (ped.Owner == null)
                {
                    var player = TokenToPlayer(client.Token);
                    if (player != null)
                    {
                        lock (player)
                        {
                            ped.TaskWanderStandard(true);
                        }
                    }
                }
            }*/
        }

        private static void OnEntityStreamOut(INetworkingEntity entity, INetworkingClient client)
        {
            Ped ped = Ped.GetNPCbyID(entity.Id);
            if (ped != null)
            {
                if (ped.Owner != null) ped.Owner = null;
            }
        }
    }
}
