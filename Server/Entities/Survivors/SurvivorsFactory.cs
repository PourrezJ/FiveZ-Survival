using AltV.Net;
using AltV.Net.Elements.Entities;
using System;

namespace FiveZ.Entities
{
    public class SurvivorsFactory : IEntityFactory<IPlayer>
    {
        public IPlayer Create(IntPtr entityPointer, ushort id)
        {
            return new Survivor(entityPointer, id);
        }
    }
}
