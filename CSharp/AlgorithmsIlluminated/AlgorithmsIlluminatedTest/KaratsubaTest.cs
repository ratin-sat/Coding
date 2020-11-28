using AlgorithmsIlluminated;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class KaratsubaTest
    {
        [Fact]
        public void Karatsuba_SanityCheck()
        {
            var actual = Karatsuba.Solve("5678", "1234");
            Assert.Equal("7006652", actual);
        }

        [Theory]
        [InlineData("99999", "9999", "999890001")]
        [InlineData("40354", "79041204", "3189628746216")]
        public void Karatsuba_Random(string x, string y, string expected)
        {
            var actual = Karatsuba.Solve(x, y);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("5794112457490524538595502745245", "1", "5794112457490524538595502745245")]
        [InlineData("0", "4521755790520361565", "0")]
        public void Karatsuba_EdgeCase(string x, string y, string expected)
        {
            var actual = Karatsuba.Solve(x, y);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Karatsuba_Challenge()
        {
            var actual = Karatsuba.Solve(
                "3141592653589793238462643383279502884197169399375105820974944592",
                "2718281828459045235360287471352662497757247093699959574966967627");
            Assert.Equal(
                "8539734222673567065463550869546574495034888535765114961879601127067743044893204848617875072216249073013374895871952806582723184",
                actual);
        }
    }
}
