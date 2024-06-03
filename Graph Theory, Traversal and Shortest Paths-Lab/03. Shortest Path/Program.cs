using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Shortest_Path
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] used;
        private static int[] parent;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            graph = new List<int>[n+1];
            used = new bool[graph.Length];
            parent = new int[graph.Length];
            Array.Fill(parent,-1);
            int e=int.Parse(Console.ReadLine());
            for (int i = 0; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0;i < e; i++)
            {
                var edge = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                var firstNode = edge[0];
                var secondNode = edge[1];
                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
            }
            int startNode=int.Parse(Console.ReadLine());
            int destinationNode=int.Parse(Console.ReadLine());
            BFS(startNode,destinationNode);

           
        }

        private static void BFS(int startNode, int destinationNode)
        {
            if (used[startNode])
            {
                return;
            }
            used[startNode]=true;
            var queue=new Queue<int>();
            queue.Enqueue(startNode);
            while (queue.Count > 0)
            {
                int node=queue.Dequeue();
                if (node == destinationNode)
                {
                    var path = FindPath(destinationNode);
                    Console.WriteLine($"Shortest path length is: " +
                        $"{path.Count-1} {string.Join(' ',path)}");
                    break;
                }
                foreach (var child in graph[node])
                {
                    if (!used[child])
                    {
                        queue.Enqueue(child);
                        used[child]=true;
                        parent[child]=node;
                    }
                   
                }
            }
        }

        private static Stack<int> FindPath(int destination)
        {
            Stack<int>path= new Stack<int>();
            var node = destination;
            while (node != -1)
            {
                path.Push(node);
                node = parent[node];
            }
            return path;
            
        }
    }
}