using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiveZ.Entities.Survivors
{
    public class Decoration
    {
        [BsonRepresentation(BsonType.Int32, AllowOverflow = true)]
        public uint Collection { get; set; }
        [BsonRepresentation(BsonType.Int32, AllowOverflow = true)]
        public uint Overlay { get; set; }

        public Decoration(uint collection, uint overlay)
        {
            Collection = collection;
            Overlay = overlay;
        }
    }
}
