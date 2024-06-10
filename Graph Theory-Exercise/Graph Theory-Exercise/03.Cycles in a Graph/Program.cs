using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.Cycles_in_a_Graph
{
    internal class Program
    {
        private static Dictionary<string,string>graph
            = new Dictionary<string,string>();
        private static HashSet<string> cycles
            = new HashSet<string>();
        private static HashSet<string> visited
            = new HashSet<string>();
        static void Main(string[] args)
        {
            ReadGraph();
            Console.Write("Acyclic: ");
            bool hasCycle = false;
            foreach (string node in graph.Keys)
            {
                try
                {
                    DFS(node);
                }
                catch(ArgumentException ex)
                {
                    Console.Write(ex.Message);
                    hasCycle = true;
                    break;
                }
               
            }
            if(!hasCycle)
            {
                Console.Write("Yes");
            }

        }
        private static void DFS(string node)
        {
            if (!graph.ContainsKey(node))
            {
                return;
            }
            if (cycles.Contains(node))
            {
                throw new ArgumentException("No");
            }
            if(visited.Contains(node))
            {
                return;
            }
            cycles.Add(node);
            visited.Add(node);
          
            foreach (var child in graph[node])
            {
                
                   DFS(child.ToString());

            }
            cycles.Remove(node);
        }
        private static void ReadGraph()
        {
           string info=Console.ReadLine();
            while(info!="End")
            {
                string[]nodes=info
               .Split("-",StringSplitOptions.RemoveEmptyEntries)
               .Select(x => x.Trim())
               .ToArray();
                string firstNode = nodes[0];
                string secondNode = nodes[1];
                if(graph.ContainsKey(firstNode) )
                {
                    graph[firstNode] = secondNode;
                }
                else
                {
                    graph.Add(firstNode, secondNode);
                }
                info = Console.ReadLine();

            }
        }
    }
}