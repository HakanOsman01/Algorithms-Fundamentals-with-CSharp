using System;
using System.Linq;
using System.Collections.Generic;

namespace _01._Fibonacci
{
    internal class Program
    {
        private static Dictionary<int, long> cache=new Dictionary<int, long>();
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long fib = CalcFibonacii(n);
            Console.WriteLine(fib);
        }

        private static long CalcFibonacii(int n)
        {
            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            if (n <= 2)
            {
                return 1;
            }
            long result = CalcFibonacii(n - 1) + CalcFibonacii(n - 2);
            cache[n] = result;
            return result;
        
           


        }
    }
}