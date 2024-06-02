using System.Diagnostics.SymbolStore;

namespace _03._Bubble_Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]elements=Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            BubleSort(elements);
            Console.WriteLine(string.Join(' ',elements));
        }

        private static void BubleSort(int[] elements)
        {
            bool isSorted=false;
            var sortedCount = 0;
            while(!isSorted)
            {
                isSorted = true;
                for (int j = 1; j < elements.Length-sortedCount; j++)
                {
                    int i = j - 1;
                    if (elements[i] > elements[j])
                    {
                        Swap(i, j,elements);
                        isSorted = false;
                    }
                }
                sortedCount++;
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