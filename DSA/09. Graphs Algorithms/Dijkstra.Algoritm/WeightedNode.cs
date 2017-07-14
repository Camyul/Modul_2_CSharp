using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra.Algoritm
{
    public class WeightedNode : IComparable<WeightedNode>
    {
        public WeightedNode(int vertex, int weight)
        {
            Vertex = vertex;
            Weight = weight;
        }

        public int Vertex { get; set; }
        public int Weight { get; set; }

        public int CompareTo(WeightedNode other)
        {
            if (this.Weight.CompareTo(other.Weight) == 0)
            {
                return this.Vertex.CompareTo(other.Vertex);
            }

            return this.Weight.CompareTo(other.Weight);
        }
    }
}
