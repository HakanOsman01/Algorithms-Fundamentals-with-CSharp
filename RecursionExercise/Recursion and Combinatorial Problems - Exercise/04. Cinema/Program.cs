using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;

namespace _04._Cinema
{
    
    internal class Program
    {
        
        private static string[] names;
        static void Main(string[] args)
        {
            names = Console.ReadLine()
                .Split(", ");
            Dictionary<int, string> indexByNames = ReadSeats();
            Permute(0,indexByNames);
        }

        private static Dictionary<int, string> ReadSeats()
        {
            Dictionary<int, string> seats=new Dictionary<int, string>();
            string command = Console.ReadLine();
            while(command != "generate")
            {
                string[] cmdParams = command
                    .Split('-',StringSplitOptions.RemoveEmptyEntries);
                string name = cmdParams[0];
                int index = int.Parse(cmdParams[1]);
                if (!seats.ContainsKey(index))
                {
                    seats.Add(index, name);
                }
                command = Console.ReadLine();
            }
            return seats;
        }

        private static void Permute(int idx, Dictionary<int, string> indexByNames)
        {
            if (idx >= names.Length)
            {
                string currentNames=string.Join(" ", names);
                string[]arrayNames=currentNames.Split(" ");
                //Console.WriteLine(string.Join(' ',arrayNames));
                bool isValidPermute = true;
                foreach (var kvp in indexByNames)
                {
                    int index = kvp.Key-1;
                    if (arrayNames[index].TrimEnd() == kvp.Value.TrimEnd())
                    {
                        continue;
                    }
                    else
                    {
                        isValidPermute = false;
                        break;
                    }
                }
                if (isValidPermute)
                {
                    Console.WriteLine(string.Join(' ', names));
                }
                return;
            }
            Permute(idx+1,indexByNames);
            for (int i = idx+1; i < names.Length; i++)
            {
                Swap(idx,i);
                Permute(idx+1, indexByNames);
                Swap(idx,i);
            }

        }

        private static void Swap(int first, int second)
        {
            var temp = names[first];
            names[first] = names[second];
            names[second] = temp;
        }
    }
}