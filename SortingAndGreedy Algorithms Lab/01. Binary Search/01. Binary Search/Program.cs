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
            Console.WriteLine(index);

        }

        private static int BinarySearch(int[] elements, int number)
        {
            int left = 0;
            int right = elements.Length - 1;
            while(left<=right)
            {
                int mid=(left +right) / 2;
                if (elements[mid] == number)
                {
                    return mid;
                }
                if (elements[mid] < number)
                {
                    left = mid + 1;
                }
                else
                {
                    right =mid - 1;
                }
            }
            return -1;
        }
    }
}