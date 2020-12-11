using AlgorithmsIlluminated;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class GridLocalMinimumTest
    {
        [Fact]
        public void GridLocalMinimumTest_SanityCheck()
        {
            var grid = new[,] { { 7, 8, 2 }, { 5, 3, 1 }, { 4, 6, 9 } };
            var actual = GridLocalMinimum.Solve(grid);
            var possible = new[] { 1, 4 };
            Assert.Contains(actual, possible);
        }

        [Theory]
        [InlineData(@"resources\Grid_Distinct8x8.txt", new[] { 1, 2, 3, 4, 6, 7, 10, 11, 13, 17, 30 })]
        [InlineData(@"resources\Grid_Distinct10x10.txt", new[] { 1, 2, 3, 4, 5, 6, 8, 11, 12, 13, 15, 16, 21, 22, 27, 30, 36, 37, 40, 48 })]
        public void GridLocalMinimumTest_Random(string inputFile, int[] possible)
        {
            var grid = TestHelpers.Read2DArray(inputFile);
            var actual = GridLocalMinimum.Solve(grid);
            Assert.Contains(actual, possible);
        }

        [Theory]
        [InlineData(@"resources\Grid_DistinctIncreasing5x5_1.txt", new[] { 1 })]
        [InlineData(@"resources\Grid_DistinctIncreasing5x5_2.txt", new[] { 1 })]
        [InlineData(@"resources\Grid_DistinctDecreasing5x5_1.txt", new[] { 1 })]
        [InlineData(@"resources\Grid_DistinctDecreasing5x5_2.txt", new[] { 1 })]
        public void GridLocalMinimumTest_EdgeCase(string inputFile, int[] possible)
        {
            var grid = TestHelpers.Read2DArray(inputFile);
            var actual = GridLocalMinimum.Solve(grid);
            Assert.Contains(actual, possible);
        }
    }
}
