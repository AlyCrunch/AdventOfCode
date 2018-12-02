using System;
using System.Collections.Generic;
using System.Linq;
using static AdventOfCode.Helpers.Utilis;

namespace AdventOfCode._2017
{
    public static class Day8
    {
        static public void GetTest()
        {
            var path = GetFilePath(2017, 8, true);
            Console.WriteLine($"Answer is {GetFileToArray(path).MakeMagic()}");
        }

        public static void GetSolution()
        {
            var path = GetFilePath(2017, 2);
            Console.WriteLine($"Answer is {GetFileToArray(path).MakeMagic()}");
        }

        static private int MakeMagic(this string[] result)
        {
            var instructions = result.Select(t => t.Split(' '));
            Dictionary<string, int> values = new Dictionary<string, int>();

            //b inc 5 if a > 1
            //0 1   2 3  4 5 6
            foreach (var inst in instructions)
            {
                if (!values.ContainsKey(inst[0]))
                    values.Add(inst[0], 0);
                if (!values.ContainsKey(inst[4]))
                    values.Add(inst[4], 0);
                if (Conditional(inst[4], inst[5], int.Parse(inst[6])))
                    Operation(inst[0], inst[1], int.Parse(inst[2]));

            }

            bool Conditional(string key, string op, int value)
            {
                switch (op)
                {
                    case ">": return values[key] > value;
                    case "<": return values[key] < value;
                    case "==": return values[key] == value;
                    case "!=": return values[key] != value;
                    case ">=": return values[key] >= value;
                    case "<=": return values[key] <= value;
                }
                return false;
            }

            void Operation(string key, string op, int value)
            {
                switch (op)
                {
                    case "inc": values[key] += value; break;
                    case "dec": values[key] -= value; break;
                }
            }

            return values.Max(x => x.Value);
        }
    }
}