using AlgorithmsIlluminated;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class SecondLargestTest
    {
        [Fact]
        public void SecondLargest_SanityCheck()
        {
            var actual = SecondLargest.Solve(new[] { 5, 4, 1, 8, 7, 2, 6, 3 });
            Assert.Equal(7, actual);
        }

        [Theory]
        [InlineData(
            new[] {
                11, 19, 13, 7, 24, 23, 17, 8, 1, 27, 30, 5, 14, 29, 26, 4, 6, 22, 12, 10, 9, 15, 31, 16, 28, 25, 3, 21, 32, 18, 20, 2
            },
            31)]
        [InlineData(
            new[] {
                64, 6, 20, 34, 27, 7, 58, 15, 12, 52, 49, 59, 43, 36, 35, 10, 54, 30, 60, 3, 45, 44, 26, 63, 50, 23, 33, 1, 39, 37, 57, 47,
                17, 19, 14, 55, 2, 51, 42, 5, 18, 61, 25, 9, 28, 21, 41, 13, 22, 8, 29, 4, 46, 56, 11, 31, 38, 53, 16, 32, 48, 24, 40, 62
            },
            63)]
        public void SecondLargest_Random(int[] input, int expected)
        {
            var actual = SecondLargest.Solve(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] { 2147483647, -2147483648 }, -2147483648)]
        public void SecondLargest_EdgeCase(int[] input, int expected)
        {
            var actual = SecondLargest.Solve(input);
            Assert.Equal(expected, actual);
        }
    }
}
