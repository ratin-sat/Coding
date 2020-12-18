using System.Linq;
using AlgorithmsIlluminated.DataModel;

namespace AlgorithmsIlluminated
{
    public static class TopologicalSort
    {
        // Input: a directed acyclic graph G = (V, E)
        // Output: the f-values of vertices constitute a topological ordering of G
        //   A topological ordering of G is an assignment f(v) of every vertex v ε V to a different number
        //   such that for every (v, w) ε E, f(v) < f(w)
        public static void Solve(Graph g)
        {
            // mark all vertices as unexplored
            var explored = g.Vertices
                .Select(v => new { Vertex = v, Explored = false })
                .ToDictionary(x => x.Vertex, x => x.Explored);

            var curLabel = g.Vertices.Count();

            // mark every vertex reachable from s as explored and assign f-value
            void DFSTopo(Vertex s)
            {
                // mark s as explored
                explored[s] = true;

                foreach (var v in g.AdjacencyList[s].Select(e => e.V))
                {
                    if (!explored[v])
                    {
                        DFSTopo(v);
                    }
                }

                // s's position in ordering
                g.TopologicalOrder[s] = curLabel;
                curLabel = curLabel - 1;
            }

            foreach (var v in g.Vertices)
            {
                if (!explored[v])
                {
                    DFSTopo(v);
                }
            }
        }
    }
}
