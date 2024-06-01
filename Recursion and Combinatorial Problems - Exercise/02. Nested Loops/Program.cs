using System;
using System.Linq;

namespace _02._Nested_Loops
{
   
    internal class Program
    {
      
        private static int[] combinations;
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            int[]array=new int[n];
            FullArray(array, 0,1);
           combinations = new int[n];
            GenCombinations(array, 0);
            

        }

        private static void FullArray(int[] array, int idx,int n)
        {
            if (idx >= array.Length)
            {
                return;
            }
            array[idx] = n;
            FullArray(array, idx+1, n+1);
        }
        private  static void GenCombinations(int[]array,int idx)
        {
            if(idx>= combinations.Length)
            {
                Console.WriteLine(string.Join(' ',combinations));
                return;
            }
            for (int i = 0; i < array.Length; i++)
            {
                combinations[idx] = array[i];
                GenCombinations(array, idx+1);

            }
        }

      
    }
}