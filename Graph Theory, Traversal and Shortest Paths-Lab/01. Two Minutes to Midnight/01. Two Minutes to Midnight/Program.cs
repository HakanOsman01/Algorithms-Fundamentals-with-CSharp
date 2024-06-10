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
            //var sorted = MergeSort(elements);
            QuickSort(elements, 0, elements.Length - 1);
            Console.WriteLine(string.Join(' ', elements));
        }

        private static int[] MergeSort(int[] elements)
        {
            if (elements.Length <= 1)
            {
                return elements;
            }
            var left = elements.Take(elements.Length / 2).ToArray();
            var right = elements.Skip(elements.Length / 2).ToArray();
            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var merge = new int[left.Length + right.Length];
            var mergeIdx = 0;
            var leftIdx = 0;
            var rightIdx = 0;
            while (leftIdx < left.Length && rightIdx < right.Length)
            {
                if (left[leftIdx] > right[rightIdx])
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
        private static void QuickSort(int[] elements,int start,int end)
        {
            if (start <= end)
            {
                return;
            }
            var pivot = start;
            var left = start+1;
            var right = end;
            while (left <= right)
            {
                if (elements[left] > elements[pivot] 
                    && elements[right] < elements[pivot])
                {
                    Swap(left, right, elements);
                }
                if (elements[left] < elements[pivot])
                {
                    left++;
                }
                if (elements[right] > elements[pivot])
                {
                    right--;
                }

            }
            Swap(start, right, elements);
            QuickSort(elements, right+1, end);

        }
        private static void Swap(int first, int second, int[] elements)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }

    }
}