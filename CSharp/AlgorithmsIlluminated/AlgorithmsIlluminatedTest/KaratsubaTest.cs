using AlgorithmsIlluminated;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class KaratsubaTest
    {
        [Fact]
        public void Karatsuba_Sample()
        {
            var actual = Karatsuba.Solve("5678", "1234");
            Assert.Equal("7006652", actual);
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
