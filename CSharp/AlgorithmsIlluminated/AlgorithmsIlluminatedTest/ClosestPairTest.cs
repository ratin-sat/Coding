using System.Linq;
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
            var expected1 = (b, c);
            var expected2 = (c, b);
            var actual = ClosestPair.Solve(input);
            Assert.True(expected1.Equals(actual) || expected2.Equals(actual));
        }

        [Theory]
        [InlineData(@"resources\Input_Point2D30.txt", 0, 20)]
        [InlineData(@"resources\Input_Point2D100.txt", 49, 82)]
        public void ClosestPair_Random(string inputFile, int i, int j)
        {
            Point2D ParsePoint2D(string token)
            {
                var xy = token.Split(',').Select(double.Parse).ToArray();
                return new Point2D(xy[0], xy[1]);
            }

            var input = TestHelpers.ReadLineFromTextFile(inputFile, ParsePoint2D).ToArray();
            var expected1 = (input[i], input[j]);
            var expected2 = (input[j], input[i]);
            var actual = ClosestPair.Solve(input);
            Assert.True(expected1.Equals(actual) || expected2.Equals(actual));
        }
    }
}
