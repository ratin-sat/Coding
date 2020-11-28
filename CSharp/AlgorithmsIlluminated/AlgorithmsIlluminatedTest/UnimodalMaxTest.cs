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
    }
}
