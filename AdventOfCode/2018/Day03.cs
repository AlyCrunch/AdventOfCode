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

        public static object Answer(string[] inputs)
        {
            Dictionary<(int X, int Y), HashSet<int>> fabrics = new Dictionary<(int X, int Y), HashSet<int>>();
            HashSet<int> all_claims = new HashSet<int>();
            foreach (var input in inputs)
            {
                Fabric fabric = new Fabric(input);
                all_claims.Add(fabric.ID);
                foreach (var (X, Y) in fabric.Coords)
                {
                    if (fabrics.ContainsKey((X, Y)))
                        fabrics[(X, Y)].Add(fabric.ID);
                    else
                        fabrics.Add((X, Y), new HashSet<int>() { fabric.ID });
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
    }

    //Pretty useless class
    public class Fabric
    {
        public int ID { get; set; }
        public (int X, int Y) Origin { get; set; }
        public (int X, int Y) Size { get; set; }
        public List<(int X, int Y)> Coords { get; set; }

        public Fabric(string str) //#1 @ 1,3: 4x4
        {

            ID = int.Parse(str.Split(" @ ")[0].Split("#", StringSplitOptions.RemoveEmptyEntries).First());
            string[] useful = str.Split(" @ ")[1].Split(": ");

            Origin = GetCoordFromString(useful[0].Split(','));
            Size = GetCoordFromString(useful[1].Split('x'));
            Coords = CalculateAllCoordsT(Origin, Size);
        }

        public (int, int) GetCoordFromString(string[] arr)
        {
            return (int.Parse(arr[0]), int.Parse(arr[1]));
        }

        private List<(int X, int Y)> CalculateAllCoordsT((int X, int Y) origin, (int X, int Y) size)
        {
            List<(int X, int Y)> coords = new List<(int X, int Y)>();

            for (int y = 0; y < size.Y; y++)
            {
                for (int x = 0; x < size.X; x++)
                {
                    coords.Add((x + origin.X, y + origin.Y));
                }
            }

            return coords;
        }
    }

}
