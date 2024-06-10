using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Distance_Between_Vertices
{
    internal class Program
    {
        private static Dictionary<int, List<int>> graph;
        static void Main(string[] args)
        {
            graph = new Dictionary<int, List<int>>();
            int countNodes=int.Parse(Console.ReadLine());
            int countDistance = int.Parse(Console.ReadLine());
            ReadGraph(countNodes);
            var distances = ReadDistance(countDistance);
            foreach (var distance in distances)
            {
                int startNode = distance.Item1;
                int endNode = distance.Item2;
                int steps = BFS(startNode, endNode);
                Console.WriteLine($"{{{startNode}, {endNode}}} -> {steps}");
             
               

            }
            
        }
        private static int BFS(int startNode,int endNode)
        {
         
            var queue=new Queue<int>();
            queue.Enqueue(startNode);
            var visited = new HashSet<int>() { startNode };
           var parent=new Dictionary<int, int> { { startNode, -1 } };

         
            while (queue.Count > 0)
            {

                int currentNode=queue.Dequeue();
                if(currentNode == endNode) 
                {
                    int steps = GetSteps(endNode,parent);

                    return steps;
                }
                foreach (var child in graph[currentNode])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                        
                    }
                    queue.Enqueue(child);
                    visited.Add(child);
                    parent[child] = currentNode;

                }
             
            }

            return -1;

        }

        private static int GetSteps(int endNode, Dictionary<int, int> parent)
        {
            int node = endNode;
            int steps = 0;  
            while (node != -1)
            {
                node = parent[node];
                steps++;
                
            }
            return steps-1;
        }

        private static List<(int, int)> ReadDistance(int countDistance)
        {
            List<(int, int)> list = new List<(int, int)>();
            for (int i = 0; i < countDistance; i++)
            {
                string[]info=Console.ReadLine()
                .Split('-',StringSplitOptions.RemoveEmptyEntries)
                .Select(s=>s.Trim())
                .ToArray();
                int firstNode = int.Parse(info[0]);
                int secondNode = int.Parse(info[1]);
                list.Add((firstNode, secondNode));  

            }
            return list;
           
        }

        private static void ReadGraph(int countNodes)
        {
            for (int node = 0; node < countNodes; node++)
            {
                string[]info=Console.ReadLine()
                 .Split(":",StringSplitOptions.RemoveEmptyEntries)
                 .Select(s=>s.Trim())
                 .ToArray();
                int firstNode = int.Parse(info[0]);
                if(info.Length == 1)
                {
                    graph[firstNode] = new List<int>();
                }
                else
                {
                    List<int> secondNode = info[1]
                   .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToList();
                    graph[firstNode]=secondNode;
                }

            }
        }
    }
}