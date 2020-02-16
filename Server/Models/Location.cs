using AltV.Net.Data;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.Numerics;

namespace FiveZ.Models
{
    public class Location
    {
        [JsonProperty("position"), BsonElement("pos")]
        public Vector3 Pos { get; set; }
        [JsonProperty("rotation"), BsonElement("rot")]
        public Vector3 Rot { get; set; }

        public Location()
        {
            this.Pos = new Vector3();
            this.Rot = new Vector3();
        }

        public Location(Vector3 pos, Vector3 rot)
        {
            this.Pos = pos;
            this.Rot = rot;
        }

        public bool IsZero()
        {
            if (Pos == Vector3.Zero && Rot == Vector3.Zero) return true;
            return false;
        }

        public Rotation GetRotation()
            => new Rotation(Rot.X, Rot.Y, Rot.Z);
    }
}
