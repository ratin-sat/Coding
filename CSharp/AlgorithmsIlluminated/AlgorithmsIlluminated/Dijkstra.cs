using System;
using System.Linq;
using System.Collections.Generic;
using AlgorithmsIlluminated.DataModel;
using AlgorithmsIlluminated.DataStructure;

namespace AlgorithmsIlluminated
{
    public static class Dijkstra
    {
        // Input: directed graph G = (V, E) in adjacency-list representation,
        //   a vertex s ε V, a length le >= 0 for each e ε E
        // Postcondition: for every vertex v, the value len(v) equals the true shortest-path distance dist(s, v)
        public static void Solve(Graph g, Vertex s)
        {
            SolveWithHeap(g, s);
        }

        // the straightforward implementation of Dijkstra's algorithm without using Heap data structure
        private static void SolveWithoutHeap(Graph g, Vertex s)
        {
            // initialization
            g.InitializeSearchRecord(s);
            var len = g.SearchRecord.Distance;
            len[s] = 0;

            // define Dijkstra score
            int DScore(Edge e) => len[e.S] + e.Length;

            // set X contains the vertices that the algorithm has already dealt with
            var x = new HashSet<Vertex> { s };
            // crosses = list of cross-edge (v, w) with v ε X, w ∉ X
            var crosses = x.SelectMany(v => g.AdjacencyList[v]).Where(e => !x.Contains(e.V));
            while (crosses.Count() > 0)
            {
                // find an edge minimizing Dijkstra score
                var vw = crosses.Aggregate((e1, e2) => DScore(e1) < DScore(e2) ? e1 : e2);
                // assign len-value of w and add w to X
                var w = vw.V;
                len[w] = DScore(vw);
                x.Add(w);

                // update cross-edge list
                crosses = x.SelectMany(v => g.AdjacencyList[v]).Where(e => !x.Contains(e.V));
            }
        }

        // the heap-based implementation of Dijkstra's algorithm
        private static void SolveWithHeap(Graph g, Vertex s)
        {
            // initialization
            g.InitializeSearchRecord(s);
            var len = g.SearchRecord.Distance;

            // set X contains the vertices that the algorithm has already dealt with
            var x = new HashSet<Vertex>();
            // heap H contains the as-yet-unprocessed vertex keys
            var h = new Heap<VertexKey>();
            // key(s) = 0, key(v) = infinity where v != s
            var vkmap = g.Vertices
                .Select(v => new { V = v, K = new VertexKey(v, v == s ? 0 : int.MaxValue) })
                .ToDictionary(anon => anon.V, anon => anon.K);
            // heapify keys
            h.Heapify(vkmap.Values);

            // main loop
            while (h.Count() > 0)
            {
                var keyW = h.ExtractMin();
                var w = keyW.Vertex;
                x.Add(w);
                len[w] = keyW.Key;
                // update heap to maintain invariant
                foreach (var e in g.AdjacencyList[w].Where(e => !x.Contains(e.V)))
                {
                    var y = e.V;
                    var dscore = len[w] + e.Length;
                    if (vkmap[y].Key > dscore)
                    {
                        h.Delete(vkmap[y]);
                        vkmap[y] = new VertexKey(y, dscore);
                        h.Insert(vkmap[y]);
                    }
                }
            }
        }

        // key of a vertex - the minimum Dijkstra score of an edge with a starting vertex
        private struct VertexKey : IComparable<VertexKey>
        {
            public Vertex Vertex { get; }

            public int Key { get; }

            public VertexKey(Vertex vertex, int key)
            {
                this.Vertex = vertex;
                this.Key = key;
            }

            public override bool Equals(object obj)
            {
                if (!(obj is VertexKey))
                {
                    return false;
                }

                var key = (VertexKey)obj;
                return EqualityComparer<Vertex>.Default.Equals(this.Vertex, key.Vertex) &&
                       this.Key == key.Key;
            }

            public override int GetHashCode()
            {
                var hashCode = 2142146539;
                hashCode = hashCode * -1521134295 + EqualityComparer<Vertex>.Default.GetHashCode(this.Vertex);
                hashCode = hashCode * -1521134295 + this.Key.GetHashCode();
                return hashCode;
            }

            public int CompareTo(VertexKey other) => this.Key.CompareTo(other.Key);
        }
    }
}
