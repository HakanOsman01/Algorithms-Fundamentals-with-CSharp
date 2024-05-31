using System;
using System.Linq;
namespace _03._Generating_0_1_Vectors
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int n=int.Parse(Console.ReadLine());
           int[] vec = new int[n];
            Gen01(vec, 0);
        }

        private static void Gen01(int[] vec, int idx)
        {
           if(idx==vec.Length)
           {
              string row=string.Join(string.Empty, vec);
              Console.WriteLine(row);
              return;

           }
            for (int i = 0; i <= 1; i++)
            {
                vec[idx] = i;
                Gen01(vec, idx + 1);
            }
        }
    }
}