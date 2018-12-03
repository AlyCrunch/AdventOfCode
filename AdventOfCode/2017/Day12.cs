using System;
using static AdventOfCode.Helpers.Utilis;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017
{
    public static class Day12
    {
        static public void GetTest1()
        {
            var path = GetFilePath(2017, 12, true);
            Console.WriteLine($"Test :\nAnswer is {MakeMagic(GetFileToArray(path))}");
        }

        public static void GetSolution()
        {
            var path = GetFilePath(2017, 12);
            Console.WriteLine($"Solution :\nAnswer is {MakeMagic(GetFileToArray(path))}");
        }

        private static int MakeMagic(string[] v)
        {
            Dictionary<int, HashSet<int>> programs = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < v.Length; i++)
            {
                var vals = v[i].GetSubPrograms();
                programs.TryAdd(vals.Key, vals.Value);
            }

            return PartOne(programs);
        }

        private static KeyValuePair<int, HashSet<int>> GetSubPrograms(this string programs)
        {
            var program = programs.Split(" <-> ");
            var progs = program[1].ToString().Split(", ").Select(x => int.Parse(x)).ToHashSet();
            return new KeyValuePair<int, HashSet<int>>(int.Parse(program[0]), progs);
        }

        private static int PartOne(Dictionary<int, HashSet<int>> programs)
        {
            HashSet<int> toExclude = new HashSet<int> { 0 };
            int old_count = 0;

            do
            {
                HashSet<int> containsID = programs.Where(x => x.Value.Intersect(toExclude).Count() > 0)
                                                  .Select(id => id.Key).ToHashSet();

                if (old_count == containsID.Count()) return toExclude.Count();
                old_count = containsID.Count();
                toExclude.UnionWith(containsID);
            }
            while (true);
        }

        
    }
}
