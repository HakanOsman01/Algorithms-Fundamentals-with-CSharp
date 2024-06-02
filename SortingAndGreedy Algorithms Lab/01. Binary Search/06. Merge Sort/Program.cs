using System;
using System.Linq;

namespace _06._Merge_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split(' ')
               .Select(num => int.Parse(num))
               .ToArray();
            var sorted=MergeSort(elements);
            Console.WriteLine(string.Join(' ',sorted));
        }

        private static int[] MergeSort(int[] elements)
        {
            if (elements.Length <= 1)
            {
                return elements;
            }
            var left=elements.Take(elements.Length/2).ToArray();
            var right=elements.Skip(elements.Length/2).ToArray();
            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var merge=new int[left.Length+right.Length];
            var mergeIdx = 0;
            var leftIdx = 0;
            var rightIdx = 0;
            while(leftIdx < left.Length && rightIdx < right.Length) 
            {
                if (left[leftIdx] < right[rightIdx])
                {
                    merge[mergeIdx++] = left[leftIdx++];
                }
                else
                {
                    merge[mergeIdx++] = right[rightIdx++];
                }
            }
            for (int i = leftIdx; i < left.Length; i++)
            {
                merge[mergeIdx++] = left[i];
            }
            for (int i = rightIdx; i < right.Length; i++)
            {
                merge[mergeIdx++] = right[i];
            }
            return merge;
        }

    }
}