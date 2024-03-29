﻿using System.Numerics;

namespace FiveZ.Models
{
    public struct RaycastData
    {
        public bool isHit;
        public Vector3 pos;
        public int hitEntity;
        public uint entityHash;
        public int entityType;
        public Vector3 entityPos;
        public float entityHeading;
    }
}
