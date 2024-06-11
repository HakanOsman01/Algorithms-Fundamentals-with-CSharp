using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Move_Down_Right
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows=int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());
            int[,]matrix=ReadMatrix(rows, cols);
            int[,]fullMatrix=FullMatrix(matrix);
            Stack<string> path = GetPath(fullMatrix);
            Console.WriteLine(string.Join(' ',path));
        }

        private static Stack<string> GetPath(int[,] fullMatrix)
        {
            Stack<string> path = new Stack<string>();
            int rows=fullMatrix.GetLength(0)-1;
            int cols=fullMatrix.GetLength(1)-1;
            path.Push($"[{rows}, {cols}]");
            while (rows>0 && cols > 0)
            {
              
                int top = fullMatrix[rows-1,cols];
                int right = fullMatrix[rows,cols-1];
                if (top > right)
                {
                    rows--;
                }
                else
                {
                    cols--;
                }
                path.Push($"[{rows}, {cols}]");

            }
            while (rows > 0)
            {
                rows--;
                path.Push($"[{rows}, {cols}]");
            }
            while(cols > 0)
            {
                cols--;
                path.Push($"[{rows}, {cols}]");
            }
            //path.Push($"[{rows}, {cols}]");
            return path;
        }

        private static int[,] ReadMatrix(int rows, int cols)
        {
            int[,]matrix=new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                int[] currentRow = Console.ReadLine().Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            return matrix;
        }
        private static int[,] FullMatrix(int[,]matrix)
        {
            int[,]fullMatrix=new int[matrix.GetLength(0),matrix.GetLength(1)];
            fullMatrix[0,0]= matrix[0,0];
            
            for (int col = 1; col < fullMatrix.GetLength(1); col++)
            {
               
                fullMatrix[0, col] = fullMatrix[0, col - 1] + matrix[0, col];
              
            }
           
            for (int row = 1; row < fullMatrix.GetLength(0); row++)
            {
               
                fullMatrix[row, 0] = fullMatrix[row-1,0]+matrix[row,0];

            }
            for (int row = 1; row < fullMatrix.GetLength(0); row++)
            {
                for (int col = 1; col < fullMatrix.GetLength(1); col++)
                {

                    int left = fullMatrix[row-1, col];
                    int down = fullMatrix[row, col-1];
                    if (down >= left)
                    {
                        fullMatrix[row, col] = Math.Max(left, down) + matrix[row, col];

                    }
                }
            }
            return fullMatrix;
        }
    }
}