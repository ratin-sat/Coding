using AlgorithmsIlluminated;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class MergeSortTest
    {
        [Fact]
        public void MergeSort_Sample()
        {
            var actual = MergeSort.Solve(new[] { 5, 4, 1, 8, 7, 2, 6, 3 });
            Assert.Equal(new[] { 1, 2, 3, 4, 5, 6, 7, 8 }, actual);
        }
    }
}
