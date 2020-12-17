using System.Collections;
using System.Linq;
using System.Collections.Generic;
using AlgorithmsIlluminated;
using AlgorithmsIlluminated.DataModel;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class DepthFirstSearchTest
    {
        [Fact]
        public void DepthFirstSearch_SanityCheck()
        {
            var g = TestHelpers.ReadUndirectedGraphFromEdgesListFile(@"resources\Graph_EdgesList4V.txt");
            var s = g.Vertices.First();

            DepthFirstSearch.Solve(g, s);

            var actual = g.SearchRecord.Explored;
            var expected = g.Vertices
                .Select(v => new { Vertex = v, Explored = true })
                .ToDictionary(x => x.Vertex, x => x.Explored);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(DepthFirstSearchTestRandomData))]
        public void DepthFirstSearch_Random(string inputFile, Vertex s, IDictionary<Vertex, bool> expected)
        {
            var g = TestHelpers.ReadUndirectedGraphFromEdgesListFile(inputFile);

            DepthFirstSearch.Solve(g, s);

            var actual = g.SearchRecord.Explored;
            Assert.Equal(expected, actual);
        }

        private class DepthFirstSearchTestRandomData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    @"resources\Graph_EdgesList9V.txt",
                    new Vertex(1),
                    new Dictionary<Vertex, bool>
                    {
                        { new Vertex(1), true },
                        { new Vertex(2), true },
                        { new Vertex(3), true },
                        { new Vertex(4), true },
                        { new Vertex(5), true },
                        { new Vertex(6), true },
                        { new Vertex(7), true },
                        { new Vertex(8), true },
                        { new Vertex(9), true },
                    }
                };
                yield return new object[]
                {
                    @"resources\Graph_EdgesList10V3CC.txt",
                    new Vertex(1),
                    new Dictionary<Vertex, bool>
                    {
                        { new Vertex(1), true },
                        { new Vertex(2), false },
                        { new Vertex(3), true },
                        { new Vertex(4), false },
                        { new Vertex(5), true },
                        { new Vertex(6), false },
                        { new Vertex(7), true },
                        { new Vertex(8), false },
                        { new Vertex(9), true },
                        { new Vertex(10), false },
                    }
                };
                yield return new object[]
                {
                    @"resources\Graph_EdgesList10V3CC.txt",
                    new Vertex(6),
                    new Dictionary<Vertex, bool>
                    {
                        { new Vertex(1), false },
                        { new Vertex(2), false },
                        { new Vertex(3), false },
                        { new Vertex(4), false },
                        { new Vertex(5), false },
                        { new Vertex(6), true },
                        { new Vertex(7), false },
                        { new Vertex(8), true },
                        { new Vertex(9), false },
                        { new Vertex(10), true },
                    }
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }
    }
}
