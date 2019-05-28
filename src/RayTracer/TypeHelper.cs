using System;

namespace RayTracer
{
    public static class TypeHelper
    {
        private const double Epsilon = 1E-15;

        public static int GetTupleHashCode(this (double a, double b, double c) tuple)
        {
            var result = 17;
            result = result * 31 + tuple.a.GetHashCode();
            result = result * 31 + tuple.b.GetHashCode();
            result = result * 31 + tuple.c.GetHashCode();
            return result;
        }

        /// <summary>
        /// Compares if two double values are approximately equal based on the given epsilon.
        /// </summary>
        /// <see cref="https://stackoverflow.com/a/253874/151488"/>
        public static bool ApproximatelyEqual(this double a, double b, double epsilon = Epsilon) 
            => Math.Abs(a - b) <= ((Math.Abs(a) < Math.Abs(b) ? Math.Abs(b) : Math.Abs(a)) * epsilon);
    }
}