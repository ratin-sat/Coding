namespace AlgorithmsIlluminated.DataModel
{
    public struct Vertex
    {
        public int Id { get; }

        public Vertex(int id)
        {
            this.Id = id;
        }

        public override string ToString()
        {
            return this.Id.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vertex))
            {
                return false;
            }

            var vertex = (Vertex)obj;
            return this.Id == vertex.Id;
        }

        public override int GetHashCode()
        {
            return 2108858624 + this.Id.GetHashCode();
        }

        public static bool operator ==(Vertex left, Vertex right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Vertex left, Vertex right)
        {
            return !(left == right);
        }
    }
}
