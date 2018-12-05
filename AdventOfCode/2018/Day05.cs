using System;
using static AdventOfCode.Helpers.Utilis;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2018
{
    public static class Day5
    {
        static public void GetTest(string str)
        {
            var polymer = PartOne(str);
            var best_polymer = PartTwo(str);
            Console.WriteLine($"The polymer {str} contains {polymer.Count} units ({string.Join("", polymer)})");
            Console.WriteLine($"The best polymer for {str} contains {best_polymer.Item2.Count} units and avoid \"{best_polymer.Item1}\"");
        }

        public static void GetSolution()
        {
            var str = GetFileToString(GetFilePath(2018, 5));
            var polymer = PartOne(str);
            var best_polymer = PartTwo(str);
            Console.WriteLine($"The polymer final contains {polymer.Count} units");
            Console.WriteLine($"The best polymer final contains {best_polymer.Item2.Count} units and avoid \"{best_polymer.Item1}\"");
        }

        private static List<char> PartOne(string input)
        {
            List<char> polymer = input.ToList();

            for (int i = 0; i < input.Length - 1; i++)
            {
                string cur_unit = polymer[i].ToString();
                string next_unit = polymer[i + 1].ToString();

                if (cur_unit.ToUpper() == next_unit.ToUpper() &&
                    ((char.IsUpper(cur_unit[0]) && char.IsLower(next_unit[0])) ||
                    (char.IsLower(cur_unit[0]) && char.IsUpper(next_unit[0]))))

                {
                    polymer.RemoveAt(i + 1);
                    polymer.RemoveAt(i);
                    if (i > 1) i = i - 2;
                    else if (i > 0) i = 0;
                }

                if (i >= polymer.Count - 2) break;
            }

            return polymer;
        }

        private static Tuple<char, List<char>> PartTwo(string input)
        {
            List<char> toTest = input.Select(x => char.ToUpper(x)).Distinct().ToList();
            Tuple<char, List<char>> best_polymer = null;

            foreach (char c in toTest)
            {
                var str_test = input.Where(x => char.ToUpper(x) != c);
                var polymer = PartOne(String.Concat(str_test));
                if (best_polymer == null || best_polymer.Item2.Count > polymer.Count)
                    best_polymer = new Tuple<char, List<char>>(c, polymer);
            }

            return best_polymer;
        }
    }
}
