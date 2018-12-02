using System;
using System.Collections.Generic;
using System.Linq;
using static AdventOfCode.Helpers.Utilis;

namespace AdventOfCode._2017
{
    public static class Day7
    {
        static public void GetTest()
        {
            var path = GetFilePath(2017, 7, true);
            Console.WriteLine($"Answer is {GetFileToArray(path).MakeMagic()}");
        }

        public static void GetSolution()
        {
            var path = GetFilePath(2017, 7);
            Console.WriteLine($"Answer is {GetFileToArray(path).MakeMagic()}");
        }

        static private string MakeMagic(this string[] lines)
        {
            var parentsNodes = lines.Where(n => n.Contains("->")).Select(t => Node(t));
            var firstParent = parentsNodes.First(n => parentsNodes.Count(c => c.Item2.Any(x => x.Equals(n.Item1))) == 0);

            return firstParent.Item1;

            Tuple<string, List<string>> Node(string node)
            {
                var twoParts = node.Split(" -> ");
                string nodeName = twoParts[0].Split(' ').First();
                return new Tuple<string, List<string>>(nodeName, twoParts[1].Split(", ").ToList());
            }
        }
    }
}