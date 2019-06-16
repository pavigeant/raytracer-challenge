using System;
using Xunit;

namespace RayTracer.Tests
{
    public class MatrixShould
    {
        [Fact]
        [UnitTest]
        public void BeAbleToCreateA4x4()
        {
            var m = Matrix.Create(new double[,]
            {
                { 1, 2, 3, 4 },
                { 5.5, 6.5, 7.5, 8.5 },
                { 9, 10, 11, 12 },
                { 13.5, 14.5, 15.5, 16.5}
            });

            Assert.Equal(1, m[0, 0]);
            Assert.Equal(2, m[0, 1]);
            Assert.Equal(3, m[0, 2]);
            Assert.Equal(4, m[0, 3]);
            Assert.Equal(5.5, m[1, 0]);
            Assert.Equal(6.5, m[1, 1]);
            Assert.Equal(7.5, m[1, 2]);
            Assert.Equal(8.5, m[1, 3]);
            Assert.Equal(9, m[2, 0]);
            Assert.Equal(10, m[2, 1]);
            Assert.Equal(11, m[2, 2]);
            Assert.Equal(12, m[2, 3]);
            Assert.Equal(13.5, m[3, 0]);
            Assert.Equal(14.5, m[3, 1]);
            Assert.Equal(15.5, m[3, 2]);
            Assert.Equal(16.5, m[3, 3]);
        }

        [Fact]
        [UnitTest]
        public void BeEquatable()
        {
            var m1 = Matrix.Create(new double[,]
            {
                { 1, 2, 3, 4 },
                { 5.5, 6.5, 7.5, 8.5 },
                { 9, 10, 11, 12 },
                { 13.5, 14.5, 15.5, 16.5 }
            });

            var m2 = Matrix.Create(new double[,]
            {
                { 1, 2, 3, 4 },
                { 5.5, 6.5, 7.5, 8.5 },
                { 9, 10, 11, 12 },
                { 13.5, 14.5, 15.5, 16.5 }
            });

            Assert.True(m1 == m2);
        }

        [Fact]
        [UnitTest]
        public void BeNotEquatable()
        {
            var m1 = Matrix.Create(new double[,]
            {
                { 1, 2, 3, 4 },
                { 5.5, 6.5, 7.5, 8.5 },
                { 9, 10, 11, 12 },
                { 13.5, 14.5, 15.5, 16.5 }
            });

            var m2 = Matrix.Create(new double[,]
            {
                { 4, 3, 2, 1 },
                { 5.5, 6.5, 7.5, 8.5 },
                { 9, 10, 11, 12 },
                { 13.5, 14.5, 15.5, 16.5 }
            });

            Assert.True(m1 != m2);
        }

        [Fact]
        [UnitTest]
        public void BeMultiplicable()
        {
            var m1 = Matrix.Create(new double[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 8, 7, 6 },
                { 5, 4, 3, 2 }
            });

            var m2 = Matrix.Create(new double[,]
            {
                { -2, 1, 2, 3 },
                { 3, 2, 1, -1 },
                { 4, 3, 6, 5 },
                { 1, 2, 7, 8 }
            });

            var expected = Matrix.Create(new double[,]
            {
                { 20, 22, 50, 48 },
                { 44, 54, 114, 108 },
                { 40, 58, 110, 102 },
                { 16, 26, 46, 42 }
            });

            Assert.Equal(expected, m1 * m2);
        }

        [Fact]
        [UnitTest]
        public void BeMultiplicableWithDifferentSize()
        {
            var m1 = Matrix.Create(new double[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 8, 7, 6 },
                { 5, 4, 3, 2 }
            });

            var m2 = Matrix.Create(new double[,]
            {
                { -2, 1 },
                { 3, 2 },
                { 4, 3 },
                { 1, 2 }
            });

            var expected = Matrix.Create(new double[,]
            {
                { 20, 22 },
                { 44, 54 },
                { 40, 58 },
                { 16, 26 }
            });

