using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Longest_Common_Subsequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();
            var lcs=new int[str1.Length+1,str2.Length+1];
            for (int row = 1; row < lcs.GetLength(0); row++)
            {
                for (int col = 1; col < lcs.GetLength(1); col++)
                {
                    if (str1[row - 1] == str2[col - 1])
                    {
                        lcs[row,col] = lcs[row-1,col-1]+1;

                    }
                    else
                    {
                        lcs[row, col] = Math.Max(lcs[row, col - 1], lcs[row - 1, col]);
                    }
                }
            }
            Console.WriteLine(lcs[str1.Length,str2.Length]);

        }
    }
}