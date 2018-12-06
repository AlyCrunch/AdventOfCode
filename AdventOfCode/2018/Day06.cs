using System;
using static AdventOfCode.Helpers.Utilis;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace AdventOfCode._2018
{
    public static class Day6
    {
        public static void GetTest() => Execute(true);
        public static void GetSolution() => Execute();
        private static void Execute(bool test = false, int nbTest = 0)
        {
            var sample = GetFileToArray(GetFilePath(2018, 6, test, nbTest));
            Console.WriteLine($"Answer is part 1 : {Part1(sample)} & part 2 : {Part2(sample)}");
        }

        private static object Part1(string[] sample)
        {
            (int X, int Y)[] locations = sample.Select(s => StringsToCoord(s.Split(", "))).ToArray();
            
            var greater_location = locations.Aggregate((c, o) => c.X > o.X && c.Y > o.Y ? c : o);
            Dictionary<(int X, int Y), int> areas = new Dictionary<(int X, int Y), int>();


            for (int y = 0; y <= greater_location.Y; y++)
            {
                for (int x = 0; x <= greater_location.X; x++)
                {
                    areas.Add((x,y),FindNearestLocation((x, y), locations));
                }
            }

            var finiteareas = FiniteArea(areas, greater_location);
            var stepsbyareas = areas.GroupBy(x => x.Value).Select(group => new { Value = group.Key, Count = group.Count() });
            List<int> steps = new List<int>();
            foreach (var area in stepsbyareas)
                if (finiteareas.Any(x => x == area.Value)) steps.Add(area.Count);
            return steps.Max();
        }

        private static object Part2(string[] sample)
        {
            return "(nothing)";
        }

        private static int Distance((int X, int Y) f, (int X, int Y) s) => Math.Abs(f.X - s.X) + Math.Abs(f.Y - s.Y);
        private static (int, int) StringsToCoord(string[] c) => (int.Parse(c[0]), int.Parse(c[1]));
        private static int FindNearestLocation((int X, int Y) p, (int X, int Y)[] all)
        {
            Dictionary<int, int> locations_steps = new Dictionary<int, int>();
            for (int i = 0; i < all.Length; i++)
            {
                locations_steps.Add(i, Distance(p, all[i]));
            }
            var min_step = locations_steps.Min(x => x.Value);
            var nearest_locations = locations_steps.Where(x => x.Value.Equals(min_step));

            return (nearest_locations.Count() > 1) ? -1 : nearest_locations.First().Key;
        }
        private static List<int> FiniteArea(Dictionary<(int X, int Y), int> all, (int X, int Y) max_value)
        {

            var allareas = all.GroupBy(x => x.Value).Select(v => v.Key).ToList();
            var infiniteArea = new List<int>();

            infiniteArea.AddRange(all.Where(x => x.Key.Y == 0).Select((i, x) => i.Value).ToList());
            infiniteArea.AddRange(all.Where(x => x.Key.X == 0).Select((i, x) => i.Value).ToList());
            infiniteArea.AddRange(all.Where(x => x.Key.X == max_value.X).Select((i, x) => i.Value).ToList());
            infiniteArea.AddRange(all.Where(x => x.Key.Y == max_value.Y).Select((i, x) => i.Value).ToList());

            infiniteArea = infiniteArea.Distinct().ToList();

            return allareas.Except(infiniteArea).ToList();

        }
    }
}
