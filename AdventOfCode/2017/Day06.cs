using System;
using System.Collections.Generic;
using System.Linq;
using static AdventOfCode.Helpers.Utilis;

namespace AdventOfCode._2017
{
    public static class Day6
    {
        static public void GetTest()
        {
            var path = GetFilePath(2017, 6, true);
            Console.WriteLine($"Answer is {GetFileToString(path).MakeMagic()}");
        }

        public static void GetSolution()
        {
            var path = GetFilePath(2017, 6);
            Console.WriteLine($"Answer is {GetFileToString(path).MakeMagic()}");
        }

        static private int MakeMagic(this string file)
        {
            var memoryBlocks = file
                   .Split(new string[] { "\t", " " }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse).ToArray();

            List<string> states = new List<string>();
            int cycles = 0;
            int lengthMB = memoryBlocks.Length;

            do
            {
                states.Add(string.Join("", memoryBlocks));
                int max = memoryBlocks.Max();
                int index = Array.IndexOf(memoryBlocks, max);

                memoryBlocks[index] = 0;

                for (int i = 1; i <= max; i++)
                {
                    if (index + i < lengthMB)
                        memoryBlocks[index + i]++;
                    else
                        memoryBlocks[(index + i) % lengthMB]++;
                }

                cycles++;
            }
            while (!states.Contains(string.Join("", memoryBlocks)));

            return cycles;
        }
    }
}