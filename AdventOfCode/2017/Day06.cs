using System;
using System.Collections.Generic;
using System.Linq;
using static AdventOfCode.Helpers.Utilis;

namespace AdventOfCode._2017
{
    public static class Day6
    {
        public static void GetTest() => Execute(true);

        public static void GetTest(string str) => Console.WriteLine($"Answer is part 1 : {Part1(str)} & part 2 : {Part2(str)}");

        public static void GetSolution() => Execute();

        private static void Execute(bool test = false, int nbTest = 0)
        {
            var sample = GetFileToString(GetFilePath(2017, 6, test, nbTest));
            Console.WriteLine($"Answer is part 1 : {Part1(sample)} & part 2 : {Part2(sample)}");
        }

        private static int Part1(string sample)
        {
            if (States == null) States = GetMemoryBank(sample);

            return States.Count - 1;
        }

        private static object Part2(string sample)
        {

            if (States == null) States = GetMemoryBank(sample);
            var test = States.Where(x => x.State.Equals(States.Last().State));

            return test.Last().Cycle - test.First().Cycle;
        }
        
        private static List<(int Cycle, string State)> GetMemoryBank(string sample)
        {
            var memoryBlocks = sample
                   .Split(new string[] { "\t", " " }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse).ToArray();

            List<(int Cycle, string State)> states = new List<(int Cycle, string State)>();
            int cycles = 0;
            int lengthMB = memoryBlocks.Length;

            do
            {
                states.Add((cycles, string.Join("", memoryBlocks)));
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
            while (!states.Any(x => x.State.Equals(string.Join("", memoryBlocks))));
            states.Add((cycles, string.Join("", memoryBlocks)));            

            return states;
        }

        private static List<(int Cycle, string State)> _states;
        private static List<(int Cycle, string State)> States
        {
            get { return _states; }
            set { _states = value; }
        }
    }
}