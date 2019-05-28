using System;

namespace RayTracer.Challenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var projectile = new Projectile(new Point(0, 100, 0), new Vector(0, 0, 0));
            var environment = new Environment(new Vector(0, -9.8, 0), new Vector(0, 0, 0));

            while ((projectile = Tick(environment, projectile)).Position.Y > 0)
            {
                Console.WriteLine(projectile.Position);
            }
        }

        private static Projectile Tick(Environment env, Projectile proj)
        {
            var position = proj.Position + proj.Velocity;
            var velocity = proj.Velocity + env.Gravity + env.Wind;

            return new Projectile(position, velocity);
        }
    }
}