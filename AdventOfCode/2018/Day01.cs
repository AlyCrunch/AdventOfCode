using System;
using static AdventOfCode.Helpers.Utilis;
using System.Collections.Generic;

namespace AdventOfCode._2018
{
    public static class Day1
    {
        static public void GetTest()
        {
            //Console.WriteLine($"Answer is {MakeMagic(test)}");
        }

        public static void GetSolution()
        {
            var file = GetFileToArray(GetFilePath(2018, 1));
            Console.WriteLine($"Answer part one is {PartOne(file)}");
            Console.WriteLine($"Answer part two is {PartTwo(file)}");
        }

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
