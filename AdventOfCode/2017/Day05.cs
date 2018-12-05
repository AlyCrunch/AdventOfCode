using System;
using System.Collections.Generic;
using System.Linq;
using static AdventOfCode.Helpers.Utilis;

namespace AdventOfCode._2017
{
    public static class Day5
    {
        static public void GetTest() => Execute(true);

        public static void GetSolution() => Execute();

        private static void Execute(bool test = false, int nbTest = 0)
        {
            var sample = GetFileToArray(GetFilePath(2017, 5, test, nbTest));
            Console.WriteLine($"Answer is part 1 : {Part1(sample)} & part 2 : {Part2(sample)}");
        }

        private static int Part1(string[] lines)
        {
            int[] maze = lines.Select(int.Parse).ToArray();

            int position = 0;
            int OOMaze = maze.Length;
            int moves = 0;

            while (position < OOMaze)
            {
                moves++;
                int temp_position = maze[position];
                maze[position]++;
                position += temp_position;
            }

            return moves;
        }

        private static int Part2(string[] lines)
        {
            int[] maze = lines.Select(int.Parse).ToArray();

            int position = 0;
            int OOMaze = maze.Length;
            int moves = 0;

            while (position < OOMaze)
            {
                moves++;
                int temp_position = maze[position];
                if (temp_position >= 3) maze[position]--;
                else maze[position]++;
                position += temp_position;
            }

            return moves;
        }
    }
}