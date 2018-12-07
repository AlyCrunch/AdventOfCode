using System;
using static AdventOfCode.Helpers.Utilis;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace AdventOfCode._2018
{
    // TODO: Performances issues. 
    public static class Day6
    {
        public static void GetTest() => Execute(true);
        public static void GetSolution() => Execute();
        private static void Execute(bool test = false, int nbTest = 0)
        {
            int limit = (test) ? 32 : 10000;
            var sample = GetFileToArray(GetFilePath(2018, 6, test, nbTest));
            Console.WriteLine($"Answer is part 1 : {Part1(sample, limit)} & part 2 : {Part2(sample, limit)}");
        }

        private static object Part1(string[] sample, int limit)
        {
            (int X, int Y)[] locations = sample.Select(s => StringsToCoord(s.Split(", "))).ToArray();

            var greater_location = locations.Aggregate((c, o) => c.X > o.X && c.Y > o.Y ? c : o);
            Dictionary<(int X, int Y), int> areas = new Dictionary<(int X, int Y), int>();


            for (int y = 0; y <= greater_location.Y; y++)
            {
                for (int x = 0; x <= greater_location.X; x++)
                {
                    areas.Add((x, y), FindNearestLocation((x, y), locations));
                }
            }

            var part2 = 0;
            foreach (var area in areas)
            {
                var totalDistance = 0;
                foreach (var data in locations)
                {
                    totalDistance += Math.Abs(data.X - area.Key.X) + Math.Abs(data.Y - area.Key.Y);
                }

                if (totalDistance < 1000)
                {
                    part2++;
                }
            }

            var finiteareas = FiniteArea(areas, greater_location);
            var stepsbyareas = areas.GroupBy(x => x.Value).Select(group => new { Value = group.Key, Count = group.Count() });
            List<int> steps = new List<int>();
            foreach (var area in stepsbyareas)
                if (finiteareas.Any(x => x == area.Value)) steps.Add(area.Count);
            return steps.Max();
        }

        private static object Part2(string[] sample, int limit)
        {
            (int X, int Y)[] locations = sample.Select(s => StringsToCoord(s.Split(", "))).ToArray();
            List<Point> areas = new List<Point>();

            var greater_location = locations.Aggregate((c, o) => c.X > o.X && c.Y > o.Y ? c : o);

            var y_toAdd = greater_location.Y / 2;
            var x_toAdd = greater_location.X / 2;

            for (int y = 0 - y_toAdd; y <= greater_location.Y + y_toAdd; y++)
            {
                for (int x = 0 - x_toAdd; x <= greater_location.X + x_toAdd; x++)
                {
                    var allLocations = GetAllDistance((x, y), locations);
                    var nearest = FindNearestLocation(allLocations);

                    areas.Add(new Point(nearest.Item1, (x, y), nearest.Item2, GetAllDistance((x, y), locations)));
                }
            }
            
            return areas.Count(m => m.TotalDistance < limit);
        }

        private static int Distance((int X, int Y) f, (int X, int Y) s) => Math.Abs(f.X - s.X) + Math.Abs(f.Y - s.Y);
        private static (int, int) StringsToCoord(string[] c) => (int.Parse(c[0]), int.Parse(c[1]));

        private static Dictionary<int, int> GetAllDistance((int X, int Y) p, (int X, int Y)[] all) => all.Select((coord, index) => new { coord, index })
                                                        .ToDictionary(pair => pair.index, pair => Distance(p, pair.coord));

        private static int FindNearestLocation((int X, int Y) p, (int X, int Y)[] all)
        {
            Dictionary<int, int> locations_steps = GetAllDistance(p, all);

            var min_step = locations_steps.Min(x => x.Value);
            var nearest_locations = locations_steps.Where(x => x.Value.Equals(min_step));

            return (nearest_locations.Count() > 1) ? -1 : nearest_locations.First().Key;
        }

        private static Tuple<int, int> FindNearestLocation(Dictionary<int, int> locations_steps)
        {
            var min_step = locations_steps.Min(x => x.Value);
            var nearest_locations = locations_steps.Where(x => x.Value.Equals(min_step));

            return (nearest_locations.Count() > 1) ? new Tuple<int, int>(-1, nearest_locations.First().Value) : new Tuple<int, int>(nearest_locations.First().Key, nearest_locations.First().Value);
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

        private static Dictionary<(int X, int Y), int> ToDictionary(this List<Point> list) => list.ToDictionary(value => value.Coord, value => value.ID);
    }

    class Point
    {
        public int ID { get; set; }
        public (int X, int Y) Coord { get; set; }
        public int Steps { get; set; }
        public Dictionary<int, int> StepsToPoint { get; set; }
        public string StepsToPointString { get => $"{ID}({Coord}) : " + string.Join(", ", StepsToPoint.Select(x => $"{x.Key} ({x.Value})")) + $" => {TotalDistance}"; }
        public int TotalDistance { get { return StepsToPoint.Where(x => x.Key != -1).Sum(x => x.Value); } }

        public Point(int _id, (int X, int Y) _coord, int _steps, Dictionary<int, int> allDistance)
        {
            ID = _id;
            Coord = _coord;
            Steps = _steps;
            StepsToPoint = allDistance;
        }
    }
}
