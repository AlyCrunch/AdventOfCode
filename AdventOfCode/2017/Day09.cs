using System;
using static AdventOfCode.Helpers.Utilis;

namespace AdventOfCode._2017
{
    public static class Day9
    {
        static public void GetTest()
        {
            var path = GetFilePath(2017, 9, true);
            Console.WriteLine($"Answer is {GetFileToString(path).MakeMagic()}");
        }

        public static void GetSolution()
        {
            var path = GetFilePath(2017, 9);
            Console.WriteLine($"Answer is {GetFileToString(path).MakeMagic()}");
        }

        static private int MakeMagic(this string str)
        {
            bool garbage = false;
            int score = 0;
            int depth = 1;

            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];
                if (c == '!') i++;
                else if (garbage && c != '>') continue;
                else if (c == '<') garbage = true;
                else if (c == '>') garbage = false;
                else if (c == '{') score += depth++;
                else if (c == '}') depth--;
            }

            return score;
        }
    }
}