using System.ComponentModel.Design;

namespace _01._Two_Minutes_to_Midnight
{
    internal class Program
    {
        private static List<int>[] graph;
        private static bool[] visited;
        static void Main(string[] args)
        {
           int n=int.Parse(Console.ReadLine());
           graph=new List<int>[n];
           visited=new bool[n];
           ReadGraph(n);
            
            for (int i = 0; i < graph.Length; i++)
            {
                List<int> components = new List<int>();
                DFS(i, components);
                if(components.Count != 0)
                {
                    Console.WriteLine($"Connected component: {string.Join(' ',components)}");
                }
            }

        }
        private static void ReadGraph(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var childs = Console.ReadLine();
                if (string.IsNullOrEmpty(childs))
                {
                    graph[i] = new List<int>();
                }
                else
                {
                    graph[i] = childs.Split(' ')
                        .Select(int.Parse)
                        .ToList();
                }


            }
        }
        private static void DFS (int node, List<int> components)
        {
            if (visited[node])
            {
                return;
            }
            visited[node]=true;
            foreach (var child in graph[node])
            {
                DFS(child, components);
            }
            components.Add(node);
            
        }

    
    }
}