using System.Linq;
using System.Collections.Generic;
using AlgorithmsIlluminated.DataModel;

namespace AlgorithmsIlluminated
{
    public static class StronglyConnectedComponent
    {
        // Input: directed graph G = (V, E) in adjacency-list representation, with V = { 1, 2, 3, ..., n }
        // Postcondition: for every v, w ε V, scc(v) = scc(w) if and only if v, w are in the same SCC of G
        public static void Solve(Graph g)
        {
            // Grev = G with all edges reversed
            var grev = ReverseGraph(g);

            // first pass of depth-first search
            TopologicalSort.Solve(grev);

            // second pass of depth-first search
            // mark all vertices of G as unexplored
            var explored = g.Vertices
                .Select(v => new { Vertex = v, Explored = false })
                .ToDictionary(x => x.Vertex, x => x.Explored);

            var numScc = 0;

            // Input: directed graph G = (V, E) in adjacency-list representation, and a vertex s ε V
            // Postcondition: every vertex reachable from s is marked as "explored" and has an assigned scc-value
            void DFSScc(Graph graph, Vertex s)
            {
                // mark s as explored
                explored[s] = true;
                graph.StronglyConnectedComponent[s] = numScc;

                foreach (var v in graph.AdjacencyList[s].Select(e => e.V))
                {
                    if (!explored[v])
                    {
                        DFSScc(graph, v);
                    }
                }
            }

            // process each v ε V in increasing order of f(v)
            foreach (var kvp in grev.TopologicalOrder.OrderBy(kvp => kvp.Value))
            {
                var v = kvp.Key;
                if (!explored[v])
                {
                    numScc += 1;
                    // assign scc-values
                    DFSScc(g, v);
                }
            }
        }

        // Input: directed graph G = (V, E) in adjacency-list representation
        // Output: directed graph with all edges reversed
        private static Graph ReverseGraph(Graph g)
        {
            var reversed = new Dictionary<Vertex, IList<Edge>>();
            foreach (var kvp in g.AdjacencyList)
            {
                reversed[kvp.Key] = new List<Edge>();
            }

            foreach (var kvp in g.AdjacencyList)
            {
                foreach (var e in kvp.Value)
                {
                    reversed[e.V].Add(new Edge(e.V, e.S, e.Length));
                }
            }

            return new Graph(reversed);
        }
    }
}
