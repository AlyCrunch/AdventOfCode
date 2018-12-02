using System;
using System.Collections.Generic;
using System.Linq;
using static AdventOfCode.Helpers.Utilis;

namespace AdventOfCode._2017
{
    public static class Day5
    {
        static public void GetTest()
        {
            var path = GetFilePath(2017, 5, true);
            Console.WriteLine($"Answer is {GetFileToArray(path).MakeMagic()}");
        }

        public static void GetSolution()
        {
            var path = GetFilePath(2017, 5);
            Console.WriteLine($"Answer is {GetFileToArray(path).MakeMagic()}");
        }

        static private int MakeMagic(this string[] lines)
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
    }
}