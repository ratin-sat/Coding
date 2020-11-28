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
    }
}
