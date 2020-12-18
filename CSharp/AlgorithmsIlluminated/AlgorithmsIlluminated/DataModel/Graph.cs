using System.Linq;
using System.Collections.Generic;

namespace AlgorithmsIlluminated.DataModel
{
    public class Graph
    {
        public IDictionary<Vertex, IList<Edge>> AdjacencyList { get; }

        public IEnumerable<Vertex> Vertices => this.AdjacencyList.Keys;

        public GraphSearchRecord SearchRecord { get; private set; }

        public IDictionary<Vertex, int> ConnectedComponent { get; }

        public IDictionary<Vertex, int> TopologicalOrder { get; }

        public IDictionary<Vertex, int> StronglyConnectedComponent { get; }

        public Graph(IDictionary<Vertex, IList<Edge>> adjacencyList)
        {
            this.AdjacencyList = adjacencyList;
            this.ConnectedComponent = adjacencyList.Keys
                .Select(v => new { V = v, Cc = 0 })
                .ToDictionary(x => x.V, x => x.Cc);
            this.TopologicalOrder = adjacencyList.Keys
                .Select(v => new { Vertex = v, Order = 0 })
                .ToDictionary(x => x.Vertex, x => x.Order);
            this.StronglyConnectedComponent = adjacencyList.Keys
                .Select(v => new { V = v, Scc = 0 })
                .ToDictionary(x => x.V, x => x.Scc);
        }

        public void InitializeSearchRecord(Vertex start)
        {
            this.SearchRecord = new GraphSearchRecord(this, start);
        }
    }
}
