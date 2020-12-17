using System.Linq;
using AlgorithmsIlluminated;
using AlgorithmsIlluminated.DataModel;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class UndirectedConnectedComponentTest
    {
        [Fact]
        public void UndirectedConnectedComponent_SanityCheck()
        {
            var g = TestHelpers.ReadUndirectedGraphFromEdgesListFile(@"resources\Graph_EdgesList10V3CC.txt");

            UndirectedConnectedComponent.Solve(g);

            AssertUCC(g);
        }

        private static void AssertUCC(Graph g)
        {
            var cc = g.ConnectedComponent;
            var edges = g.AdjacencyList.SelectMany(kvp => kvp.Value);
            foreach (var e in edges)
            {
                Assert.NotEqual(0, cc[e.S]);
                Assert.Equal(cc[e.S], cc[e.V]);
            }
        }
    }
}
