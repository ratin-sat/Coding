using System.Linq;
using AlgorithmsIlluminated;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class DSelectTest
    {
        [Fact]
        public void DSelect_SanityCheck()
        {
            var a = new[] { 11, 6, 10, 2, 15, 8, 1, 7, 14, 3, 9, 12, 4, 5, 13 };
            var actual = DSelect.Solve(a, 3);
            Assert.Equal(3, actual);
        }

        [Theory]
        [InlineData(@"resources\Input_Sorting10.txt", 3, 2148)]
        [InlineData(@"resources\Input_Sorting100.txt", 89, 8910)]
        [InlineData(@"resources\Input_Sorting10000.txt", 1016, 1016)]
        public void DSelect_Random(string inputFile, int i, int expected)
        {
            var input = TestHelpers.ReadLineFromTextFile(inputFile, int.Parse).ToArray();
            var actual = DSelect.Solve(input, i);
            Assert.Equal(expected, actual);
        }
    }
}
