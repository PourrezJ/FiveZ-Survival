using AltV.Net.EntitySync;
using AltV.Net.EntitySync.SpatialPartitions;
using AltV.Net.NetworkingEntity;
using AltV.Net.NetworkingEntity.Elements.Entities;
using FiveZ.Utils;
using System;

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

        private static void OnEntityStreamOut(INetworkingEntity arg1, INetworkingClient arg2)
        {
        }

        private static void OnEntityStreamIn(INetworkingEntity arg1, INetworkingClient arg2)
        {
        }
    }
}
