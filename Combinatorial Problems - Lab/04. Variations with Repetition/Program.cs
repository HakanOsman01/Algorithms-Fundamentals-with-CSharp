using System;
using System.Linq;
using System.Xml.Linq;

namespace _04._Variations_with_Repetition
{
    internal class Program
    {
        private static string[] elements;
        private static string[] variations;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split()
               .ToArray();
            int k = int.Parse(Console.ReadLine());
            variations = new string[k];
            GenVariations(0);

        }
        private static void GenVariations(int idx)
        {
            if (idx >= variations.Length)
            {
                Console.WriteLine(string.Join(' ', variations));
                return;
            }
            for (int i = 0; i < elements.Length; i++)
            {
                
                    variations[idx] = elements[i];
                    GenVariations(idx + 1);
            }
        }
    }
}