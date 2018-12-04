using System;
using static AdventOfCode.Helpers.Utilis;
using System.Collections.Generic;

namespace AdventOfCode._2018
{
    public static class Day1
    {
        public static void GetSolution(string[] file) =>Console.WriteLine($"Answer part one is {PartOne(file)} & Answer part two is {PartTwo(file)}");

        static int PartOne(string[] inputs)
        {
            int currentFrenquecy = 0;

            foreach (string value_str in inputs)
            {
                currentFrenquecy += int.Parse(value_str);
            }

            return currentFrenquecy;
        }

        static int PartTwo(string[] inputs)
        {
            int currentFrenquecy = 0;

            HashSet<int> frenquencies = new HashSet<int>
            {
                currentFrenquecy
            };

            while (true)
            {
                foreach (string value_str in inputs)
                {
                    currentFrenquecy += int.Parse(value_str);
                    if (frenquencies.Contains(currentFrenquecy)) return currentFrenquecy;
                    else frenquencies.Add(currentFrenquecy);
                }
            }
        }
    }
}
