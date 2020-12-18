using System.Collections;
using System.Linq;
using System.Collections.Generic;
using AlgorithmsIlluminated;
using AlgorithmsIlluminated.DataModel;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class DijkstraTest
    {
        [Fact]
        public void Dijkstra_SanityCheck()
        {
            var g = TestHelpers.ReadDirectedGraphFromAdjacenciesListFile(@"resources\Graph_AdjList4V.txt");
            var s = g.Vertices.First();

            Dijkstra.Solve(g, s);

            var actual = g.SearchRecord.Distance;
            var expected = new Dictionary<Vertex, int>
            {
                { new Vertex(1), 0 },
                { new Vertex(2), 1 },
                { new Vertex(3), 3 },
                { new Vertex(4), 6 },
            };
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(DijkstraTestRandomData))]
        public void Dijkstra_Random(string inputFile, Vertex s, IDictionary<Vertex, int> expected)
        {
            var g = TestHelpers.ReadDirectedGraphFromAdjacenciesListFile(inputFile);

            Dijkstra.Solve(g, s);

            var actual = g.SearchRecord.Distance;
            Assert.Equal(expected, actual);
        }

        private class DijkstraTestRandomData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"resources\Graph_AdjList8V.txt",
                    new Vertex(1),
                    new Dictionary<Vertex, int>
                    {
                        { new Vertex(1), 0 },
                        { new Vertex(2), 1 },
                        { new Vertex(3), 2 },
                        { new Vertex(4), 3 },
                        { new Vertex(5), 4 },
                        { new Vertex(6), 4 },
                        { new Vertex(7), 3 },
                        { new Vertex(8), 2 },
                    }
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }
    }
}
