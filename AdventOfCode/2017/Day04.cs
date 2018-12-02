using System;
using System.Linq;
using static AdventOfCode.Helpers.Utilis;

namespace AdventOfCode._2017
{
    public static class Day4
    {
        static public void GetTest()
        {
            var path = GetFilePath(2017, 4, true);
            Console.WriteLine($"Answer is {GetFileToArray(path).MakeMagic()}");
        }

        public static void GetSolution()
        {
            var path = GetFilePath(2017, 4);
            Console.WriteLine($"Answer is {GetFileToArray(path).MakeMagic()}");
        }

        static private int MakeMagic(this string[] lines)
        {
            var passwordsList = lines.Select(x => x.Split(' ')).ToList();
            return passwordsList.Count(x => x.GroupBy(i => i).Count() == x.Count());
        }
    }
}
