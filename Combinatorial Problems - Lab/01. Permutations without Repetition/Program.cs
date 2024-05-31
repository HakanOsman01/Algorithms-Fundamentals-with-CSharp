namespace _01._Permutations_without_Repetition
{
    internal class Program
    {
        private static string [] elements;
        private static string []permutions;
        static void Main(string[] args)
        {
            elements=Console.ReadLine()
           .Split(' ',StringSplitOptions.RemoveEmptyEntries)
           .ToArray();
            permutions=new string[elements.Length];
            Permute(0);
        }

        private static void Permute(int idx)
        {
            if (idx >= permutions.Length)
            {
                Console.WriteLine(string.Join(' ',permutions));
                return;
            }
        }
    }
}