using System;
using static AdventOfCode.Helpers.Utilis;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2018
{
    public static class Day2
    {
        static public void GetTest()
        {
            var file = GetFileToArray(GetFilePath(2018, 2, true));
            Console.WriteLine("Test one");
            Console.WriteLine($"Answer part one is {PartOne(file)}");
            Console.WriteLine($"Answer part two is {PartTwo(file)}");
        }

        static public void GetTest2()
        {
            var file = GetFileToArray(GetFilePath(2018, 2, true, 2));
            Console.WriteLine("\nTest two");
            Console.WriteLine($"Answer part one is {PartOne(file)}");
            Console.WriteLine($"Answer part two is {PartTwo(file)}");
        }

        public static void GetSolution()
        {
            var file = GetFileToArray(GetFilePath(2018, 2));
            Console.WriteLine("\nSolution");
            Console.WriteLine($"Answer part one is {PartOne(file)}");
            Console.WriteLine($"Answer part two is {PartTwo(file)}");
        }

        private static int PartOne(string[] file)
        {
            int twice = 0, thrice = 0;

            foreach (string word in file)
            {
                Dictionary<char, int> wordLetters = new Dictionary<char, int>();
                foreach (char c in word)
                {
                    if (wordLetters.ContainsKey(c))
                        wordLetters[c]++;
                    else
                        wordLetters.Add(c, 1);
                }
                if (wordLetters.ContainsValue(2))
                    twice++;
                if (wordLetters.ContainsValue(3))
                    thrice++;
            }

            return twice * thrice;
        }

        private static string PartTwo(string[] file)
        {
            Tuple<int, string> commonbox = null;
            for (int i = 0; i < file.Count() - 1; i++)
            {
                Tuple<int, string> temp = GetTheMostSimilar(file[i], file.Slice(i + 1, file.Count() - 1));
                if (temp == null)
                    continue;
                if (commonbox is null || temp.Item1 < commonbox.Item1)
                    commonbox = temp;
            }

            return commonbox.Item2;
        }

        private static Tuple<int, string> GetTheMostSimilar(string word, string[] file)
        {
            List<Tuple<int, string>> similarities = new List<Tuple<int, string>>();
            foreach (string w in file)
            {
                var comp = Compare(word, w);
                if (comp != null)
                    similarities.Add(comp);
            }
            
            return similarities.Min();
        }

        private static Tuple<int, string> Compare(string first, string second)
        {
            int diff = 0;
            string common = string.Empty;
            for (int i = 0; i < first.Length; i++)
                if (first[i] != second[i])
                    diff++;
                else
                    common += first[i];
            if (diff == first.Length)
                return null;
            else
                return new Tuple<int, string>(diff, common);
        }
    }
}
