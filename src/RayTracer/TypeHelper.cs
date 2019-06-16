using System;

namespace RayTracer
{
    public static class TypeHelper
    {
        private const double Epsilon = 1E-15;

        public static int GetHashCode(params double[] array)
        {
            var result = 17;
            foreach (var item in array)
                result = result * 31 + item.GetHashCode();
            
            return result;
        }

        /// <summary>
        /// Compares if two double values are approximately equal based on the given epsilon.
        /// </summary>
        /// <see cref="https://stackoverflow.com/a/253874/151488"/>
        public static bool ApproximatelyEqual(this double a, double b, double epsilon = Epsilon) 
            => Math.Abs(a - b) <= ((Math.Abs(a) < Math.Abs(b) ? Math.Abs(b) : Math.Abs(a)) * epsilon);

        public static bool ApproximatelyEqual(this double a, double b, int precision)
            => Math.Round(a, precision) == Math.Round(b, precision);
    }
}