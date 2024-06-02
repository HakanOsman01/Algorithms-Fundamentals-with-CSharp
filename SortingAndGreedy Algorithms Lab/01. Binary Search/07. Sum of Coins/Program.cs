using System;
using System.Linq;
using System.Collections.Generic;

namespace _07._Sum_of_Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var coins = new Queue<int>(Console.ReadLine().Split(", ")
                .Select(int.Parse)
                .OrderByDescending(c => c));
            var target=int.Parse(Console.ReadLine());
            var usedCoins=new Dictionary<int, int>();
            var totalCoins = 0;
            while (target > 0 && coins.Count>0)
            {
                int currentCoint=coins.Dequeue();
                var count = target / currentCoint;
                if (count == 0)
                {
                    continue;
                }
                usedCoins[currentCoint]=count;
                totalCoins += count;
                target %= currentCoint;

            }
            if (target== 0)
            {

                Console.WriteLine($"Number of coins to take: {totalCoins}");
                foreach (var kvp in usedCoins)
                {
                    Console.WriteLine($"{kvp.Value} coin(s) with value {kvp.Key}");
                }
               
            }
            else
            {
                Console.WriteLine("Error");
            }

        }
    }
}