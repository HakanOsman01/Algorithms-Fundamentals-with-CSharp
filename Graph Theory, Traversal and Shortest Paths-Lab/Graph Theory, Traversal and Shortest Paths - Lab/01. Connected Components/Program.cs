using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.ComponentModel.Design;

namespace _01._Connected_Components
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                string currentNode=Console.ReadLine();
                if (string.IsNullOrEmpty(currentNode))
                {
                    graph[i] = new List<int>();
                }
                else
                {
                    var childrens=currentNode.Split(' ')
                        .Select(int.Parse)
                        .ToList();
                    graph[i] = childrens;

                }
            }


            for (int i = 0; i < graph.Length; i++)
            {
                var component = new List<int>();
                  DFS(i, component);
                if (component.Count > 0)
                {
                    Console.WriteLine($"Connected component: {string.Join(' ',component)}");
                }
                
            }


        }
        private static void DFS(int node,List<int>component)
        {
            if (visited[node])
            {
                return;
            }
            visited[node] = true;
            foreach (var child in graph[node])
            {
                DFS(child,component);

            }
            component.Add(node);

        }
     
    }
}