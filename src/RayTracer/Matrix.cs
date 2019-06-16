using System;
using System.Collections.Generic;

namespace RayTracer
{
    public class Matrix : IEquatable<Matrix>
    {
        private readonly double[,] _values;

        private Matrix(int rows, int columns, double[,] values)
        {
            Rows = rows;
            Columns = columns;
            _values = values;
        }

        public Matrix(int rows, int columns)
            : this(rows, columns, new double[rows, columns])
        {
        }

        public int Rows { get; }
        public int Columns { get; }

        public double this[int row, int column]
        {
            get => _values[row, column];
        }

        public Matrix Transpose()
        {
            var result = new double[Rows, Columns];
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    result[j, i] = _values[i, j];

            return Create(result);
        }

        public double Determinant()
        {
            if (Rows == 2 && Columns == 2)
                return _values[0, 0] * _values[1, 1] - _values[0, 1] * _values[1, 0];

            var det = 0.0;
            for (int j = 0; j < Columns; j++)
                det += _values[0, j] * Cofactor(0, j);

            return det;
        }

        public Matrix Submatrix(int deleteRow, int deleteColumn)
        {
            var result = new double[Rows - 1, Columns - 1];

            for (int i = 0; i < Rows - 1; i++)
            {
                for (int j = 0; j < Columns - 1; j++)
                {
                    result[i, j] = _values[i + (i >= deleteRow ? 1 : 0), j + (j >= deleteColumn ? 1 : 0)];
                }
            }

            return Create(result);
        }

        public double Minor(int row, int column) => Submatrix(row, column).Determinant();

        public double Cofactor(int row, int column) => Minor(row, column) * ((row + column) % 2 == 0 ? 1 : -1);

        public bool IsInvertible() => Determinant() != 0;

        public Matrix Inverse()
        {
            var det = Determinant();
            if (det == 0)
                throw new ArithmeticException("Matrix cannot be inversed: determinant is 0.");
            var result = new double[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    // transpose operation
                    result[j, i] = Cofactor(i, j) / det;
                }
            }

            return Create(result);
        }

        public override int GetHashCode()
        {
            var hash = 17;
            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    hash = hash * 31 + _values[i, j].GetHashCode();

            return hash;
        }

        public bool Equals(Matrix other, int? precision = null)
        {
            if (Rows != other.Rows || Columns != other.Columns)
                return false;

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if(precision == null ?
                        !this[i, j].ApproximatelyEqual(other[i, j]) :
                        !this[i, j].ApproximatelyEqual(other[i, j], precision.Value))
                        return false;
                }
            }

            return true;
        }

        public bool Equals(Matrix other) => Equals(other, precision: null);

        public override bool Equals(object obj) =>
            obj is Matrix other && Equals(other);

        public static bool operator ==(Matrix left, Matrix right) => left.Equals(right);

        public static bool operator !=(Matrix left, Matrix right) => !left.Equals(right);

        public static Matrix operator *(Matrix left, Matrix right) => NaiveMultiply(left, right);

        private static Matrix NaiveMultiply(Matrix left, Matrix right)
        {
            if (left.Columns != right.Rows)
                throw new ArithmeticException("Matrices are not compatible.");

            var result = new double[left.Rows, right.Columns];

            for (int i = 0; i < left.Rows; i++)
            {
                for (int j = 0; j < right.Columns; j++)
                {
                    for (int k = 0; k < left.Columns; k++)
                        result[i, j] += left[i, k] * right[k, j];
                }
            }

            return Create(result);
        }

        public static Matrix Create(double[,] values) => new Matrix(values.GetLength(0), values.GetLength(1), values);

        public static Matrix Identity(int size)
        {
            var data = new double[size, size];
            for (int i = 0; i < size; i++)
                data[i, i] = 1;

            return Matrix.Create(data);
            {

            }
        }
    }
}