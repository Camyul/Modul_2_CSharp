namespace Friends_of_Pesho
{
    public class Edge
    {
        public Edge(int startNode, int endNode, int weight)
        {
            StartNode = startNode;
            EndNode = endNode;
            Weight = weight;
        }

        public int StartNode { get; set; }
        public int EndNode { get; set; }
        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            int result = this.Weight.CompareTo(other.Weight);

            if (result == 0)
            {
                return this.StartNode.CompareTo(other.StartNode);
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("({0} {1}) -> {2}", this.StartNode, this.EndNode, this.Weight);
        }
    }
}
