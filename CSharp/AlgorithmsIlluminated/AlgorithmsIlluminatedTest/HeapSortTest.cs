using System.Linq;
using AlgorithmsIlluminated;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class HeapSortTest
    {
        [Fact]
        public void HeapSort_SanityCheck()
        {
            var input = new[] { 5, 4, 1, 8, 7, 2, 6, 3 };
            var expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var actual = HeapSort.Solve(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(@"resources\Input_Sorting10.txt", @"resources\Output_Sorting10.txt")]
        [InlineData(@"resources\Input_Sorting100.txt", @"resources\Output_Sorting100.txt")]
        [InlineData(@"resources\Input_Sorting10000.txt", @"resources\Output_Sorting10000.txt")]
        public void HeapSort_RandomArray(string inputFile, string expectedResultFile)
        {
            var input = TestHelpers.ReadLineFromTextFile(inputFile, int.Parse).ToArray();
            var expected = TestHelpers.ReadLineFromTextFile(expectedResultFile, int.Parse).ToArray();
            var actual = HeapSort.Solve(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 }, new[] { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 })]
        [InlineData(new[] { 5, 4, 3, 2, 1, 0, -1, -2, -3, -4, -5 }, new[] { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 })]
        public void HeapSort_MonotonicArray(int[] input, int[] expected)
        {
            var actual = HeapSort.Solve(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] { 12 }, new[] { 12 })]
        [InlineData(new[] { 0, 2147483647, -1, 1, -2147483648 }, new[] { -2147483648, -1, 0, 1, 2147483647 })]
        public void HeapSort_EdgeCase(int[] input, int[] expected)
        {
            var actual = HeapSort.Solve(input);
            Assert.Equal(expected, actual);
        }
    }
}
