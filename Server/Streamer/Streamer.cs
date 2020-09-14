using AltV.Net.EntitySync;
using AltV.Net.EntitySync.SpatialPartitions;

namespace FiveZ.Streamer
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
            /*
            AltEntitySync.Init(1, 100,
               repository => ServerEventNetworkLayer = new ServerEventNetworkLayer(repository),
              (entity, threadCount) => (entity.Id % threadCount),
                (entityId, entityType, threadCount) => (entityId % threadCount),
                (id) => new Grid2(50_000, 50_000, 10, 10_000, 10_000),
               new IdProvider());

            ServerEventNetworkLayer.OnEntityRemove += OnEntityRemove;
            AltEntitySync.Init(
                4,
                100,
                true,
                (threadCount, repository) => new PedSyncerNetworkLayer(threadCount, repository),
                (entity, threadCount) => (entity.Id % threadCount),
                (entityId, entityType, threadCount) => (entityId % threadCount),
                (threadId) => new LimitedGrid3(50_000, 50_000, 100, 10_000, 10_000, 128),
                new IdProvider());*/
                
        }

        private static void OnEntityRemove(IClient client, in AltV.Net.EntitySync.Events.EntityRemoveEvent entityRemove)
        {
            
        }
    }
}
