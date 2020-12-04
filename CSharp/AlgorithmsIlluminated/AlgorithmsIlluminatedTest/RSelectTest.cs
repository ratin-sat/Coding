using System.Linq;
using AlgorithmsIlluminated;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class RSelectTest
    {
        [Fact]
        public void RSelect_SanityCheck()
        {
            var a = new[] { 6, 8, 2, 9 };
            var actual = RSelect.Solve(a, 2);
            Assert.Equal(6, actual);
        }

        [Theory]
        [InlineData(@"resources\Input_Sorting10.txt", 6, 6324)]
        [InlineData(@"resources\Input_Sorting100.txt", 41, 3859)]
        [InlineData(@"resources\Input_Sorting10000.txt", 8257, 8257)]
        public void RSelect_Random(string inputFile, int i, int expected)
        {
            var input = TestHelpers.ReadLineFromTextFile(inputFile, int.Parse).ToArray();
            var actual = RSelect.Solve(input, i);
            Assert.Equal(expected, actual);
        }
    }
}
