using System;
using System.Linq;
namespace _05._Quicksort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]elements=Console.ReadLine().Split(' ')
                .Select(num=>int.Parse(num))
                .ToArray();
            Quicksort(elements,0,elements.Length-1);
            Console.WriteLine(string.Join(' ',elements));
        }

        private static void Quicksort(int[] elements, int start, int end)
        {
            if(start>=end) 
            {
                return;
            }
            var pivot = start;
            var left = start + 1;
            var right = end;
            while (left <= right)
            {
                if (elements[left] > elements[pivot] 
                    && elements[right] < elements[pivot])
                {
                    Swap(left, right, elements);
                }
                if (elements[left] <= elements[pivot])
                {
                    left++;

                }
                if (elements[right] >= elements[pivot])
                {
                    right--;
                }

            }
            Swap(right,pivot, elements);
            var isLeftSubArraySmaller = right - 1 - start < right + 1 - end;
            if (isLeftSubArraySmaller)
            {
                Quicksort(elements, start, right - 1);
                Quicksort(elements, right + 1, end);
            }
            else
            {
                Quicksort(elements, right + 1, end);
                Quicksort(elements, start, right - 1);
               
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