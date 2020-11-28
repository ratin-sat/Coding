using AlgorithmsIlluminated;
using AlgorithmsIlluminated.DataModel;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class MatrixMultiplicationTest
    {
        [Fact]
        public void MatrixMultiplication_SanityCheck()
        {
            var x = new Matrix(new[,] { { 1, 2 }, { 3, 4 } });
            var y = new Matrix(new[,] { { 5, 6 }, { 7, 8 } });
            var expected = new Matrix(new[,] { { 19, 22 }, { 43, 55 } });
            var actual = MatrixMultiplication.Solve(x, y);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MatrixMultiplication_Random()
        {
            var x = new Matrix(new[,] { { 6, -2, 5, 2 }, { 3, 7, 1, -3 }, { -8, 4, 3, 2 }, { 0, 4, 5, -7 } });
            var y = new Matrix(new[,] { { 1, -2, -8, 1 }, { -3, 4, -2, 6 }, { 2, -1, 3, 5 }, { 6, 1, -1, -4 } });
            var expected = new Matrix(new[,] { { 34, -23, -31, 11 }, { -34, 18, -32, 62 }, { -2, 31, 63, 23 }, { -44, 4, 14, 77 } });
            var actual = MatrixMultiplication.Solve(x, y);
            Assert.Equal(expected, actual);
        }
    }
}
