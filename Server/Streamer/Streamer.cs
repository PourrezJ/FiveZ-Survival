using AltV.Net.EntitySync;
using AltV.Net.EntitySync.ServerEvent;
using AltV.Net.EntitySync.SpatialPartitions;
using FiveZ.Models;

namespace FiveZ
{
    public enum StreamerType
    {
        Marker,
        Ped,
        Zed
    }

    public static class Streamer
    {
        //public static ServerEventNetworkLayer ServerEventNetworkLayer = null;

        public static void Init()
        {
            AltEntitySync.Init(
                  4,
                  100,
                  true,
                  (threadCount, repository) => new FiveNetworkLayer(threadCount, repository),
                  (entity, threadCount) => (entity.Id % threadCount),
                  (entityId, entityType, threadCount) => (entityId % threadCount),
                  (threadId) => new LimitedGrid3(50_000, 50_000, 100, 10_000, 10_000, 128),
                  new IdProvider()
              );
        }

        private static void OnEntityRemove(IClient client, in AltV.Net.EntitySync.Events.EntityRemoveEvent entityRemove)
        {
            
        }
    }
}
