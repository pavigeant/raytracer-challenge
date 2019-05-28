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
        public override string ToString() => $"({R}, {G}, {B})";

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var c = (Color)obj;
            return (R == c.R) && (G == c.G) && (B == c.B);
        }

        public override int GetHashCode() => (R, G, B).GetTupleHashCode();
    }
}