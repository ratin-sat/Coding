using System.Collections.Generic;

namespace AlgorithmsIlluminated.DataModel
{
    public struct Edge
    {
        public Vertex S { get; }

        public Vertex V { get; }

        public int Length { get; }

        public Edge(Vertex s, Vertex v, int length)
        {
            this.S = s;
            this.V = v;
            this.Length = length;
        }

        public override string ToString()
        {
            return $"({this.S.ToString()}, {this.V.ToString()}) : {Length}";
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Edge))
            {
                return false;
            }

            var edge = (Edge)obj;
            return EqualityComparer<Vertex>.Default.Equals(this.S, edge.S) &&
                   EqualityComparer<Vertex>.Default.Equals(this.V, edge.V) &&
                   this.Length == edge.Length;
        }

        public override int GetHashCode()
        {
            var hashCode = 1752717990;
            hashCode = hashCode * -1521134295 + EqualityComparer<Vertex>.Default.GetHashCode(this.S);
            hashCode = hashCode * -1521134295 + EqualityComparer<Vertex>.Default.GetHashCode(this.V);
            hashCode = hashCode * -1521134295 + this.Length.GetHashCode();
            return hashCode;
        }

        public static bool operator ==(Edge left, Edge right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Edge left, Edge right)
        {
            return !(left == right);
        }
    }
}
