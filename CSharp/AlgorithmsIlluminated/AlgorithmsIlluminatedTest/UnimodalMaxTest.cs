using AlgorithmsIlluminated;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class UnimodalMaxTest
    {
        [Fact]
        public void UnimodalMax_SanityCheck()
        {
            var input = new[] { 2, 4, 6, 8, 7, 5, 3, 1 };
            var actual = UnimodalMax.Solve(input);
            Assert.Equal(8, actual);
        }

        [Theory]
        [InlineData(new[] { 4, 5, 8, 9, 10, 11, 7, 3, 2, 1 }, 11)]
        [InlineData(new[] { 11, 9, 8, 7, 5, 4, 3, 2, 1 }, 11)]
        [InlineData(new[] { 1, 2, 3, 4, 5, 7, 8, 9, 11 }, 11)]
        public void UnimodalMax_AllPatterns(int[] input, int expected)
        {
            var actual = UnimodalMax.Solve(input);
            Assert.Equal(expected, actual);
        }
    }
}
