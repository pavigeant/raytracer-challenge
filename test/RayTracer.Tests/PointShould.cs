using Xunit;

namespace RayTracer.Tests
{
    public class PointShould
    {
        [Fact]
        [UnitTest]
        public void GiveAPointWhenAddingAVectorFromAPoint()
        {
            var p = new Point(3, 2, 1);
            var v = new Vector(5, 6, 7);
            var expected = new Point(8, 8, 8);

            var actual = p + v;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void GiveAPointWhenSubstractingAVectorFromAPoint()
        {
            var p = new Point(3, 2, 1);
            var v = new Vector(5, 6, 7);
            var expected = new Point(-2, -4, -6);

            var actual = p - v;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void GiveAVectorWhenTwoPointsAreSubstracted()
        {
            var p1 = new Point(3, 2, 1);
            var p2 = new Point(5, 6, 7);

            var expected = new Vector(-2, -4, -6);

            var actual = p1 - p2;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void BeNegatable()
        {
            var t = new Point(1, -2, 3);
            var expected = new Point(-1, 2, -3);

            var actual = -t;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void BeMultipliedByAScalar()
        {
            var t = new Point(1, -2, 3);
            var expected = new Point(3.5, -7, 10.5);

            var actual = t * 3.5;
            Assert.Equal(expected, actual);

            actual = 3.5 * t;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void BeDividedByAScalar()
        {
            var t = new Point(1, -2, 3);
            var expected = new Point(0.5, -1, 1.5);

            var actual = t / 2;
            Assert.Equal(expected, actual);
        }
    }
}