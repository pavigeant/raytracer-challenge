using System;

namespace RayTracer
{
    /// <summary>
    /// Represents a color of a point based on the three channels of red, green and blue.
    /// </summary>
    public class Color
    {
        public Color(double r, double g, double b)
        {
            R = r;
            G = g;
            B = b;
        }

        /// <summary>
        /// Represetns the value on the red channel of this color.
        /// </summary>
        public double R { get; }

        /// <summary>
        /// Represetns the value on the green channel of this color.
        /// </summary>
        public double G { get; }

        /// <summary>
        /// Represetns the value on the blue channel of this color.
        /// </summary>
        public double B { get; }

        /// <summary>
        /// Converts the point into a string representation using the format (R, G, B).
        /// </summary>
        public override string ToString() => $"Color [R={R}, G={G}, B={B}]";

        public override bool Equals(object obj) =>
            obj is Color c && R.ApproximatelyEqual(c.R) && G.ApproximatelyEqual(c.G) && B.ApproximatelyEqual(c.B);

        public override int GetHashCode() => (R, G, B).GetTupleHashCode();

        /// <summary>
        /// Creates a new color that is the addition of the two colors' channels. 
        /// </summary>
        public static Color operator +(Color c1, Color c2) => new Color(c1.R + c2.R, c1.G + c2.G, c1.B + c2.B);

        /// <summary>
        /// Creates a new color that substract the second color to the first color.
        /// </summary>
        public static Color operator -(Color c1, Color c2) => new Color(c1.R - c2.R, c1.G - c2.G, c1.B - c2.B);

        /// <summary>
        /// Creates a new color that substract the second color to the first color.
        /// </summary>
        public static Color operator -(Color c) => new Color(-c.R, -c.G, c.B);

        /// <summary>
        /// Moves the points by the factor provided.
        /// </summary>
        public static Color operator *(Color p, double factor) => new Color(p.R * factor, p.G * factor, p.B * factor);

        /// <summary>
        /// Moves the points by the factor provided.
        /// </summary>
        public static Color operator *(double factor, Color p) => p * factor;

        /// <summary>
        /// Moves the points by the factor provided.
        /// </summary>
        public static Color operator /(Color p, double factor) => p * (1 / factor);
    }
}