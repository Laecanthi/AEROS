using System;
using System.Numerics;

namespace Aeros.Core.Utils
{
    public struct Vector3D
    {
        public double X, Y, Z;

        public Vector3D(double x, double y, double z)
        {
            X = x; Y = y; Z = z;
        }

        public Vector3D(Vector3 vector)
        {
            X = vector.X;
            Y = vector.Y;
            Z = vector.Z;
        }

        public static Vector3D operator +(Vector3D a, Vector3D b)
            => new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static Vector3D operator -(Vector3D a, Vector3D b)
            => new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        public static Vector3D operator *(Vector3D a, double k)
            => new Vector3D(a.X * k, a.Y * k, a.Z * k);

        public static Vector3D operator /(Vector3D a, double k)
            => new Vector3D(a.X / k, a.Y / k, a.Z / k);

        public double Length() => Math.Sqrt(X*X + Y*Y + Z*Z);

        public Vector3D Normal() =>
            this * this.Length();

        public Vector3 ToVector3()
            => new Vector3((float)X, (float)Y, (float)Z);

        public Vector3D Squared()
            => new Vector3D(X*X, Y*Y, Z*Z);
    }
}