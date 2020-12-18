using System.Collections;
using System.Linq;
using System.Collections.Generic;
using AlgorithmsIlluminated;
using AlgorithmsIlluminated.DataModel;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class ShortestPathTest
    {
        [Fact]
        public void ShortestPath_SanityCheck()
        {
            var g = TestHelpers.ReadUndirectedGraphFromEdgesListFile(@"resources\Graph_EdgesList4V.txt");
            var s = g.Vertices.First();

            ShortestPath.Solve(g, s);

            var actual = g.SearchRecord.Distance;
            var expected = new Dictionary<Vertex, int>
            {
                { new Vertex(1), 0 },
                { new Vertex(2), 1 },
                { new Vertex(3), 1 },
                { new Vertex(4), 2 },
            };
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(ShortestPathTestRandomData))]
        public void ShortestPath_Random(string inputFile, Vertex s, IDictionary<Vertex, int> expected)
        {
            var g = TestHelpers.ReadUndirectedGraphFromEdgesListFile(inputFile);

            ShortestPath.Solve(g, s);

            var actual = g.SearchRecord.Distance;
            Assert.Equal(expected, actual);
        }

        private class ShortestPathTestRandomData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"resources\Graph_EdgesList9V.txt",
                    new Vertex(1),
                    new Dictionary<Vertex, int>
                    {
                        { new Vertex(1), 0 },
                        { new Vertex(2), 5 },
                        { new Vertex(3), 3 },
                        { new Vertex(4), 1 },
                        { new Vertex(5), 5 },
                        { new Vertex(6), 3 },
                        { new Vertex(7), 1 },
                        { new Vertex(8), 4 },
                        { new Vertex(9), 2 },
                    }
                };
                yield return new object[]
                {
                    @"resources\Graph_EdgesList10V3CC.txt",
                    new Vertex(1),
                    new Dictionary<Vertex, int>
                    {
                        { new Vertex(1), 0 },
                        { new Vertex(2), int.MaxValue },
                        { new Vertex(3), 1 },
                        { new Vertex(4), int.MaxValue },
                        { new Vertex(5), 1 },
                        { new Vertex(6), int.MaxValue },
                        { new Vertex(7), 2 },
                        { new Vertex(8), int.MaxValue },
                        { new Vertex(9), 2 },
                        { new Vertex(10), int.MaxValue },
                    }
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }
    }
}
