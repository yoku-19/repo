using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector3DStruct
{
    public struct Vector3D
    {
        private const double Epsilon = 1e-13;

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public double Length => Math.Sqrt(X * X + Y * Y + Z * Z);

        public Vector3D(double x, double y, double z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString() => $"({X}; {Y}; {Z})";

        public override bool Equals(object obj)
        {
            if (obj is Vector3D other)
                return Math.Abs(X - other.X) < Epsilon &&
                       Math.Abs(Y - other.Y) < Epsilon &&
                       Math.Abs(Z - other.Z) < Epsilon;

            throw new ArgumentException("Object is not a Vector3D");
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                const int p = 23;
                hash = hash * p + X.GetHashCode();
                hash = hash * p + Y.GetHashCode();
                hash = hash * p + Z.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Vector3D a, Vector3D b) => a.Equals(b);
        public static bool operator !=(Vector3D a, Vector3D b) => !a.Equals(b);

        public static Vector3D operator +(Vector3D a, Vector3D b)
            => new Vector3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static Vector3D operator -(Vector3D a, Vector3D b)
            => new Vector3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        public static Vector3D operator *(double lambda, Vector3D a)
            => new Vector3D(lambda * a.X, lambda * a.Y, lambda * a.Z);

        public static Vector3D operator *(Vector3D a, double lambda)
            => lambda * a;

        public static double Dot(Vector3D a, Vector3D b)
            => a.X * b.X + a.Y * b.Y + a.Z * b.Z;

        public static Vector3D operator ^(Vector3D a, Vector3D b)
            => new Vector3D(
                a.Y * b.Z - a.Z * b.Y,
                a.Z * b.X - a.X * b.Z,
                a.X * b.Y - a.Y * b.X);
    }
}
