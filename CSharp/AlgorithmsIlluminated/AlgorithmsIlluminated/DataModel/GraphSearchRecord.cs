using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsIlluminated.DataModel
{
    public class GraphSearchRecord
    {
        public Vertex Start { get; }

        public IDictionary<Vertex, bool> Explored { get; }

        public IDictionary<Vertex, int> Distance { get; }

        public GraphSearchRecord(Graph graph, Vertex start)
        {
            this.Start = start;
            this.Explored = graph.Vertices
                .Select(v => new { Vertex = v, Explored = false })
                .ToDictionary(x => x.Vertex, x => x.Explored);
            this.Distance = graph.Vertices
                .Select(v => new { Vertex = v, Distance = int.MaxValue })
                .ToDictionary(x => x.Vertex, x => x.Distance);
        }
    }
}
