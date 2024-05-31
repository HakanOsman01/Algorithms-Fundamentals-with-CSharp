namespace _01._Recursive_Array_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]array=Console.ReadLine()
            .Split(' ',StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();
            int sum = RecursiveSumArray(array, array.Length - 1);
            Console.WriteLine(sum);
        }

        private static int RecursiveSumArray(int[] array, int idx)
        {
            if (idx == 0)
            {
                return array[idx];
            }
            int currentSum = array[idx]+RecursiveSumArray(array, idx-1);
            return currentSum;
        }
    }
}