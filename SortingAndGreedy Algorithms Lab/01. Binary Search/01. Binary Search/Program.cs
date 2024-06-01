using System;
using System.Linq;

namespace _01._Binary_Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]elements=Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int number = int.Parse(Console.ReadLine());
            int index=BinarySearch(elements, number);

            Console.WriteLine($"Index of {number} is {index}");




        }

        private static int BinarySearch(int[] elements, int number)
        {
            int start = 0;
            int end = elements.Length - 1;
            while(start<=end)
            {
                int mid=(start+end)/2;
                if (elements[mid] == number)
                {
                    return mid;
                }
                if (elements[mid] < number)
                {
                    start = mid + 1;
                }
                else
                {
                    end=mid - 1;
                }
            }
            return -1;
        }
    }
}