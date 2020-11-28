using AlgorithmsIlluminated;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class HasIdenticalIndexValueTest
    {
        [Theory]
        [InlineData(new[] { -4, -2, 2, 4, 6, 8 }, true)]
        [InlineData(new[] { 1, 3, 5, 7, 9, 11 }, false)]
        public void HasIdenticalIndexValueTest_SanityCheck(int[] input, bool expected)
        {
            var actual = HasIdenticalIndexValue.Solve(input);
            Assert.Equal(expected, actual);
        }
    }
}
