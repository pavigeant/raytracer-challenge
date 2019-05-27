namespace RayTracer
{
    public class Environment
    {
        public Environment(Vector gravity, Vector wind)
        {
            Gravity = gravity;
            Wind = wind;
        }

        public Vector Gravity { get; }
        public Vector Wind { get; }
    }
}