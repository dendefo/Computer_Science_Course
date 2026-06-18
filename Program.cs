using System.Collections.Generic;

namespace ComputerScience
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NetworkDelayTime(null, 0, 0));

        }
        public static int NetworkDelayTime(int[][] times, int n, int k)
        {
            var graph = new Graph<int>();
            foreach (var t in times)
            {
                GraphNode<int> startNode = null;
                GraphNode<int> endNode = null;
                int weight = t[2];
                if (!graph.Nodes.TryGetValue(t[0], out startNode))
                {
                    startNode = graph.AddNode(t[0]);
                }
                if (!graph.Nodes.TryGetValue(t[1], out endNode))
                {
                    endNode = graph.AddNode(t[1]);
                }
                graph.AddEdgeOneDirection(startNode, endNode, weight);
            }
            int longestPath = Dijkstra(graph, graph.Nodes[k]);
            if (longestPath == int.MaxValue) return -1;
            return longestPath;
        }

        public static List<GraphNode<T>> Dijkstra<T>(Graph<T> graph, GraphNode<T> start, GraphNode<T> Target)
        {
            Dictionary<GraphNode<T>, float> weights = new();
            Dictionary<GraphNode<T>, GraphNode<T>> previousNodes = new();
            PriorityQueue<GraphNode<T>, float> ToVisit = new();
            List<GraphNode<T>> visitedNodes = new();
            foreach (var node in graph.Nodes.Values)
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

        public static int Dijkstra<T>(Graph<T> graph, GraphNode<T> start)
        {
            Dictionary<GraphNode<T>, float> weights = new();
            Dictionary<GraphNode<T>, GraphNode<T>> previousNodes = new();
            PriorityQueue<GraphNode<T>, float> ToVisit = new();
            List<GraphNode<T>> visitedNodes = new();
            foreach (var node in graph.Nodes.Values)
            {
                weights.Add(node, float.MaxValue);
            }
            weights[start] = 0;
            ToVisit.Enqueue(start, 0);
            while (ToVisit.Count > 0)
            {
                var currentNode = ToVisit.Dequeue();
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

            return ((int)weights.Max(x => x.Value));
        }
    }
}
