using System.Linq;
using System.Collections.Generic;
using AlgorithmsIlluminated.DataModel;

namespace AlgorithmsIlluminated
{
    public static class Dijkstra
    {
        // Input: directed graph G = (V, E) in adjacency-list representation,
        //   a vertex s ε V, a length le >= 0 for each e ε E
        // Postcondition: for every vertex v, the value len(v) equals the true shortest-path distance dist(s, v)
        public static void Solve(Graph g, Vertex s)
        {
            SolveWithoutHeap(g, s);
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
    }
}
