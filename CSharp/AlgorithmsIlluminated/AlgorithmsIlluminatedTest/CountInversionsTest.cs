using System.Linq;
using AlgorithmsIlluminated;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class CountInversionsTest
    {
        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 0)]
        [InlineData(new[] { 8, 7, 6, 5, 4, 3, 2, 1 }, 28)]
        [InlineData(new[] { 1, 3, 5, 2, 4, 6 }, 3)]
        public void CountInversions_SanityCheck(int[] input, long expected)
        {
            var actual = CountInversions.Solve(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(@"resources\Input_CountInversions10.txt", 28)]
        [InlineData(@"resources\Input_CountInversions100000.txt", 2407905288)]
        public void CountInversions_Challenge(string inputFile, long expected)
        {
            var input = TestHelpers.ReadLineFromTextFile(inputFile, int.Parse).ToArray();
            var actual = CountInversions.Solve(input);
            Assert.Equal(expected, actual);
        }
    }
}