            Assert.Equal(expected, m1 * m2);
        }

        [Fact]
        [UnitTest]
        public void RejectWhenMultiplyingInvalidSizedMatrices()
        {
            var m1 = Matrix.Create(new double[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 8, 7, 6 }
            });

            var m2 = Matrix.Create(new double[,]
            {
                { -2, 1 },
                { 3, 2 },
                { 4, 3 },
            });


            Assert.Throws<ArithmeticException>(() => m1 * m2);
        }

        [Fact]
        [UnitTest]
        public void BeMultiplicableByIdentityMatrix()
        {
            var m = Matrix.Create(new double[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 8, 7, 6 },
                { 5, 4, 3, 2 }
            });

            var identity = Matrix.Identity(4);

            Assert.Equal(m, m * identity);
            Assert.Equal(m, identity * m);
        }

        [Fact]
        [UnitTest]
        public void BeTransposable()
        {
            var m = Matrix.Create(new double[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 8, 7, 6 },
                { 5, 4, 3, 2 }
            });

            var expected = Matrix.Create(new double[,]
            {
                { 1, 5, 9, 5 },
                { 2, 6, 8, 4 },
                { 3, 7, 7, 3 },
                { 4, 8, 6, 2 }
            });

            Assert.Equal(expected, m.Transpose());
        }

        [Fact]
        [UnitTest]
        public void ComputeTheDeterminantOf2x2()
        {
            var m = Matrix.Create(new double[,]
            {
                { 1, 5 },
                { -3, 2 }
            });

            Assert.Equal(17, m.Determinant());
        }

        [Fact]
        [UnitTest]
        public void CreateASubmatrix()
        {
            var m = Matrix.Create(new double[,]
            {
                { 1, 5, 0 },
                { -3, 2, 7 },
                { 0, 6, -3 }
            });

            var expected = Matrix.Create(new double[,]
            {
                { -3, 2 },
                { 0, 6 }
            });

            Assert.Equal(expected, m.Submatrix(0, 2));

            m = Matrix.Create(new double[,]
            {
                { -6, 1, 1, 6 },
                { -8, 5, 8, 6 },
                { -1, 0, 8, 2 },
                { -7, 1, -1, 1 },
            });

            expected = Matrix.Create(new double[,]
            {
                { -6, 1, 6 },
                { -8, 8, 6 },
                { -7, -1, 1 }
            });

            Assert.Equal(expected, m.Submatrix(2, 1));
        }

        [Fact]
        [UnitTest]
        public void ComputeAMinor()
        {
            var m = Matrix.Create(new double[,]
            {
                { 3, 5, 0 },
                { 2, -1, -7 },
                { 6, -1, 5 }
            });

            var submatrix = m.Submatrix(1, 0);

            Assert.Equal(25, submatrix.Determinant());
            Assert.Equal(25, m.Minor(1, 0));
        }

        [Fact]
        [UnitTest]
        public void ComputeCofactor()
        {
            var m = Matrix.Create(new double[,]
            {
                { 3, 5, 0 },
                { 2, -1, -7 },
                { 6, -1, 5 }
            });

            Assert.Equal(-12, m.Minor(0, 0));
            Assert.Equal(-12, m.Cofactor(0, 0));
            Assert.Equal(25, m.Minor(1, 0));
            Assert.Equal(-25, m.Cofactor(1, 0));
        }

        [Fact]
        [UnitTest]
        public void ComputeTheDeterminantOf3x3()
        {
            var m = Matrix.Create(new double[,]
            {
                { 1, 2, 6 },
                { -5, 8, -4 },
                { 2, 6, 4 }
            });

            Assert.Equal(56, m.Cofactor(0, 0));
            Assert.Equal(12, m.Cofactor(0, 1));
            Assert.Equal(-46, m.Cofactor(0, 2));
            Assert.Equal(-196, m.Determinant());
        }


        [Fact]
        [UnitTest]
        public void ComputeTheDeterminantOf4x4()
        {
            var m = Matrix.Create(new double[,]
            {
                { -2, -8, 3, 5 },
                { -3, 1, 7, 3 },
                { 1, 2, -9, 6 },
                { -6, 7, 7, -9 }
            });

            Assert.Equal(690, m.Cofactor(0, 0));
            Assert.Equal(447, m.Cofactor(0, 1));
            Assert.Equal(210, m.Cofactor(0, 2));
            Assert.Equal(51, m.Cofactor(0, 3));
            Assert.Equal(-4071, m.Determinant());
        }

        [Fact]
        [UnitTest]
        public void BeInvertible()
        {
            var m = Matrix.Create(new double[,]
            {
                { 6, 4, 4, 4 },
                { 5, 5, 7, 6 },
                { 4, -9, 3, -7 },
                { 9, 1, 7, -6 }
            });

            Assert.Equal(-2120, m.Determinant());
            Assert.True(m.IsInvertible());
        }

        [Fact]
        [UnitTest]
        public void NotBeInvertible()
        {
            var m = Matrix.Create(new double[,]
            {
                { -5, 2, 6, -3 },
                { 9, 6, 2, 6 },
                { 0, -5, 1, -5 },
                { 0, 0, 0, 0 }
            });

            Assert.Equal(0, m.Determinant());
            Assert.False(m.IsInvertible());
        }

        [Fact]
        [UnitTest]
        public void ComputeTheInverse()
        {
            var m = Matrix.Create(new double[,]
            {
                { -5, 2, 6, -8 },
                { 1, -5, 1, 8 },
                { 7, 7,-6, -7 },
                { 1, -3, 7, 4 }
            });

            var expected = Matrix.Create(new double[,]
            {
                { 0.21805, 0.45113, 0.24060, -0.04511 },
                { -0.80827, -1.45677, -0.44361, 0.52068 },
                { -0.07895, -0.22368, -0.05263, 0.19737 },
                { -0.52256, -0.81391, -0.30075, 0.30639 }
            });

            var inversed = m.Inverse();

            Assert.Equal(532, m.Determinant());
            Assert.Equal(-160, m.Cofactor(2, 3));
            Assert.Equal(-160.0 / 532, inversed[3, 2]);

            Assert.Equal(105, m.Cofactor(3, 2));
            Assert.Equal(105.0 / 532, inversed[2, 3]);

            Assert.True(expected.Equals(inversed, precision: 5));
        }
    }
}