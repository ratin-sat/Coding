using System.Linq;
using AlgorithmsIlluminated;
using AlgorithmsIlluminated.DataModel;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class TopologicalSortTest
    {
        [Fact]
        public void TopologicalSort_SanityCheck()
        {
            var g = TestHelpers.ReadDirectedGraphFromEdgesListFile(@"resources\Graph_DAG_EdgesList4V.txt");

            TopologicalSort.Solve(g);

            AssertTopologicalOrder(g);
        }

        [Theory]
        [InlineData(@"resources\Graph_DAG_EdgesList8V.txt")]
        public void TopologicalSort_Random(string inputFile)
        {
            var g = TestHelpers.ReadDirectedGraphFromEdgesListFile(inputFile);

            TopologicalSort.Solve(g);

            AssertTopologicalOrder(g);
        }

        private static void AssertTopologicalOrder(Graph g)
        {
            var actual = g.TopologicalOrder;
            var edges = g.AdjacencyList.SelectMany(kvp => kvp.Value);
            foreach (var e in edges)
            {
                Assert.True(actual[e.S] < actual[e.V]);
            }
        }
    }
}
