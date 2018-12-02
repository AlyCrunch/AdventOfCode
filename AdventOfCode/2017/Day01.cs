using System;
using static AdventOfCode.Helpers.Utilis;

namespace AdventOfCode._2017
{
    public static class Day1
    {
        static public void GetTest(string test)
        {
            Console.WriteLine($"Answer is {MakeMagic(test)}");
        }

        public static void GetSolution()
        {
            string c = GetFileToString(GetFilePath(2017,1));
            Console.WriteLine($"Answer is {MakeMagic(c)}");
        }

        static public int MakeMagic(string c)
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
    }
}
