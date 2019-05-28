namespace RayTracer
{
    public static class TypeHelper
    {
        public static int GetTupleHashCode(this (double a, double b, double c) tuple)
        {
            var result = 17;
            result = result * 31 + tuple.a.GetHashCode();
            result = result * 31 + tuple.b.GetHashCode();
            result = result * 31 + tuple.c.GetHashCode();
            return result;
        }
    }
}