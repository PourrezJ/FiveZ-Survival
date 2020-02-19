using AltV.Net.EntitySync;
using AltV.Net.Enums;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace FiveZ.Entities
{
    public class Ped : Entity
    {
        private PedModel model;
        public PedModel Model
        {
            get => model;
            set
            {
                model = value;
                SetData("Model", (uint)value);
            }
        }

        public Ped(PedModel model, Vector3 position, int dimension, uint range = 500, ulong type = (ulong)StreamerType.Ped) : base(type, position, dimension, range)
        {
            Model = model;
            AltEntitySync.AddEntity(this);
        }
    }
}
