using AlgorithmsIlluminated.DataModel;

namespace AlgorithmsIlluminated
{
    public static class MatrixMultiplication
    {
        // Input: Two n x n integer matrices, X and Y
        // Output: The matrix product XY
        public static Matrix Solve(Matrix x, Matrix y)
        {
            return StraightForwardMatrixMult(x, y);
        }

        // Input: n x n integer matrices X and Y
        // Output: Z = XY
        private static Matrix StraightForwardMatrixMult(Matrix x, Matrix y)
        {
            var n = x.ColDim;
            var z = new int[n, n];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    z[i, j] = 0;
                    for (var k = 0; k < n; k++)
                    {
                        z[i, j] += x.GetElement(i, k) * y.GetElement(k, j);
                    }
                }
            }

            return new Matrix(z);
        }
    }
}
