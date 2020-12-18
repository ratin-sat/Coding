using System.Collections;
using System.Linq;
using System.Collections.Generic;
using AlgorithmsIlluminated;
using AlgorithmsIlluminated.DataModel;
using Xunit;

namespace AlgorithmsIlluminatedTest
{
    public class BreadthFirstSearchTest
    {
        [Fact]
        public void BreadthFirstSearch_SanityCheck()
        {
            var g = TestHelpers.ReadUndirectedGraphFromEdgesListFile(@"resources\Graph_EdgesList4V.txt");
            var s = g.Vertices.First();

            BreadthFirstSearch.Solve(g, s);

            var actual = g.SearchRecord.Explored;
            var expected = new Dictionary<Vertex, bool>
            {
                { new Vertex(1), true },
                { new Vertex(2), true },
                { new Vertex(3), true },
                { new Vertex(4), true },
            };
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(BreadthFirstSearchTestRandomData))]
        public void BreadthFirstSearch_Random(string inputFile, Vertex s, IDictionary<Vertex, bool> expected)
        {
            var g = TestHelpers.ReadUndirectedGraphFromEdgesListFile(inputFile);

            BreadthFirstSearch.Solve(g, s);

            var actual = g.SearchRecord.Explored;
            Assert.Equal(expected, actual);
        }

        private class BreadthFirstSearchTestRandomData : IEnumerable<object[]>
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
