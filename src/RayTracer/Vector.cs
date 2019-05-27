using System;

namespace RayTracer
{
    public struct Vector
    {
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public override string ToString() => $"[{X}, {Y}, {Z}]";

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var v = (Vector)obj;
            return (X == v.X) && (Y == v.Y) && (Z == v.Z);
        }

        public override int GetHashCode()
        {
            var result = 17;
            result = result * 31 + X.GetHashCode();
            result = result * 31 + Y.GetHashCode();
            result = result * 31 + Z.GetHashCode();
            return result;
        }

        public double Magnitude() => Math.Sqrt(X * X + Y * Y + Z * Z);

        public Vector Normalize()
        {
            var m = Magnitude();
            return new Vector(X / m, Y / m, Z / m);
        }

        public double Dot(Vector t) => X * t.X + Y * t.Y + Z * t.Z;

        public Vector Cross(Vector t)
        {
            return new Vector(
                Y * t.Z - Z * t.Y,
                Z * t.X - X * t.Z,
                X * t.Y - Y * t.X);
        }


        public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

        public static Vector operator -(Vector v1, Vector v2) => v1 + -v2;

        public static Vector operator -(Vector t) => new Vector(-t.X, -t.Y, -t.Z);

        public static Vector operator *(Vector t, double factor) => new Vector(t.X * factor, t.Y * factor, t.Z * factor);

        public static Vector operator *(double factor, Vector p) => p * factor;

        public static Vector operator /(Vector p, double factor) => p * (1 / factor);

        public static Vector Zero() => new Vector(0, 0, 0);
    }
}