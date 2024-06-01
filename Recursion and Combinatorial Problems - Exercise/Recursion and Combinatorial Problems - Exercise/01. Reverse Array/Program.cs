using System;
using System.Linq;
using System.Security.Principal;

namespace _01._Reverse_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(num => int.Parse(num))
            .ToArray();
            ReverseRecursivelyArray(array, 0, array.Length - 1);
            PrintRecursive(array, 0);
        }

        private static void PrintRecursive(int[] array, int idx)
        {
           if(idx>=array.Length)
           {
                return;
           }
           Console.Write($"{array[idx]} ");
           PrintRecursive(array, idx + 1);

        }

        private static void ReverseRecursivelyArray(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }
            int temp = array[start];
            array[start] = array[end];
            array[end] = temp;
            ReverseRecursivelyArray(array,start+1, end-1);
        }
    }
}