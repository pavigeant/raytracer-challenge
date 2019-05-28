using Xunit;

namespace RayTracer.Tests
{
    public class ColorShould
    {
        [Fact]
        [UnitTest]
        public void BeRedGreenBlueTuple()
        {
            var c = new Color(-0.5, 0.4, 1.7);

            Assert.Equal(-0.5, c.R);
            Assert.Equal(0.4, c.G);
            Assert.Equal(1.7, c.B);
        }

        [Fact]
        [UnitTest]
        public void BeAdditive()
        {
            var c1 = new Color(0.9, 0.6, 0.75);
            var c2 = new Color(0.7, 0.1, 0.25);

            var expected = new Color(1.6, 0.7, 1.0);
            var actual = c1 + c2;

            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void BeSubstractive()
        {
            var c1 = new Color(0.9, 0.6, 0.75);
            var c2 = new Color(0.7, 0.1, 0.25);

            var expected = new Color(0.2, 0.5, 0.5);
            var actual = c1 - c2;

            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void BeMultipliedByAScalar()
        {
            var c = new Color(0.2, 0.3, 0.4);

            var expected = new Color(0.4, 0.6, 0.8);
            var actual = c * 2;
            Assert.Equal(expected, actual);

            actual = 2 * c;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void BeDividedByAScalar()
        {
            var c = new Color(0.2, 0.3, 0.4);

            var expected = new Color(0.1, 0.15, 0.2);
            var actual = c / 2;

            Assert.Equal(expected, actual);
        }
    }
}