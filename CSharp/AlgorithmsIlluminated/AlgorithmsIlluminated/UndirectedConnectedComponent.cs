using System.Linq;
using System.Collections.Generic;
using AlgorithmsIlluminated.DataModel;

namespace AlgorithmsIlluminated
{
    public static class UndirectedConnectedComponent
    {
        // Input: undirected graph G = (V, E) in adjacency-list representation, with V = { 1, 2, 3, ..., n}
        // Postcondition: for every u, v ε V, cc(u) = cc(v) if and only if u, v are in the same connected component
        public static void Solve(Graph g)
        {
            // mark all vertices as unexplored
            var explored = g.Vertices
                .Select(v => new { Vertex = v, Explored = false })
                .ToDictionary(x => x.Vertex, x => x.Explored);

            var cc = g.ConnectedComponent;
            var numCc = 0;
            foreach (var i in g.Vertices)
            {
                // avoid redundancy
                if (!explored[i])
                {
                    // new component
                    numCc += 1;
                    cc[i] = numCc;

                    // call BFS starting at v
                    explored[i] = true;
                    var q = new Queue<Vertex>();
                    q.Enqueue(i);

                    while (q.Count > 0)
                    {
                        var v = q.Dequeue();
                        cc[v] = numCc;
                        foreach (var w in g.AdjacencyList[v].Select(e => e.V))
                        {
                            if (!explored[w])
                            {
                                // mark w as explored
                                explored[w] = true;
                                q.Enqueue(w);
                            }
                        }
                    }
                }
            }
        }
    }
}
