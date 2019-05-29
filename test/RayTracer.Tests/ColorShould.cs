using Xunit;

namespace RayTracer.Tests
{
    public class ColorShould
    {
        [Fact]
        [UnitTest]
        public void BeRedGreenBlueTuple()
        {
            var c = Color.FromRgb(-0.5, 0.4, 1.7);

            Assert.Equal(-0.5, c.R);
            Assert.Equal(0.4, c.G);
            Assert.Equal(1.7, c.B);
        }

        [Fact]
        [UnitTest]
        public void BeAdditive()
        {
            var c1 = Color.FromRgb(0.9, 0.6, 0.75);
            var c2 = Color.FromRgb(0.7, 0.1, 0.25);

            var expected = Color.FromRgb(1.6, 0.7, 1.0);
            var actual = c1 + c2;

            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void BeSubstractive()
        {
            var c1 = Color.FromRgb(0.9, 0.6, 0.75);
            var c2 = Color.FromRgb(0.7, 0.1, 0.25);

            var expected = Color.FromRgb(0.2, 0.5, 0.5);
            var actual = c1 - c2;

            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void BeMultipliedByAScalar()
        {
            var c = Color.FromRgb(0.2, 0.3, 0.4);

            var expected = Color.FromRgb(0.4, 0.6, 0.8);
            var actual = c * 2;
            Assert.Equal(expected, actual);

            actual = 2 * c;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void BeDividedByAScalar()
        {
            var c = Color.FromRgb(0.2, 0.3, 0.4);

            var expected = Color.FromRgb(0.1, 0.15, 0.2);
            var actual = c / 2;

            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void ByMultipliedByAnotherColor()
        {
            var c1 = Color.FromRgb(1, 0.2, 0.4);
            var c2 = Color.FromRgb(0.9, 1, 0.1);

            var expected = Color.FromRgb(0.9, 0.2, 0.04);
            var actual = c1 * c2;

            Assert.Equal(expected, actual);
        }
    }
}