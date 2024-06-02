﻿using System;
using System.Linq;

namespace _04._Insertion_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine()
                  .Split()
                  .Select(int.Parse)
                  .ToArray();
            InsertionSort(elements);
            Console.WriteLine(string.Join(' ', elements));
        }

        private static void InsertionSort(int[] elements)
        {
            for (int i = 1; i < elements.Length; i++)
            {
                int j = i;
                while(j>0 && elements[j-1] > elements[j])
                {
                    Swap(j, j - 1, elements);
                    j--;

                }

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