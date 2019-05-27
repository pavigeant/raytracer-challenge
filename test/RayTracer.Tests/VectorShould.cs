using System;
using Xunit;

namespace RayTracer.Tests
{
    public class VectorShould
    {
        [Fact]
        [UnitTest]
        public void GiveAVectorWhenAddingTwoVectors()
        {
            var v1 = new Vector(3, -2, 5);
            var v2 = new Vector(-2, 3, 1);

            var expected = new Vector(1, 1, 6);

            var actual = v1 + v2;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void GiveAVectorWhenSubstractingTwoVectors()
        {
            var v = new Vector(1, -2, 3);
            var expected = new Vector(-1, 2, -3);

            var actual = Vector.Zero() - v;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void BeNegatable()
        {
            var v = new Vector(1, -2, 3);
            var expected = new Vector(-1, 2, -3);

            var actual = -v;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void BeMultipliedByAScalar()
        {
            var v = new Vector(1, -2, 3);
            var expected = new Vector(3.5, -7, 10.5);

            var actual = v * 3.5;
            Assert.Equal(expected, actual);

            actual = 3.5 * v;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void BeDividedByAScalar()
        {
            var v = new Vector(1, -2, 3);
            var expected = new Vector(0.5, -1, 1.5);

            var actual = v / 2;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void BeAbleToGetAMagnitude()
        {
            Assert.Equal(1, new Vector(1, 0, 0).Magnitude());
            Assert.Equal(1, new Vector(0, 1, 0).Magnitude());
            Assert.Equal(1, new Vector(0, 0, 1).Magnitude());

            Assert.Equal(Math.Sqrt(14), new Vector(1, 2, 3).Magnitude());
            Assert.Equal(Math.Sqrt(14), new Vector(-1, -2, -3).Magnitude());
        }

        [Fact]
        [UnitTest]
        public void BeAbleToBeNormalized()
        {
            Assert.Equal(new Vector(1, 0, 0), new Vector(4, 0, 0).Normalize());
            Assert.Equal(new Vector(1 / Math.Sqrt(14), 2 / Math.Sqrt(14), 3 / Math.Sqrt(14)), new Vector(1, 2, 3).Normalize());
            Assert.Equal(1, new Vector(1, 2, 3).Normalize().Magnitude());
        }

        [Fact]
        [UnitTest]
        public void BeAbleToHaveADotProduct()
        {
            var a = new Vector(1, 2, 3);
            var b = new Vector(2, 3, 4);

            Assert.Equal(20, a.Dot(b));
        }

        [Fact]
        [UnitTest]
        public void BeAbleToHaveACrossProduct()
        {
            var a = new Vector(1, 2, 3);
            var b = new Vector(2, 3, 4);

            Assert.Equal(new Vector(-1, 2, -1), a.Cross(b));
            Assert.Equal(new Vector(1, -2, 1), b.Cross(a));
        }
    }
}