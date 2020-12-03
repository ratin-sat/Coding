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
            var expected = new Matrix(new[,] { { 19, 22 }, { 43, 50 } });
            var actual = MatrixMultiplication.Solve(x, y);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(@"resources\MatrixXYZ_Mult4x4.txt")]
        [InlineData(@"resources\MatrixXYZ_Mult16x16.txt")]
        [InlineData(@"resources\MatrixXYZ_Mult64x64.txt")]
        public void MatrixMultiplication_Random(string filepath)
        {
            var matrices = TestHelpers.ReadMatricesFromTextFile(filepath);
            var x = matrices[0];
            var y = matrices[1];
            var expected = matrices[2];
            var actual = MatrixMultiplication.Solve(x, y);
            Assert.Equal(expected, actual);
        }
    }
}
