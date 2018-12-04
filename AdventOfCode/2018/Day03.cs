using System;
using static AdventOfCode.Helpers.Utilis;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2018
{
    public static class Day3
    {
        static public void GetTest()
        {
            var file = GetFileToArray(GetFilePath(2018, 3, true));
            Console.WriteLine("Test one :");
            Console.WriteLine(Answer(file));
        }

        public static void GetSolution()
        {
            var file = GetFileToArray(GetFilePath(2018, 3));
            Console.WriteLine("\nSolution :");
            Console.WriteLine(Answer(file));
        }

        private static object Answer(string[] inputs)
        {
            Dictionary<(int X, int Y), HashSet<int>> fabrics = new Dictionary<(int X, int Y), HashSet<int>>();
            HashSet<int> all_claims = new HashSet<int>();
            foreach (var input in inputs)
            {
                int ID = GetIDFromString(input);
                var origin = GetCoordFromString(GetValuePart(input)[0].Split(','));
                var size = GetCoordFromString(GetValuePart(input)[1].Split('x'));
                
                all_claims.Add(ID);

                for (int y = 0; y < size.Y; y++)
                {
                    for (int x = 0; x < size.X; x++)
                    {
                        if (fabrics.ContainsKey((origin.X + x, origin.Y + y)))
                            fabrics[(origin.X + x, origin.Y + y)].Add(ID);
                        else
                            fabrics.Add((origin.X + x, origin.Y + y), new HashSet<int>() { ID });
                    }
                }
            }

            var square_inches = fabrics.Count(x => x.Value.Count > 1);
            var claimed_id = fabrics.Where(x => x.Value.Count > 1)
                .Select(x => x.Value.Select(y => y))
                .ToList()
                .SelectMany(x => x).Distinct().ToHashSet();
            var ID_claimed_not_overlapped = all_claims.Except(claimed_id).First();
            return $"Overlaped inches sq. : {square_inches} & not overlapped ID of claim : {ID_claimed_not_overlapped}";
        }

        private static int GetIDFromString(string str) => int.Parse(str.Split(" @ ")[0].Split("#", StringSplitOptions.RemoveEmptyEntries).First());
        private static string[] GetValuePart(string str) => str.Split(" @ ")[1].Split(": ");
        private static (int X, int Y) GetCoordFromString(string[] arr) => (int.Parse(arr[0]), int.Parse(arr[1]));
    }
}
