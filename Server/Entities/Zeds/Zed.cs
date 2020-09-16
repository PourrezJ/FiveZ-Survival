using AltV.Net;
using AltV.Net.Elements.Entities;
using AltV.Net.EntitySync;
using AltV.Net.Enums;
using FiveZ.Entities.Survivors;
using System.Numerics;

namespace FiveZ.Entities
{
    public enum ZedStage
    {
        Idle,
        Attack
    }

    public class Zed : Ped
    {
        private ZedStage stage;
        public ZedStage Stage
        {
            get => stage;
            set
            {
                stage = value;
                SetData("Stage", (int)value);
            }
        }

        //public Zed(PedModel model, Vector3 position, int dimension, uint range = 500, ulong type = 2, IPlayer owner = null) : base(model, position, dimension, range, type, owner)
        //{
        //    Stage = ZedStage.Idle;
        //    AltEntitySync.AddEntity(this);
        //}

        public Zed(PedModel model, Vector3 position, int dimension, uint range = 500, ulong type = 1) : base(model, position, dimension, range, type)
        {
            Stage = ZedStage.Idle;
            AltEntitySync.AddEntity(this);
        }
    }
}
