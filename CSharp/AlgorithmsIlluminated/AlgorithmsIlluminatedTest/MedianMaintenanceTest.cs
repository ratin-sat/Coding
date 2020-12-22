using AlgorithmsIlluminated;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class MedianMaintenanceTest
    {
        [Fact]
        public void MedianMaintenance_SanityCheck()
        {
            var input = TestHelpers.ReadLineFromTextFile(@"resources\Input_MedianMaintenance10.txt", int.Parse);
            var sum = 0L;

            foreach (var median in MedianMaintenance.Solve(input))
            {
                sum += median;
            }

            var actual = (int)(sum % 10000);
            var expected = 9335;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MedianMaintenance_Challenge()
        {
            var input = TestHelpers.ReadLineFromTextFile(@"resources\Input_MedianMaintenance10000.txt", int.Parse);
            var sum = 0L;

            foreach (var median in MedianMaintenance.Solve(input))
            {
                sum += median;
            }

            var actual = (int)(sum % 10000);
            var expected = 1213;
            Assert.Equal(expected, actual);
        }
    }
}
