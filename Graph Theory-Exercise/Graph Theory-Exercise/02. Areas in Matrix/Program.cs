using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace _02._Areas_in_Matrix
{
    
    internal class Program
    {
        private static char[,] graph;
        private static bool[,] visited;
        static void Main(string[] args)
        {
           int rows=int.Parse(Console.ReadLine());
           int cols=int.Parse(Console.ReadLine());
           graph=ReadGraph(rows,cols);
           visited=new bool[rows,cols];
          SortedDictionary<char,int>lettersByCount=new SortedDictionary<char,int>();
            int areaCount = 0;
           
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (visited[row, col])
                    {
                        continue;
                    }
                    char currentNode = graph[row, col];
                    DFS(row, col, currentNode);
                    if (!lettersByCount.ContainsKey(currentNode))
                    {
                        lettersByCount.Add(currentNode, 1);
                    }
                    else
                    {
                        lettersByCount[currentNode]++;
                    }
                    areaCount++;

                }
            }
            Console.WriteLine($"Areas: {areaCount}");
            foreach (var kvp in lettersByCount)
            {
                Console.WriteLine($"Letter '{kvp.Key}' -> {kvp.Value}");
            }
         
        }

        private static char[,] ReadGraph(int rows, int cols)
        {
            char[,]matrix=new char[rows,cols];
            for (int row = 0; row < rows; row++)
            {
                string currentRow=Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            return matrix;
        }
        private static void DFS(int row,int col,char parentNode)
        {
            if(row<0 || row>=graph.GetLength(0) || 
                col<0 || col >= graph.GetLength(1))
            {
                return;
            }
            if (visited[row, col])
            {
                return;
            }
            if (graph[row, col] != parentNode)
            {
                return;
            }
            visited[row, col] = true;
            DFS(row-1,col,parentNode);
            DFS(row+1, col, parentNode);
            DFS(row, col-1, parentNode);
            DFS(row, col+1, parentNode);

        }
    }
}