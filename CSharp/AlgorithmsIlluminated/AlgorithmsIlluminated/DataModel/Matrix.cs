using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsIlluminated.DataModel
{
    public class Matrix
    {
        private int[,] Elements { get; }

        public int RowDim { get; }

        public int ColDim { get; }

        public Matrix(int[,] elements)
        {
            this.Elements = elements;
            this.RowDim = elements.GetLength(0);
            this.ColDim = elements.GetLength(1);
        }

        public int GetElement(int row, int col)
        {
            if (row < 0 || row >= this.RowDim || col < 0 || col >= this.ColDim)
            {
                throw new ArgumentException();
            }

            return this.Elements[row, col];
        }

        public int[] GetRow(int row)
        {
            if (row < 0 || row >= this.RowDim)
            {
                throw new ArgumentException();
            }

            return Enumerable.Range(0, this.ColDim)
                .Select(x => this.Elements[row, x])
                .ToArray();
        }

        public int[] GetColumn(int col)
        {
            if (col < 0 || col >= this.ColDim)
            {
                throw new ArgumentException();
            }

            return Enumerable.Range(0, this.RowDim)
                .Select(x => this.Elements[x, col])
                .ToArray();
        }

        public static Matrix operator +(Matrix left, Matrix right)
        {
            if (left.RowDim != right.RowDim || left.ColDim != right.ColDim)
            {
                throw new ArgumentException();
            }

            var result = new int[left.RowDim, left.ColDim];
            for (var i = 0; i < left.RowDim; i++)
            {
                for (var j = 0; j < left.ColDim; j++)
                {
                    result[i, j] = left.GetElement(i, j) + right.GetElement(i, j);
                }
            }

            return new Matrix(result);
        }

        public static Matrix operator -(Matrix left, Matrix right)
        {
            if (left.RowDim != right.RowDim || left.ColDim != right.ColDim)
            {
                throw new ArgumentException();
            }

            var result = new int[left.RowDim, left.ColDim];
            for (var i = 0; i < left.RowDim; i++)
            {
                for (var j = 0; j < left.ColDim; j++)
                {
                    result[i, j] = left.GetElement(i, j) - right.GetElement(i, j);
                }
            }

            return new Matrix(result);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Matrix matrix))
            {
                return false;
            }

            if (this.RowDim != matrix.RowDim || this.ColDim != matrix.ColDim)
            {
                return false;
            }

            for (var i = 0; i < this.RowDim; i++)
            {
                var row = this.GetRow(i) as IStructuralEquatable;
                if (!row.Equals(matrix.GetRow(i), StructuralComparisons.StructuralEqualityComparer))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            var hashCode = -260687900;
            hashCode = (hashCode * -1521134295) + this.RowDim.GetHashCode();
            hashCode = (hashCode * -1521134295) + this.ColDim.GetHashCode();
            hashCode = (hashCode * -1521134295) + EqualityComparer<int[,]>.Default.GetHashCode(this.Elements);
            return hashCode;
        }
    }
}
