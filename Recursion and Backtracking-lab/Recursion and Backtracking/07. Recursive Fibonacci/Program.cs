using System;
using System.Linq;

namespace _07._Recursive_Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int number=int.Parse(Console.ReadLine());
            int fibonacii = CalculateFibonacii(number);
            Console.WriteLine(fibonacii);
        }

        private static int CalculateFibonacii(int number)
        {
          
           if(number <= 1 )
           {
                return 1;

           }
            int firstNumber = CalculateFibonacii(number - 1);
            int secondNumber = CalculateFibonacii(number - 2);
            return firstNumber + secondNumber;
        }
    }
}