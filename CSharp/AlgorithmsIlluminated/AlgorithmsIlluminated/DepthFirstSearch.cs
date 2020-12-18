using System.Linq;
using System.Collections.Generic;
using AlgorithmsIlluminated.DataModel;

namespace AlgorithmsIlluminated
{
    public static class DepthFirstSearch
    {
        // Input: graph G = (V, E) in adjacency-list representation, and a vertex s ε V
        // Postcondition: a vertex is reachable from s if and only if it is marked as "explored"
        public static void Solve(Graph g, Vertex s)
        {
            // mark all vertices as unexplored
            g.InitializeSearchRecord(s);

            DFSIter(g, s);
        }

        // Input: graph G = (V, E) in adjacency-list representation, and a vertex s ε V
        // Postcondition: a vertex is reachable from s if and only if it is marked as "explored"
        private static void DFSIter(Graph g, Vertex s)
        {
            // initialize a stack data structure with s
            var stack = new Stack<Vertex>();
            stack.Push(s);

            var explored = g.SearchRecord.Explored;
            while (stack.Count > 0)
            {
                var v = stack.Pop();
                if (!explored[v])
                {
                    // mark v as explored
                    explored[v] = true;
                    foreach (var w in g.AdjacencyList[v].Select(e => e.V))
                    {
                        stack.Push(w);
                    }
                }
            }
        }

        // Input: graph G = (V, E) in adjacency-list representation, and a vertex s ε V
        // Postcondition: a vertex is reachable from s if and only if it is marked as "explored"
        private static void DFSRecur(Graph g, Vertex s)
        {
            var explored = g.SearchRecord.Explored;

            // mark s as explored
            explored[s] = true;

            foreach (var w in g.AdjacencyList[s].Select(e => e.V))
            {
                if (!explored[w])
                {
                    DFSRecur(g, w);
                }
            }
        }
    }
}
