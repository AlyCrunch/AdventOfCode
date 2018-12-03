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
            Console.WriteLine($"Answer part one is {PartOne(file)}");
            //Console.WriteLine($"Answer part two is {PartTwo(file)}");
        }
        
        public static void GetSolution()
        {
            var file = GetFileToArray(GetFilePath(2018, 3));
            Console.WriteLine("\nSolution :");
            Console.WriteLine($"Answer part one is {PartOne(file)}");
            //Console.WriteLine($"Answer part two is {PartTwo(file)}");
        }

        public static object PartOne(string[] inputs)
        {
            List<Fabric> fabrics = new List<Fabric>();
            foreach(var input in inputs)
            {
                fabrics.Add(new Fabric(input));
            }

            var allFabrics = fabrics.SelectMany(x => x.Coords).ToList();
            var g_fabrics = allFabrics.GroupBy(x => x)
                                      .Where(g => g.Count() > 1)
                                      .Select(y => new { Element = y.Key, Counter = y.Count() })
                                      .ToList();

            return g_fabrics.Count();
        }

        public static object PartTwo(string[] input)
        {
            return 0;
        }
    }

    public class Fabric
    {
        public Coord Origin { get; set; }
        public Coord Size { get; set; }
        //public List<Coord> Coords { get; set; }
        public List<Tuple<int,int>> Coords { get; set; }

        public Fabric(string str) //#1 @ 1,3: 4x4
        {            
            string[] useful = str.Split(" @ ")[1].Split(": ");

            string origin = useful[0];
            string size = useful[1];

            Origin = new Coord(origin.Split(','));
            Size = new Coord(size.Split('x'));
            //Coords = CalculateAllCoords(Origin, Size);
            Coords = CalculateAllCoordsT(Origin, Size);
        }

        private List<Tuple<int, int>> CalculateAllCoordsT(Coord origin, Coord size)
        {
            List<Tuple<int, int>> coords = new List<Tuple<int, int>>();

            for (int y = 0; y < size.Y; y++)
            {
                for (int x = 0; x < size.X; x++)
                {
                    coords.Add( new Tuple<int, int>(x + origin.X, y + origin.Y));
                }
            }

            return coords;
        }
        private List<Coord> CalculateAllCoords(Coord origin, Coord size)
        {
            List<Coord> coords = new List<Coord>();

            for (int y = 0; y < size.Y; y++)
            {
                for (int x = 0; x < size.X; x++)
                {
                    coords.Add(new Coord(x + origin.X, y + origin.Y));
                }
            }

            return coords;
        }
    }

    public class Coord
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coord(string[] arr)
        {
            X = int.Parse(arr[0]);
            Y = int.Parse(arr[1]);
        }

        public Coord(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    
}
