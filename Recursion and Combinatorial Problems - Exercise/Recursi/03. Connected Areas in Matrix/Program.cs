using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Connected_Areas_in_Matrix
{
    public class Area
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }

    }
    internal class Program
    {
        private static char[,] matrix;
        private static int size;
        private const char VisitedSymbol = 'v';
        static void Main(string[] args)
        {
            int rows=int.Parse(Console.ReadLine());
            int cols=int.Parse(Console.ReadLine());
            matrix = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var colElement=Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colElement[col];

                }
            }
            var areas= new List<Area>();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col <cols; col++)
                {
                    size = 0;
                    ExploreArea(row, col);
                    if (size != 0)
                    {
                        areas.Add(new Area {Row=row, Col=col,Size=size});
                    }
                }
            }
            var sorted = areas.OrderByDescending(a => a.Size)
                .ThenBy(a => a.Row)
                .ThenBy(a => a.Col)
                .ToList();
            Console.WriteLine($"Total areas found: {sorted.Count}");
            for (int i = 0; i < sorted.Count; i++)
            {
                var area = sorted[i];
                Console.WriteLine($"Area #{i + 1} " +
                    $"at ({area.Row}, {area.Col})" +
                    $", size: {area.Size}");

            }
        }

        private static void ExploreArea(int row, int col)
        {
            if (IsOutside(row,col) || IsWall(row,col) || IsVisited(row,col))
            {

                return;

            }
            size += 1;
            matrix[row, col] = VisitedSymbol;
            ExploreArea(row + 1, col);
            ExploreArea(row - 1, col);
            ExploreArea(row , col+1);
            ExploreArea(row , col-1);
        }

        private static bool IsVisited(int row, int col)
        {
            return matrix[row, col] == VisitedSymbol;
        }

        private static bool IsWall(int row, int col)
        {
            return matrix[row, col] == '*';
        }

        private static bool IsOutside(int row, int col)
        {
            return row<0 || row>=matrix.GetLength(0) ||
                col<0 || col>=matrix.GetLength(1);
        }
    }
}