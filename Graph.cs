using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerScience
{
    public class Graph<T>
    {
        public List<Node<T>> Nodes { get; set; }
        public HashSet<Edge<T>> Edges { get; set; }


        public Graph()
        {
            Edges = new HashSet<Edge<T>>();
            Nodes = new List<Node<T>>();
        }

        public Node<T> AddNode(T value, List<Node<T>> connection = null)
        {
            var node = new Node<T>(value);
            Nodes.Add(node);
            if (connection != null)
            {
                foreach (var conn in connection)
                {
                    if (conn == null) continue;
                    Edges.Add(new Edge<T>(conn, node));
                }
            }
            return node;
        }

        public void AddEdge(Node<T> first, Node<T> second)
        {
            Edges.Add(new Edge<T>(first, second));

        }

        public class Node<T>
        {
            public T Value { get; private set; }
            public Node(T value)
            {
                Value = value;
            }
        }
        public class Edge<T>
        {
            public Node<T> First { get; set; }
            public Node<T> Last { get; set; }
            public override int GetHashCode()
            {
                return First.GetHashCode() * Last.GetHashCode();
            }
            public Edge(Node<T> first, Node<T> last)
            {
                First = first;
                Last = last;
            }
        }
    }
}