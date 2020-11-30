using AlgorithmsIlluminated;
using AlgorithmsIlluminated.DataModel;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class ClosestPairTest
    {
        [Fact]
        public void ClosestPair_SanityCheck()
        {
            var a = new Point2D(-2.4575, 7.00125);
            var b = new Point2D(1.1425, 0.80125);
            var c = new Point2D(2.0425, 1.20125);
            var d = new Point2D(7.0025, 4.26125);
            var input = new[] { a, b, c, d };
            var expected = (b, c);
            var actual = ClosestPair.Solve(input);
            Assert.Equal(expected, actual);
        }
    }
}
