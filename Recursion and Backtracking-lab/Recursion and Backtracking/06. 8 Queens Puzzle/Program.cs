using System;
using System.Linq;

namespace _06._8_Queens_Puzzle
{
    
    internal class Program
    {
        private static HashSet<int>right=new HashSet<int>();
        private static HashSet<int>left=new HashSet<int>();
        private static HashSet<int>rightDiagonal=new HashSet<int>();
        private  static HashSet<int>leftDiagonale =new HashSet<int>();

        static void Main(string[] args)
        {
            bool[,] bord = new bool[8, 8];
            GenerateSolutions(bord,0);
        }

        private static void GenerateSolutions(bool[,] bord,int row)
        {
            if (row >= bord.GetLength(0))
            {
                PrintBord(bord);
              
                return;
            }
            for (int col = 0; col < bord.GetLength(1); col++)
            {
                if (IsValidSolution(row, col))
                {
                    left.Add(row);
                    right.Add(col);
                    leftDiagonale.Add(row - col);
                    rightDiagonal.Add(row + col);
                    bord[row,col] = true;
                    GenerateSolutions(bord, row + 1);
                    left.Remove(row);
                    right.Remove(col);
                    leftDiagonale.Remove(row - col);
                    rightDiagonal.Remove(row + col);
                    bord[row, col] = false;



                }
            }
        }
        private  static void PrintBord(bool[,] bord)
        {
            for (int row = 0; row < bord.GetLength(0); row++)
            {
                for (int col = 0; col < bord.GetLength(1); col++)
                {
                    if (bord[row, col] == true)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        private static bool IsValidSolution(int row,int col)
        {
            return !left.Contains(row) && 
                !right.Contains(col) 
                && 
                !leftDiagonale.Contains(row-col) 
                && !rightDiagonal.Contains(row+col);
        }
    }
}