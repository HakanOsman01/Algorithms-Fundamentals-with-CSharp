using System;
using System.Globalization;
using System.Linq;
namespace _05._School_Teams
{
    internal class Program
    {
        private static string[] girlsVariation;
        private static string[] boysVariations;
        private static bool[] girsUsedVariation;
        private static bool[] boysUsedVariation;
        private static string [] combinations;
        static void Main(string[] args)
        {
            var girs=Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries).ToList();
            var boys = Console.ReadLine()
                .Split(", ",StringSplitOptions.RemoveEmptyEntries).ToList();
            girlsVariation = new string[3];
            boysVariations = new string[2];
            boysUsedVariation = new bool[boys.Count];
            girsUsedVariation = new bool[girs.Count];
            HashSet<string>allVariationsOfGirls=new HashSet<string>();
            HashSet<string>allVariationsOfBoys=new HashSet<string>();
            GenCombinationsGirls(0, girs,allVariationsOfGirls,0);
            GenCombinationBoys(0, boys, allVariationsOfBoys,0);
            var teams = CombineGirlsWithBoys(allVariationsOfGirls
                , allVariationsOfBoys);
            foreach (var team in teams)
            {
                Console.WriteLine(team);
            }
           
        }

        private static void GenCombinations(List<string> teams, int idx, int startIdx)
        {
            if (idx >= combinations.Length)
            {
                Console.WriteLine($"{string.Join(' ',combinations)}");
                return;
            }
            for (int i = startIdx; i < teams.Count; i++)
            {
                combinations[idx] = teams[i];
                GenCombinations(teams,idx+1,i+1); 
            }
        }

        private static List<string> 
            CombineGirlsWithBoys(HashSet<string> allVariationsOfGirls
            , HashSet<string> allVariationsOfBoys)
        {
            List<string>collection=new List<string>();
            foreach (var girl in allVariationsOfGirls)
            {
                string currrentRowGirl = girl;
                foreach (var boy in allVariationsOfBoys)
                {
                    string currentCombine = currrentRowGirl + ' ' +boy;
                    collection.Add(currentCombine);
                }
            }
           return collection;
        }

        private static void GenCombinationBoys(int idx, 
            List<string> boys, HashSet<string> allVariationsOfBoys,int statIdx)
        {
            if (idx >= boysVariations.Length)
            {
                string currentVariationBoys = string.Join(' ', boysVariations);
                allVariationsOfBoys.Add(currentVariationBoys);
                return;
            }
            for (int i = statIdx; i < boys.Count; i++)
            {
                if (!boysUsedVariation[i])
                {
                    boysUsedVariation[i] = true;
                    boysVariations[idx] = boys[i];
                    GenCombinationBoys(idx + 1, boys, allVariationsOfBoys, i+1);
                    boysUsedVariation[i] = false;

                }
            }
        }

        private static void GenCombinationsGirls(int idx, List<string> girs
            ,  HashSet<string> allVariationsOfGirls,int starInx)
        {
            if (idx >= girlsVariation.Length)
            {
                string currentVariationGirls = string.Join(' ', girlsVariation);
                allVariationsOfGirls.Add(currentVariationGirls);
                return;
            }
            for (int i = starInx; i < girs.Count; i++)
            {
                if (!girsUsedVariation[i])
                {
                    girsUsedVariation[i] = true;
                    girlsVariation[idx] = girs[i];
                    GenCombinationsGirls(idx + 1, girs, allVariationsOfGirls,i+1);
                    girsUsedVariation[i] = false;

                }
            }
        }
    }
}