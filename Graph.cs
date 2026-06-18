using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScience
{
    public class Graph<T>
    {
        public List<GraphNode<T>> Nodes { get; set; }
        public HashSet<Edge<T>> Edges { get; set; }


        public Graph()
        {
            Edges = new HashSet<Edge<T>>();
            Nodes = new List<GraphNode<T>>();
        }

        public GraphNode<T> AddNode(T value)
        {
            var node = new GraphNode<T>(value);
            Nodes.Add(node);
            return node;
        }

        public void AddEdgeOneDirection(GraphNode<T> first, GraphNode<T> second, float weight)
        {
            var edge = new Edge<T>(first, second, weight);
            Edges.Add(edge);
            first.AddEdge(edge);

        }
        public void AddEdgeTwoDirection(GraphNode<T> first, GraphNode<T> second, float weight)
        {
            AddEdgeOneDirection(first, second, weight);
            AddEdgeOneDirection(second, first, weight);
        }

    }
    public class Edge<T>
    {
        public GraphNode<T> First { get; set; }
        public GraphNode<T> Last { get; set; }
        public float Weight { get; private set; }
        public Edge(GraphNode<T> first, GraphNode<T> last, float weight)
        {
            First = first;
            Last = last;
            Weight = weight;
        }
    }
    public class GraphNode<T>
    {
        public T Value { get; private set; }
        public List<Edge<T>> Edges { get; private set; }

        public List<GraphNode<T>> Neighbours => Edges.Select(x => x.Last).ToList();
        public GraphNode(T value)
        {
            Value = value;
            Edges = new();
        }
        public void AddEdge(Edge<T> edge)
        {
            Edges.Add(edge);
        }
    }
}