using System.Linq;
using System.Collections.Generic;
using AlgorithmsIlluminated.DataModel;

namespace AlgorithmsIlluminated
{
    public static class ShortestPath
    {
        // Input: graph G = (V, E) in adjacency-list representation, and a vertex s ε V
        // Postcondition: for every vertex v ε V, the value l(v) equals the true shortest-path distance dist(s, v)
        public static void Solve(Graph g, Vertex s)
        {
            // mark s as explored, all other vertices as unexplored
            g.InitializeSearchRecord(s);
            var explored = g.SearchRecord.Explored;
            explored[s] = true;

            var distance = g.SearchRecord.Distance;
            distance[s] = 0;

            // Q = a queue data structure, initialized with s
            var q = new Queue<Vertex>();
            q.Enqueue(s);

            while (q.Count > 0)
            {
                var v = q.Dequeue();
                foreach (var w in g.AdjacencyList[v].Select(e => e.V))
                {
                    if (explored[w] == false)
                    {
                        // mark w as explored
                        explored[w] = true;
                        distance[w] = distance[v] + 1;
                        q.Enqueue(w);
                    }
                }
            }
        }
    }
}
