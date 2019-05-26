using System;
using Xunit;

namespace RayTracer.Tests
{
    public class TupleShould
    {
        [Fact]
        [UnitTest]
        public void BeAPointWhenWIsOne()
        {
            var tuple = new Tuple(4.3, -4.2, 3.1, 1.0);

            Assert.Equal(4.3, tuple.X);
            Assert.Equal(-4.2, tuple.Y);
            Assert.Equal(3.1, tuple.Z);
            Assert.Equal(1, tuple.W);

            Assert.Equal(TupleType.Point, tuple.Type);
        }

        [Fact]
        [UnitTest]
        public void BeAVectorWhenWIsZero()
        {
            var tuple = new Tuple(4.3, -4.2, 3.1, 0.0);

            Assert.Equal(4.3, tuple.X);
            Assert.Equal(-4.2, tuple.Y);
            Assert.Equal(3.1, tuple.Z);
            Assert.Equal(0, tuple.W);

            Assert.Equal(TupleType.Vector, tuple.Type);
        }

        [Fact]
        [UnitTest]
        public void BeAVectorWhenVectorHelperIsUsed()
        {
            var tuple = Tuple.Vector(4.3, -4.2, 3.1);
            Assert.Equal(TupleType.Vector, tuple.Type);
        }

        [Fact]
        [UnitTest]
        public void BeAPointWhenPointHelperIsUsed()
        {
            var tuple = Tuple.Point(4.3, -4.2, 3.1);
            Assert.Equal(TupleType.Point, tuple.Type);
        }

        [Fact]
        [UnitTest]
        public void BeAdditive()
        {
            var t1 = new Tuple(3, -2, 5, 1);
            var t2 = new Tuple(-2, 3, 1, 0);

            var expected = new Tuple(1, 1, 6, 1);

            var actual = t1 + t2;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void GiveAVectorWhenTwoPointsAreSubstracted()
        {
            var p1 = Tuple.Point(3, 2, 1);
            var p2 = Tuple.Point(5, 6, 7);

            var expected = Tuple.Vector(-2, -4, -6);

            var actual = p1 - p2;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void GiveAPointWhenSubstractingAVectorFromAPoint()
        {
            var p = Tuple.Point(3, 2, 1);
            var v = Tuple.Vector(5, 6, 7);

            var expected = Tuple.Point(-2, -4, -6);

            var actual = p - v;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void GiveAVectorWhenSubstractingTwoVectors()
        {
            var v = Tuple.Vector(1, -2, 3);

            var expected = Tuple.Vector(-1, 2, -3);

            var actual = Tuple.ZeroVector() - v;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void BeNegatable()
        {
            var t = new Tuple(1, -2, 3, -4);
            var expected = new Tuple(-1, 2, -3, 4);

            var actual = -t;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void BeMultipliedByAScalar()
        {
            var t = new Tuple(1, -2, 3, -4);
            var expected = new Tuple(3.5, -7, 10.5, -14);

            var actual = t * 3.5;
            Assert.Equal(expected, actual);

            actual = 3.5 * t;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void BeDividedByAScalar()
        {
            var t = new Tuple(1, -2, 3, -4);
            var expected = new Tuple(0.5, -1, 1.5, -2);

            var actual = t / 2;
            Assert.Equal(expected, actual);
        }

        [Fact]
        [UnitTest]
        public void BeAbleToGetAMagnitude()
        {
            Assert.Equal(1, Tuple.Vector(1, 0, 0).Magnitude());
            Assert.Equal(1, Tuple.Vector(0, 1, 0).Magnitude());
            Assert.Equal(1, Tuple.Vector(0, 0, 1).Magnitude());

            Assert.Equal(Math.Sqrt(14), Tuple.Vector(1, 2, 3).Magnitude());
            Assert.Equal(Math.Sqrt(14), Tuple.Vector(-1, -2, -3).Magnitude());
        }

        [Fact]
        [UnitTest]
        public void BeAbleToBeNormalized()
        {
            Assert.Equal(Tuple.Vector(1, 0, 0), Tuple.Vector(4, 0, 0).Normalize());
            Assert.Equal(Tuple.Vector(1 / Math.Sqrt(14), 2 / Math.Sqrt(14), 3 / Math.Sqrt(14)), Tuple.Vector(1, 2, 3).Normalize());
            Assert.Equal(1, Tuple.Vector(1, 2, 3).Normalize().Magnitude());
        }

        [Fact]
        [UnitTest]
        public void BeAbleToHaveADotProduct()
        {
            var a = Tuple.Vector(1, 2, 3);
            var b = Tuple.Vector(2, 3, 4);

            Assert.Equal(20, a.Dot(b));
        }

        [Fact]
        [UnitTest]
        public void BeAbleToHaveACrossProduct()
        {
            var a = Tuple.Vector(1, 2, 3);
            var b = Tuple.Vector(2, 3, 4);

            Assert.Equal(Tuple.Vector(-1, 2, -1), a.Cross(b));
            Assert.Equal(Tuple.Vector(1, -2, 1), b.Cross(a));
        }

        [Fact]
        [UnitTest]
        public void OnlyVectorCanHaveACrossProduct()
        {
            Assert.Throws<ArithmeticException>(() => Tuple.ZeroVector().Cross(Tuple.ZeroPoint()));
            Assert.Throws<ArithmeticException>(() => Tuple.ZeroPoint().Cross(Tuple.ZeroVector()));
        }
    }
}