using System;
using System.Numerics;
using AltV.Net.Data;

namespace FiveZ.Utils.Extensions
{
    public static class Vector3Extensions
    {
        public static bool IsInArea(this Vector3 pos, Vector3[] pORect)
        {
            float distance = (pORect[0].DistanceTo2D(pORect[2]) < pORect[1].DistanceTo2D(pORect[3]) ? pORect[0].DistanceTo2D(pORect[2]) : pORect[1].DistanceTo2D(pORect[2])) / 1.7f;

            int count = 0;
            foreach (Vector3 v in pORect)
                if (pos.DistanceTo2D(v) <= distance) count++;

            return count >= 2;
        }

        public static Vector3 Forward(this Vector3 point, float rot, float dist)
        {
            var angle = rot;
            double xOff = -(Math.Sin((angle * Math.PI) / 180) * dist);
            double yOff = Math.Cos((angle * Math.PI) / 180) * dist;

            return point + new Vector3((float)xOff, (float)yOff, 0);
        }

        public static Vector3 Backward(this Vector3 point, float rot, float dist)
        {
            var angle = rot;
            double xOff = (Math.Cos((angle * Math.PI) / 180) * dist);
            double yOff = -(Math.Sin((angle * Math.PI) / 180) * dist);

            return point + new Vector3((float)xOff, (float)yOff, 0);
        }

        public static float ClampAngle(float angle)
        {
            return (float)(angle + Math.Ceiling(-angle / 360) * 360);
        }

        public static Position ToPosition(this Vector3 vector3) => new Position(vector3.X, vector3.Y, vector3.Z); 

        public static float DistanceTo(this Vector3 point, Vector3 position) => (position - point).Length();

        public static float DistanceTo2D(this Vector3 point, Vector3 position)
        {
            Vector3 lhs = new Vector3(point.X, point.Y, 0.0f);
            Vector3 rhs = new Vector3(position.X, position.Y, 0.0f);

            return Distance(lhs, rhs);
        }

        public static float Distance(Vector3 position1, Vector3 position2) => (position1 - position2).Length();

        public static Vector3 Subtract(this Vector3 left, Vector3 right) => new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);

        public static Position ConvertToPosition(this Vector3 pos) =>  new Position { X = pos.X, Y=pos.Y, Z=pos.Z };

        public static Vector3 ConvertRotationToRadian(this Vector3 rot) 
        {
            if (rot.Z < 180.0)
                return new Vector3(0.0f, 0.0f, (float)(rot.Z * Math.PI / 180.0));
            else
                return new Vector3(0.0f, 0.0f, (float)((rot.Z - 360.0) / 180.0 * Math.PI));
        }

        public static Rotation ConvertToEntityRotation(this Vector3 pos) => new Rotation(pos.X, pos.Y, pos.Z );

        public static Vector3 ConvertToVector3(this Position pos) => new Vector3(pos.X, pos.Y, pos.Z);

        // public static Vector3Serialized ConvertToVector3Serialized(this Vector3 pos) => new Vector3Serialized(pos);

        /**
        * Function to get the distance of two given positions without Z position
        */
        public static double GetDistanceBetweenPosWithoutZ(Vector2 Position1, Vector2 Position2)
        {
            return Vector2.Distance(Position1, Position2);
        }

        /**
		 * Function to get the distance of two given positions including Z position
		 */
        public static double GetDistanceBetweenPos(Vector3 Position1, Vector3 Position2)
        {
            return Vector3.Distance(Position1, Position2);
        }

        /**
		 * Boolean-Function which gives true if the distance of two positions is smaller than an given distance, else false
		 */
        public static bool InDistanceBetweenPos(Vector3 Position1, Vector3 Position2, float Distance)
        {
            if (
                Position1.X - Position2.X > Distance ||
                Position1.Y - Position2.Y > Distance ||
                Position1.Z - Position2.Z > Distance ||
                Position1.X - Position2.X < (-1) * Distance ||
                Position1.Y - Position2.Y < (-1) * Distance ||
                Position1.Z - Position2.Z < (-1) * Distance
            ) return false;
            return GetDistanceBetweenPos(Position1, Position2) < Distance;
        }

        //Method to get the directional angle of two Vector3, also know as "gon"
        public static double directionalAngle(Vector3 vec1, Vector3 vec2)
        {
            if ((vec2.Y - vec1.Y) > 0 && (vec2.X - vec1.X) > 0) return radianToGon(Math.Atan((vec2.Y - vec1.Y) / (vec2.X - vec1.X)));
            if (
                (vec2.Y - vec1.Y) > 0 && (vec2.X - vec1.X) < 0 ||
                (vec2.Y - vec1.Y) < 0 && (vec2.X - vec1.X) < 0) return radianToGon(Math.Atan((vec2.Y - vec1.Y) / (vec2.X - vec1.X))) + 200;
            if ((vec2.Y - vec1.Y) < 0 && (vec2.X - vec1.X) > 0) return radianToGon(Math.Atan((vec2.Y - vec1.Y) / (vec2.X - vec1.X))) + 400;
            return radianToGon(Math.Atan((vec2.Y - vec1.Y) / (vec2.X - vec1.X)));
        }

        //Transform radian to gon
        public static float radianToGon(double radian)
        {
            return (float)radian * (200 / (float)Math.PI);
        }
    }
}
