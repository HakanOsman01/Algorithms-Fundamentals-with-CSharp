using System;
using System.Linq;
using System.Collections.Generic;

namespace _02._Topological_Sorting
{
    internal class Program
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int>dependinceies; 
        static void Main(string[] args)
        {
           
            int n=int.Parse(Console.ReadLine());
            graph = ReadGraph(n);
            dependinceies = ExploreDependincies(graph);
            var sorted=new List<string>();
            while(dependinceies.Count > 0)
            {
                var nodeToRemove = dependinceies
                    .FirstOrDefault(d => d.Value == 0).Key;
                if (nodeToRemove == null)
                {
                    break;
                }
                dependinceies.Remove(nodeToRemove);
                sorted.Add(nodeToRemove);
                foreach (var child in graph[nodeToRemove])
                {
                    dependinceies[child]-=1;
                }


            }
            if (dependinceies.Count > 0)
            {
                Console.WriteLine("Invalid topological sorting");
            }
            else
            {
                Console.WriteLine($"Topological sorting: {string.Join(", ",sorted)}");
            }

        }

        private static Dictionary<string, int> ExploreDependincies
            (Dictionary<string, List<string>> graph)
        {
            Dictionary<string, int> result=new Dictionary<string, int>();
            foreach (var kvp in graph)
            {
                var key=kvp.Key;
                var childrens=kvp.Value;
                if (!result.ContainsKey(key))
                {
                    result[key] = 0;
                }
                foreach (var child in childrens)
                {
                    if (!result.ContainsKey(child))
                    {
                        result[child] = 1;
                    }
                    else
                    {
                        result[child] += 1;
                    }
                }

            }
            return result;
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            Dictionary<string, List<string>> result 
                = new Dictionary<string, List<string>>();
            for(int i= 0; i < n; i++)
            {
                string[] line = Console.ReadLine()
                 .Split("->", StringSplitOptions.RemoveEmptyEntries)
                 .Select(s => s.Trim())
                 .ToArray();
                string key = line[0];
            
                if (line.Length == 1)
                {
                    result[key]=new List<string>();
                }
                else
                {
                    var value = line[1]
                   .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                    result[key] = value;
                }

            }
            return result;
        }
    }
}