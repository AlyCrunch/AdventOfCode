using System;
using static AdventOfCode.Helpers.Utilis;

namespace AdventOfCode._2017
{
    public static class Day1
    {
        static public void GetTest(string test)
        {
            Console.WriteLine($"Answer is 1 : {Part1(test)} & 2 : {Part2(test)}");
        }

        public static void GetSolution()
        {
            string c = GetFileToString(GetFilePath(2017,1));
            Console.WriteLine($"Answer is 1 : {Part1(c)} & 2 : {Part2(c)}");
        }

        static private int Part1(string c)
        {
            int sol = 0;
            for (int i = 0; i < c.Length - 1; i++)
            {
                if (c[i] == c[i + 1])
                    sol += (int)Char.GetNumericValue(c[i]);
            }

            if (c[c.Length - 1] == c[0])
                sol += (int)Char.GetNumericValue(c[0]);

            return sol;
        }

        static private int Part2(string c)
        {
            int sol = 0;
            int step = c.Length / 2;
            for (int i = 0; i < step; i++)
            {
                if (c[i] == c[i + step])
                    sol += ((int)Char.GetNumericValue(c[i]) * 2);
            }

            return sol;
        }
    }
}
