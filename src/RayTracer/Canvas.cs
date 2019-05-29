using System;
using System.IO;
using System.Text;

namespace RayTracer
{
    public class Canvas
    {
        public Canvas(int width, int height)
        {
            Width = width;
            Height = height;

            _pixels = new Color[Width, Height];
        }

        public int Width { get; }
        public int Height { get; }

        private readonly Color[,] _pixels;

        public void SetPixel(int x, int y, Color color)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height) return;

            _pixels[x, y] = color;
        }

        public Color GetPixel(int x, int y) => _pixels[x, y];

        public void WritePpm(TextWriter writer)
        {
            // Write the header
            writer.WriteLine("P3");
            writer.WriteLine($"{Width} {Height}");
            writer.WriteLine("255");

            var lineLength = 0;
            for (int h = 0; h < Height; h++)
            {
                for (int w = 0; w < Width; w++)
                {
                    foreach (var channel in _pixels[w, h].Channels)
                    {
                        var scaled = (int)Math.Round(channel * 255);
                        if (scaled > 255)
                            scaled = 255;
                        if (scaled < 0)
                            scaled = 0;

                        var length = GetDigitCount(scaled);
                        if (lineLength > 0)
                            length += 1; // add the separator space between the previous channel value and this one

                        if (lineLength + length > 70)
                        {
                            lineLength = 0;
                            writer.WriteLine();
                        }
                        else if (lineLength > 0)
                        {
                            writer.Write(' ');
                        }

                        lineLength += length;
                        writer.Write(scaled);
                    }
                }

                lineLength = 0;
                writer.WriteLine();
            }
        }

        private int GetDigitCount(int scaled)
        {
            if (scaled <= 9) return 1;
            if (scaled <= 99) return 2;
            return 3;
        }

        public string ToPpm()
        {
            var sb = new StringBuilder();
            using var writer = new StringWriter(sb);

            WritePpm(writer);

            return sb.ToString();
        }

        public void Fill(Color color)
        {
            for (int h = 0; h < Height; h++)
            {
                for (int w = 0; w < Width; w++)
                {
                    SetPixel(w, h, color);
                }
            }
        }
    }
}