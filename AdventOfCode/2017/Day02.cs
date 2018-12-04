using System;
using System.Collections.Generic;
using System.Linq;
using static AdventOfCode.Helpers.Utilis;

namespace AdventOfCode._2017
{
    public static class Day2
    {
        static public void GetTest(int nb = 0)
        {
            var file = GetFileToArray(GetFilePath(2017, 2, true, nb));
            Console.WriteLine($"Part 1 : {Part1(file)} and Part 2 : {Part2(file)}");
        }

        public static void GetSolution()
        {
            var file = GetFileToArray(GetFilePath(2017, 2));
            Console.WriteLine($"Part 1 : {Part1(file)} and Part 2 : {Part2(file)}");
        }

        static private int Part1(string[] lines)
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


        static private string Part2(string[] lines)
        {
            int[][] arr = new int[lines.Length][];
            int final = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                var arrStr = lines[i].Split(new string[] { "\t", " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                foreach (var value in arrStr)
                {
                    var result = arrStr.FirstOrDefault(x => (value % x == 0) && (value != x));
                    if (result != 0)
                    {
                        final += value / result;
                    }
                }
            }

            return final.ToString();
        }
    }
}
