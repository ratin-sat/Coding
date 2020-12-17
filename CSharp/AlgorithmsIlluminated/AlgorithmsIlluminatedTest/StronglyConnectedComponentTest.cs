using System.Collections;
using System.Linq;
using System.Collections.Generic;
using AlgorithmsIlluminated;
using AlgorithmsIlluminated.DataModel;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class StronglyConnectedComponentTest
    {
        [Fact]
        public void StronglyConnectedComponent_SanityCheck()
        {
            var g = TestHelpers.ReadDirectedGraphFromEdgesListFile(@"resources\Graph_EdgesList11V4SCC.txt");

            StronglyConnectedComponent.Solve(g);

            var expected = new int[][] { new[] { 1, 3, 5 }, new[] { 11 }, new[] { 2, 4, 7, 9 }, new[] { 6, 8, 10 } };
            AssertSCC(g, expected);
        }

        [Theory]
        [ClassData(typeof(StronglyConnectedComponentTestRandomData))]
        public void StronglyConnectedComponent_Random(string inputFile, int[][] expected)
        {
            var g = TestHelpers.ReadDirectedGraphFromEdgesListFile(inputFile);

            StronglyConnectedComponent.Solve(g);

            AssertSCC(g, expected);
        }

        private class StronglyConnectedComponentTestRandomData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"resources\Graph_EdgesList9V3SCC.txt",
                    new int[][] { new[] { 1, 4, 7 }, new[] { 2, 5, 8 }, new[] { 3, 6, 9 } },
                };
                yield return new object[]
                {
                    @"resources\Graph_EdgesList8V3SCC.txt",
                    new int[][] { new[] { 1, 2, 3 }, new[] { 4, 5 }, new[] { 6, 7, 8 } },
                };
                yield return new object[]
                {
                    @"resources\Graph_EdgesList8V4SCC.txt",
                    new int[][] { new[] { 1, 2, 3 }, new[] { 4 }, new[] { 5 }, new[] { 6, 7, 8 } },
                };
                yield return new object[]
                {
                    @"resources\Graph_EdgesList8V2SCC.txt",
                    new int[][] { new[] { 1, 2, 3, 4, 6, 7, 8 }, new[] { 5 } },
                };
                yield return new object[]
                {
                    @"resources\Graph_EdgesList12V4SCC.txt",
                    new int[][] { new[] { 1 }, new[] { 2, 4, 5 }, new[] { 3, 6 }, new[] { 7, 8, 9, 10, 11, 12 } },
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }

        private static void AssertSCC(Graph g, int[][] expectedScc)
        {
            var checkedScc = new HashSet<int>();
            foreach (var scc in expectedScc)
            {
                var sccId = g.StronglyConnectedComponent[new Vertex(scc.First())];
                Assert.DoesNotContain(sccId, checkedScc);

                checkedScc.Add(sccId);

                foreach (var vid in scc.Skip(1))
                {
                    Assert.Equal(sccId, g.StronglyConnectedComponent[new Vertex(vid)]);
                }
            }
        }
    }
}
