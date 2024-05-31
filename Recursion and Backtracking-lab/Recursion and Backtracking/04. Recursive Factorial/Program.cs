using System;
using System.Linq;

namespace _04._Recursive_Factorial
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num=int.Parse(Console.ReadLine());
            int fac = CalculateFactorial(num);
            Console.WriteLine(fac);
        }

        private static int CalculateFactorial(int num)
        {
            if (num == 1)
            {
                return 1;
            }
            int fac = num * CalculateFactorial(num - 1);
            return fac;

        }
    }
}