namespace RayTracer
{
    public struct Point
    {
        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X { get; }
        public double Y { get; }
        public double Z { get; }

        public override string ToString() => $"({X}, {Y}, {Z})";

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var p = (Point)obj;
            return (X == p.X) && (Y == p.Y) && (Z == p.Z);
        }

        public override int GetHashCode()
        {
            var result = 17;
            result = result * 31 + X.GetHashCode();
            result = result * 31 + Y.GetHashCode();
            result = result * 31 + Z.GetHashCode();
            return result;
        }

        public static Point operator +(Point p, Vector v) => new Point(p.X + v.X, p.Y + v.Y, p.Z + v.Z);

        public static Vector operator -(Point p1, Point p2) => new Vector(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);

        public static Point operator -(Point p, Vector v) => p + -v;

        public static Point operator -(Point t) => new Point(-t.X, -t.Y, -t.Z);

        public static Point operator *(Point t, double factor) => new Point(t.X * factor, t.Y * factor, t.Z * factor);

        public static Point operator *(double factor, Point p) => p * factor;

        public static Point operator /(Point p, double factor) => p * (1 / factor);

        public static Point Zero() => new Point(0, 0, 0);
    }
}