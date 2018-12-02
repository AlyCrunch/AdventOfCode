using System;
using System.Linq;
using static AdventOfCode.Helpers.Utilis;

namespace AdventOfCode._2017
{
    public static class Day2
    {
        static public void GetTest()
        {
            var path = GetFilePath(2017, 2, true);
            Console.WriteLine($"Answer is {GetFileToArray(path).MakeMagic()}");
        }

        public static void GetSolution()
        {
            var path = GetFilePath(2017, 2);
            Console.WriteLine($"Answer is {GetFileToArray(path).MakeMagic()}");
        }

        static private int MakeMagic(this string[] lines)
        {
            int[][] arr = new int[lines.Length][];
            int result = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                var arrStr = lines[i].Split(new string[] { "\t", " " }, StringSplitOptions.RemoveEmptyEntries);
                arr[i] = arrStr.Select(int.Parse).ToArray();
                result += arr[i].Max() - arr[i].Min();
            }

            return result;
        }
    }
}
