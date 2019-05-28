namespace RayTracer
{
    /// <summary>
    /// Represents a point in a 3D world where the origin is located at (0, 0, 0).
    /// </summary>
    public class Point
    {
        public Point(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// The position of the point on the X axis relative to the origin.
        /// </summary>
        public double X { get; }

        /// <summary>
        /// The position of the point on the Y axis relative to the origin.
        /// </summary>
        public double Y { get; }

        /// <summary>
        /// The position of the point on the Z axis relative to the origin.
        /// </summary>
        public double Z { get; }

        /// <summary>
        /// Converts the point into a string representation using the format (x, y, z).
        /// </summary>
        public override string ToString() => $"({X}, {Y}, {Z})";

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var p = (Point)obj;
            return (X == p.X) && (Y == p.Y) && (Z == p.Z);
        }

        public override int GetHashCode() => (X, Y, Z).GetTupleHashCode();

        /// <summary>
        /// Moves the point in by the size and direction of the vector.
        /// </summary>
        public static Point operator +(Point p, Vector v) => new Point(p.X + v.X, p.Y + v.Y, p.Z + v.Z);

        /// <summary>
        /// Creates a vector from point 2 to point 1.
        /// </summary>
        public static Vector operator -(Point p1, Point p2) => new Vector(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);

        /// <summary>
        /// Moves the point by the size but opposite direction of the vector.
        /// </summary>
        public static Point operator -(Point p, Vector v) => p + -v;

        /// <summary>
        /// Negates a point.
        /// </summary>
        public static Point operator -(Point p) => new Point(-p.X, -p.Y, -p.Z);

        /// <summary>
        /// Moves the points by the factor provided.
        /// </summary>
        public static Point operator *(Point p, double factor) => new Point(p.X * factor, p.Y * factor, p.Z * factor);

        /// <summary>
        /// Moves the points by the factor provided.
        /// </summary>
        public static Point operator *(double factor, Point p) => p * factor;

        /// <summary>
        /// Moves the points by the factor provided.
        /// </summary>
        public static Point operator /(Point p, double factor) => p * (1 / factor);

        /// <summary>
        /// Returns the point at origin.
        /// </summary>
        public static Point Zero() => new Point(0, 0, 0);
    }
}