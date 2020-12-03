using System.Linq;
using AlgorithmsIlluminated;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class QuickSortTest
    {
        [Theory]
        [InlineData(@"resources\Input_Sorting10.txt", @"resources\Output_Sorting10.txt", 25)]
        [InlineData(@"resources\Input_Sorting100.txt", @"resources\Output_Sorting100.txt", 620)]
        public void QuickSort_FirstElement(string inputFile, string expectedResultFile, int expectedCount)
        {
            var input = TestHelpers.ReadLineFromTextFile(inputFile, int.Parse).ToArray();
            var postCondition = TestHelpers.ReadLineFromTextFile(expectedResultFile, int.Parse).ToArray();
            var actual = QuickSort.Solve(input, QuickSort.FirstElement);
            Assert.Equal(postCondition, input);
            Assert.Equal(expectedCount, actual);
        }

        [Theory]
        [InlineData(@"resources\Input_Sorting10.txt", @"resources\Output_Sorting10.txt", 31)]
        [InlineData(@"resources\Input_Sorting100.txt", @"resources\Output_Sorting100.txt", 573)]
        public void QuickSort_LastElement(string inputFile, string expectedResultFile, int expectedCount)
        {
            var input = TestHelpers.ReadLineFromTextFile(inputFile, int.Parse).ToArray();
            var postCondition = TestHelpers.ReadLineFromTextFile(expectedResultFile, int.Parse).ToArray();
            var actual = QuickSort.Solve(input, QuickSort.LastElement);
            Assert.Equal(postCondition, input);
            Assert.Equal(expectedCount, actual);
        }

        [Theory]
        [InlineData(@"resources\Input_Sorting10.txt", @"resources\Output_Sorting10.txt", 21)]
        [InlineData(@"resources\Input_Sorting100.txt", @"resources\Output_Sorting100.txt", 502)]
        public void QuickSort_MedianOfThreeElements(string inputFile, string expectedResultFile, int expectedCount)
        {
            var input = TestHelpers.ReadLineFromTextFile(inputFile, int.Parse).ToArray();
            var postCondition = TestHelpers.ReadLineFromTextFile(expectedResultFile, int.Parse).ToArray();
            var actual = QuickSort.Solve(input, QuickSort.MedianOfThreeElements);
            Assert.Equal(postCondition, input);
            Assert.Equal(expectedCount, actual);
        }
    }
}
