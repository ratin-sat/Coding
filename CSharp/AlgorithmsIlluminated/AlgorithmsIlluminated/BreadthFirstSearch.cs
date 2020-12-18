using System.Linq;
using System.Collections.Generic;
using AlgorithmsIlluminated.DataModel;

namespace AlgorithmsIlluminated
{
    public static class BreadthFirstSearch
    {
        // Input: graph G = (V, E) in adjacency-list representation, and a vertex s ε V
        // Postcondition: a vertex is reachable from s if and only if it is marked as "explored"
        public static void Solve(Graph g, Vertex s)
        {
            // mark s as explored, all other vertices as unexplored
            g.InitializeSearchRecord(s);
            var explored = g.SearchRecord.Explored;
            explored[s] = true;

            // Q = a queue data structure, initialized with s
            var q = new Queue<Vertex>();
            q.Enqueue(s);

            while (q.Count > 0)
            {
                var v = q.Dequeue();
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
