using System;
using static AdventOfCode.Helpers.Utilis;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017
{
    public static class Day13
    {
        static public void GetTest(int nb = 0)
        {
            var path = GetFilePath(2017, 13, true, nb);
            Console.WriteLine($"Test :\nAnswer is {MakeMagic(GetFileToArray(path))}");
        }

        public static void GetSolution()
        {
            var path = GetFilePath(2017, 13);
            Console.WriteLine($"Solution :\nAnswer is {MakeMagic(GetFileToArray(path))}");
        }

        private static object MakeMagic(string[] v)
        {
            throw new NotImplementedException();
        }
    }
}
