using System;
using System.Collections.Generic;

namespace RayTracer
{
    /// <summary>
    /// Represents a color of a point based on the three channels of red, green and blue.
    /// </summary>
    public struct Color
    {
        private Color(double r, double g, double b)
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

        public double[] Channels => new double[] { R, G, B };

        /// <summary>
        /// Converts the point into a string representation using the format (R, G, B).
        /// </summary>
        public override string ToString() => $"Color [R={R}, G={G}, B={B}]";

        public override bool Equals(object obj) =>
            obj is Color c && R.ApproximatelyEqual(c.R) && G.ApproximatelyEqual(c.G) && B.ApproximatelyEqual(c.B);

        public override int GetHashCode() => (R, G, B).GetTupleHashCode();

        /// <summary>
        /// Creates a new color based on the reg, green and blue channels.
        /// </summary>
        public static Color FromRgb(double r, double g, double b) => new Color(r, g, b);

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
        /// Multiplies the color's channels by the specified factor.
        /// </summary>
        public static Color operator *(Color c, double factor) => new Color(c.R * factor, c.G * factor, c.B * factor);

        /// <summary>
        /// Multiplies the color's channels by the specified factor.
        /// </summary>
        public static Color operator *(double factor, Color c) => c * factor;

        /// <summary>
        /// Divides the color's channels by the specified factor.
        /// </summary>
        public static Color operator /(Color c, double factor) => c * (1 / factor);

        /// <summary>
        /// Multiplies two colors by multiplying their corresponding channels. Also called the Hadamard product.
        /// </summary>
        public static Color operator *(Color c1, Color c2) => new Color(c1.R * c2.R, c1.G * c2.G, c1.B * c2.B);
    }
}