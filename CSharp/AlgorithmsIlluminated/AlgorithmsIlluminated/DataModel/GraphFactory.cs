using System.Collections.Generic;

namespace AlgorithmsIlluminated.DataModel
{
    public static class GraphFactory
    {
        public static Graph CreateUndirectedGraph(IEnumerable<(int i, int j, int l)> edges)
        {
            var adjList = new Dictionary<Vertex, IList<Edge>>();
            foreach (var (i, j, l) in edges)
            {
                var v = new Vertex(i);
                if (!adjList.ContainsKey(v))
                {
                    adjList[v] = new List<Edge>();
                }

                var w = new Vertex(j);
                if (!adjList.ContainsKey(w))
                {
                    adjList[w] = new List<Edge>();
                }

                adjList[v].Add(new Edge(v, w, l));
                adjList[w].Add(new Edge(w, v, l));
            }

            return new Graph(adjList);
        }

        public static Graph CreateDirectedGraph(IEnumerable<(int i, int j, int l)> edges)
        {
            var adjList = new Dictionary<Vertex, IList<Edge>>();
            foreach (var (i, j, l) in edges)
            {
                var v = new Vertex(i);
                if (!adjList.ContainsKey(v))
                {
                    adjList[v] = new List<Edge>();
                }

                var w = new Vertex(j);
                if (!adjList.ContainsKey(w))
                {
                    adjList[w] = new List<Edge>();
                }

                adjList[v].Add(new Edge(v, w, l));
            }

            return new Graph(adjList);
        }
    }
}
