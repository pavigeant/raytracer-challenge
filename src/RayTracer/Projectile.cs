namespace RayTracer
{
    public class Projectile
    {
        public Projectile(Point position, Vector velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        public Point Position { get; }
        public Vector Velocity { get; }
    }
}