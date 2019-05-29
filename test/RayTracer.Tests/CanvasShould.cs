using Xunit;

namespace RayTracer.Tests
{
    public class CanvasShould
    {
        [Fact]
        [UnitTest]
        public void InitializeToAllBlack()
        {
            var black = Color.FromRgb(0, 0, 0);
            var canvas = new Canvas(10, 20);

            Assert.Equal(10, canvas.Width);
            Assert.Equal(20, canvas.Height);

            for (var x = 0; x < canvas.Width; x++)
            {
                for (var y = 0; y < canvas.Height; y++)
                {
                    Assert.Equal(black, canvas.GetPixel(x, y));
                }
            }
        }

        [Fact]
        [UnitTest]
        public void SupportChangingAPixel()
        {
            var red = Color.FromRgb(1, 0, 0);
            var canvas = new Canvas(10, 20);

            canvas.SetPixel(5, 5, red);

            Assert.Equal(red, canvas.GetPixel(5, 5));
        }

        [Fact]
        [UnitTest]
        public void ConstructAProperPpmHeader()
        {
            var canvas = new Canvas(5, 3);
            var ppm = canvas.ToPpm();
            var lines = ppm.Split(System.Environment.NewLine);

            Assert.Equal("P3", lines[0]);
            Assert.Equal("5 3", lines[1]);
            Assert.Equal("255", lines[2]);
        }

        [Fact]
        [UnitTest]
        public void ConstructAProperPpmPixelData()
        {
            var canvas = new Canvas(5, 3);
            canvas.SetPixel(0, 0, Color.FromRgb(1.5, 0, 0));
            canvas.SetPixel(2, 1, Color.FromRgb(0, 0.5, 0));
            canvas.SetPixel(4, 2, Color.FromRgb(-0.5, 0, 1));

            var ppm = canvas.ToPpm();
            var lines = ppm.Split(System.Environment.NewLine);

            Assert.Equal("255 0 0 0 0 0 0 0 0 0 0 0 0 0 0", lines[3]);
            Assert.Equal("0 0 0 0 0 0 0 128 0 0 0 0 0 0 0", lines[4]);
            Assert.Equal("0 0 0 0 0 0 0 0 0 0 0 0 0 0 255", lines[5]);
        }

        [Fact]
        [UnitTest]
        public void HavePpmPixelDataLineNoLongerThan70Characters()
        {
            var canvas = new Canvas(10, 2);
            canvas.Fill(Color.FromRgb(1, 0.8, 0.6));

            var ppm = canvas.ToPpm();
            var lines = ppm.Split(System.Environment.NewLine);

            Assert.Equal("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204", lines[3]);
            Assert.Equal("153 255 204 153 255 204 153 255 204 153 255 204 153", lines[4]);
            Assert.Equal("255 204 153 255 204 153 255 204 153 255 204 153 255 204 153 255 204", lines[5]);
            Assert.Equal("153 255 204 153 255 204 153 255 204 153 255 204 153", lines[6]);
        }

        [Fact]
        [UnitTest]
        public void HavePpmFileTerminatedByANewLine()
        {
            var canvas = new Canvas(5, 3);
            var ppm = canvas.ToPpm();

            Assert.EndsWith(System.Environment.NewLine, ppm);
        }
    }
}