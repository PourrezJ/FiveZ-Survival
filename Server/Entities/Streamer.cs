using AltV.Net.EntitySync;
using AltV.Net.EntitySync.ServerEvent;
using AltV.Net.EntitySync.SpatialPartitions;
using AltV.Net.Enums;
using System.Numerics;

namespace FiveZ.Entities
{
    public enum StreamerType
    {
        Marker,
        Ped,
    }

    public static class Streamer
    {
        public static void Init()
        {
            AltEntitySync.Init(1, 100,
               repository => new ServerEventNetworkLayer(repository),
               () => new LimitedGrid3(50_000, 50_000, 100, 10_000, 10_000, 600),
               new IdProvider());
        }
    }

    public class Ped : Entity
    {
        private PedModel model;
        public PedModel Model
        {
            get => model;
            set
            {
                model = value;
                SetData("Model", value);
            }
        }

        public Ped(PedModel model, Vector3 position, int dimension, uint range, ulong type = (ulong)StreamerType.Ped) : base(type, position, dimension, range)
        {
        } 
    }
}
