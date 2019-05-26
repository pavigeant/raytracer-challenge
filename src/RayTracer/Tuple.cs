using System;

namespace RayTracer
{
    public sealed class Tuple
    {
        private readonly int _hashCode;

        public Tuple(double x, double y, double z, double w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;

            Type = w switch
            {
                0 => TupleType.Vector,
                1 => TupleType.Point,
                _ => TupleType.Unknown
            };

            _hashCode = ComputeHashCode();
        }

        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public double W { get; private set; }
        public TupleType Type { get; private set; }

        private int ComputeHashCode()
        {
            var result = 17;
            result = result * 31 + X.GetHashCode();
            result = result * 31 + Y.GetHashCode();
            result = result * 31 + Z.GetHashCode();
            result = result * 31 + W.GetHashCode();
            return result;
        }

        public override string ToString()
        {
            if (Type == TupleType.Point)
                return $"({X}, {Y}, {Z})";
            if (Type == TupleType.Vector)
                return $"[{X}, {Y}, {Z}]";

            return $"Unknown (x:{X}, y:{Y}, z:{Z}, w:{W})";
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var t = (Tuple)obj;
            return (X == t.X) && (Y == t.Y) && (Z == t.Z) && (W == t.W);
        }

        public double Magnitude() => Math.Sqrt(X * X + Y * Y + Z * Z + W * W);

        public Tuple Normalize()
        {
            var m = Magnitude();
            return new Tuple(X / m, Y / m, Z / m, W / m);
        }

        public double Dot(Tuple t) => X * t.X + Y * t.Y + Z * t.Z + W * t.W;

        public Tuple Cross(Tuple t)
        {
            if (Type != TupleType.Vector || t.Type != TupleType.Vector)
                throw new ArithmeticException("Cross operation can only be applied on vectors");

            return Vector(
                Y * t.Z - Z * t.Y,
                Z * t.X - X * t.Z,
                X * t.Y - Y * t.X);
        }

        public override int GetHashCode() => _hashCode;

        public static Tuple operator +(Tuple t1, Tuple t2) => new Tuple(t1.X + t2.X, t1.Y + t2.Y, t1.Z + t2.Z, t1.W + t2.W);

        public static Tuple operator -(Tuple t1, Tuple t2) => new Tuple(t1.X - t2.X, t1.Y - t2.Y, t1.Z - t2.Z, t1.W - t2.W);

        public static Tuple operator -(Tuple t) => new Tuple(-t.X, -t.Y, -t.Z, -t.W);

        public static Tuple operator *(Tuple t, double factor) => new Tuple(t.X * factor, t.Y * factor, t.Z * factor, t.W * factor);

        public static Tuple operator *(double factor, Tuple t) => t * factor;

        public static Tuple operator /(Tuple t, double factor) => t * (1 / factor);

        public static Tuple Vector(double x, double y, double z) => new Tuple(x, y, z, 0);

        public static Tuple Point(double x, double y, double z) => new Tuple(x, y, z, 1);

        public static Tuple ZeroPoint() => Point(0, 0, 0);

        public static Tuple ZeroVector() => Vector(0, 0, 0);
    }
}