using System.Collections.Generic;

namespace ComputerScience
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph<string>();
            var a = graph.AddNode("A");
            var b = graph.AddNode("B");
            var c = graph.AddNode("C");
            var d = graph.AddNode("D");
            var e = graph.AddNode("E");
            var f = graph.AddNode("F");
            graph.AddEdgeTwoDirection(a, b, 7);
            graph.AddEdgeTwoDirection(a, c, 9);
            graph.AddEdgeTwoDirection(a, f, 14);
            graph.AddEdgeTwoDirection(b, c, 1);
            graph.AddEdgeTwoDirection(b, d, 15);
            graph.AddEdgeTwoDirection(c, d, 11);
            graph.AddEdgeTwoDirection(c, f, 2);
            graph.AddEdgeTwoDirection(d, e, 6);
            graph.AddEdgeTwoDirection(f, e, 9);


            var path = Dijkstra(graph, e, b);
            foreach (var node in path)
            {
                Console.WriteLine(node.Value);
            }

        }

        public static List<GraphNode<T>> Dijkstra<T>(Graph<T> graph, GraphNode<T> start, GraphNode<T> Target)
        {
            Dictionary<GraphNode<T>, float> weights = new();
            Dictionary<GraphNode<T>, GraphNode<T>> previousNodes = new();
            PriorityQueue<GraphNode<T>, float> ToVisit = new();
            List<GraphNode<T>> visitedNodes = new();
            foreach (var node in graph.Nodes)
            {
                weights.Add(node, float.MaxValue);
            }
            weights[start] = 0;
            ToVisit.Enqueue(start, 0);
            while (ToVisit.Count > 0)
            {
                var currentNode = ToVisit.Dequeue();
                if (currentNode == Target) break;
                visitedNodes.Add(currentNode);
                foreach (var edge in currentNode.Edges)
                {
                    var node = edge.Last;
                    if (visitedNodes.Contains(node)) continue;
                    float distance = edge.Weight + weights[currentNode];
                    if (distance < weights[node])
                    {
                        ToVisit.Enqueue(node, distance);
                        previousNodes[node] = currentNode;
                        weights[node] = distance;
                    }
                }
            }
            List<GraphNode<T>> path = new();
            var current = Target;
            path.Add(Target);
            while (current != start)
            {
                var temp = previousNodes[current];
                path.Add(temp);
                current = temp;
            }
            path.Reverse();
            return path;
        }

    }
}
