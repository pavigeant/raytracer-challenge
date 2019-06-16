using System;

namespace RayTracer
{
    /// <summary>
    /// Represents a vector in a 3D world.
    /// </summary>
    public struct Vector : IEquatable<Vector>
    {
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// The size of the vector on the y-z plane.
        /// </summary>
        public double X { get; }

        /// <summary>
        /// The size of the vector on the x-z plane.
        /// </summary>
        public double Y { get; }

        /// <summary>
        /// The size of the vector on the x-y plane.
        /// </summary>
        public double Z { get; }

        /// <summary>
        /// Converts the vector into a string representation using the format [x, y, z].
        /// </summary>
        public override string ToString() => $"[{X}, {Y}, {Z}]";

        public override int GetHashCode() => TypeHelper.GetHashCode(X, Y, Z);

        public bool Equals(Vector other) =>
            X.ApproximatelyEqual(other.X) && Y.ApproximatelyEqual(other.Y) && Z.ApproximatelyEqual(other.Z);

        public override bool Equals(object obj) =>
            obj is Vector other && Equals(other);

        public static bool operator ==(Vector left, Vector right) => left.Equals(right);

        public static bool operator !=(Vector left, Vector right) => !left.Equals(right);

        /// <summary>
        /// Returns the length, called the magnitude, of the vector.
        /// </summary>
        public double Magnitude() => Math.Sqrt(X * X + Y * Y + Z * Z);

        /// <summary>
        /// Returns a new vector that is the unit vector of this vector. A unit vector is represented by [ai, bj, ck]where i, j and k are the unit component.
        /// </summary>
        public Vector Normalize()
        {
            var m = Magnitude();
            return new Vector(X / m, Y / m, Z / m);
        }

        /// <summary>
        /// Calculates the Dot product between this vector and the given one.
        /// </summary>
        public double Dot(Vector v) => X * v.X + Y * v.Y + Z * v.Z;

        /// <summary>
        /// Calculates the Cross vector of this vector and the given one.
        /// </summary>
        public Vector Cross(Vector v)
        {
            return new Vector(
                Y * v.Z - Z * v.Y,
                Z * v.X - X * v.Z,
                X * v.Y - Y * v.X);
        }

        /// <summary>
        /// Creates a new vector that combine the two given vectors. 
        /// </summary>
        public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);

        /// <summary>
        /// Creates a new vector that combine the first vector with the opposite of the second vector.
        /// </summary>
        public static Vector operator -(Vector v1, Vector v2) => new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);

        /// <summary>
        /// Returns the opposite of the vector.
        /// </summary>
        public static Vector operator -(Vector t) => new Vector(-t.X, -t.Y, -t.Z);

        /// <summary>
        /// Increases the size of the vector by the given factor.
        /// </summary>
        public static Vector operator *(Vector v, double factor) => new Vector(v.X * factor, v.Y * factor, v.Z * factor);

        /// <summary>
        /// Increases the size of the vector by the given factor.
        /// </summary>
        public static Vector operator *(double factor, Vector v) => v * factor;

        /// <summary>
        /// Reduces the size of the vector by the given factor.
        /// </summary>
        public static Vector operator /(Vector v, double factor) => v * (1 / factor);

        /// <summary>
        /// Returns a vector with a magnitude of 0.
        /// </summary>
        public static Vector Zero() => new Vector(0, 0, 0);
    }
}