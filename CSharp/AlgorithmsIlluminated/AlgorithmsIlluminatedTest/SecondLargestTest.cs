using AlgorithmsIlluminated;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class SecondLargestTest
    {
        [Fact]
        public void SecondLargest_Sample()
        {
            var actual = SecondLargest.Solve(new[] { 5, 4, 1, 8, 7, 2, 6, 3 });
            Assert.Equal(7, actual);
        }
    }
}
