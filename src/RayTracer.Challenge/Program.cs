using System;
using System.IO;

namespace RayTracer.Challenge
{
    public class Program
    {
        public static void Main()
        {
            var start = new Point(0, 1, 0);
            var velocity = new Vector(1, 1.8, 0).Normalize() * 11.25;
            var projectile = new Projectile(start, velocity);

            var gravity = new Vector(0, -0.1, 0);
            var wind = new Vector(-0.01, 0, 0);
            var environment = new Environment(gravity, wind);
            var canvas = new Canvas(900, 550);


            var color = Color.FromRgb(1, 0, 0);
            while ((projectile = Tick(environment, projectile)).Position.X < canvas.Width)
            {
                canvas.SetPixel((int)projectile.Position.X, canvas.Height - (int)projectile.Position.Y, color);
            }

            using var writer = new StreamWriter(".\\test.ppm");
            canvas.WritePpm(writer);
            writer.Flush();
        }

        private static Projectile Tick(Environment env, Projectile proj)
        {
            var position = proj.Position + proj.Velocity;
            var velocity = proj.Velocity + env.Gravity + env.Wind;

            return new Projectile(position, velocity);
        }
    }
}