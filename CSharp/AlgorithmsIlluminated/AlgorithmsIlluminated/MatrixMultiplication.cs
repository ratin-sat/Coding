using AlgorithmsIlluminated.DataModel;

namespace AlgorithmsIlluminated
{
    public static class MatrixMultiplication
    {
        // Input: Two n x n integer matrices, X and Y
        // Output: The matrix product XY
        // Assumption: n is a power of 2
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

        // Input: n x n integer matrices X and Y
        // Output: Z = XY
        // Assumption: n is a power of 2
        private static Matrix Strassen(Matrix x, Matrix y)
        {
            var n = x.ColDim;

            if (n == 1)
            {
                return new Matrix(new int[1, 1] { { x.GetElement(0, 0) * y.GetElement(0, 0) } });
            }

            (var a, var b, var c, var d) = SubMatrices(x, n);
            (var e, var f, var g, var h) = SubMatrices(y, n);

            // recursively compute seven (cleverly chosen) products involving A, B, ..., H
            // P1 = A * (F - H)
            var p1 = Strassen(a, f - h);
            // P2 = (A + B) * H
            var p2 = Strassen(a + b, h);
            // P3 = (C + D) * E
            var p3 = Strassen(c + d, e);
            // P4 = D * (G - E)
            var p4 = Strassen(d, g - e);
            // P5 = (A + D) * (E + H)
            var p5 = Strassen(a + d, e + h);
            // P6 = (B - D) * (G + H)
            var p6 = Strassen(b - d, g + h);
            // P7 = (A - C) * (E + F)
            var p7 = Strassen(a - c, e + f);

            // P5 + P4 - P2 + P6
            var ul = p5 + p4 - p2 + p6;
            // P1 + P2
            var ur = p1 + p2;
            // P3 + P4
            var ll = p3 + p4;
            // P1 + P5 - P3 - P7
            var lr = p1 + p5 - p3 - p7;

            return ComposeMatrix(ul, ur, ll, lr, n);
        }

        // Divide n x n matrix into 4 equally sized matrices
        private static (Matrix, Matrix, Matrix, Matrix) SubMatrices(Matrix matrix, int n)
        {
            var m = n / 2;
            var a = new int[m, m];
            var b = new int[m, m];
            var c = new int[m, m];
            var d = new int[m, m];

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    a[i, j] = matrix.GetElement(i, j);
                    b[i, j] = matrix.GetElement(i, m + j);
                    c[i, j] = matrix.GetElement(m + i, j);
                    d[i, j] = matrix.GetElement(m + i, m + j);
                }
            }

            return (new Matrix(a), new Matrix(b), new Matrix(c), new Matrix(d));
        }

        // Compose 4 matrices a, b, c, d (n/2 x n/2) into n x n matrix
        private static Matrix ComposeMatrix(Matrix a, Matrix b, Matrix c, Matrix d, int n)
        {
            var m = n / 2;
            var abcd = new int[n, n];

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    abcd[i, j] = a.GetElement(i, j);
                    abcd[i, j + m] = b.GetElement(i, j);
                    abcd[i + m, j] = c.GetElement(i, j);
                    abcd[i + m, j + m] = d.GetElement(i, j);
                }
            }

            return new Matrix(abcd);
        }
    }
}
