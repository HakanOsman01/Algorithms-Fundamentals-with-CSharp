using System;
using System.Linq;

namespace _02._Selection_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]elements=Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            SelectionSort(elements);
            Console.WriteLine(string.Join(' ',elements));
        }

        private static void SelectionSort(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < elements.Length; j++)
                {
                    if (elements[min] > elements[j])
                    {
                        min=j;
                    }
                }
                Swap(i, min,elements);
            }
        }

        private static void Swap(int first, int second, int[] elements)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}