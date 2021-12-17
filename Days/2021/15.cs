namespace Days._2021
{
    public static class Chiton
    {
        //public static int GetLowestRiskPathSum(string[] datas)
        //{
        //    var map = Format(datas);
        //    return FindAllPaths(map,
        //        new Dictionary<(int x, int y), int>() { { map.First().Key, map.First().Value } },
        //        map.First().Key,
        //        new List<Dictionary<(int x, int y), int>>(),
        //        datas.Length - 1)
        //        .Select(x => x.Sum(y => y.Value)).Min();
        //}

        //private static List<Dictionary<(int x, int y), int>> FindAllPaths(
        //    Dictionary<(int x, int y), int> map,
        //    Dictionary<(int x, int y), int> path,
        //    (int x, int y) lastPath,
        //    List<Dictionary<(int x, int y), int>> paths,
        //    int lastRow)
        //{
        //    if (lastPath.y == lastRow) return paths.Append(path).ToList();

        //    Parallel.ForEach(GetPossiblePaths(lastPath),coord 
        //    =>
        //    {
        //        if (IsPossibleNew(path, coord, map))
        //        {
        //            var newPath = path.ToDictionary(x => x.Key, x => x.Value);
        //            newPath.Add(coord, map[coord]);
        //            FindAllPaths(map, newPath, coord, paths, lastRow);
        //        }
        //    });

        //    return paths;
        //}

        //private static Dictionary<(int x, int y), int> Format(string[] datas)
        //    => datas.Select((line, y) => line.Select((value, x) => (coords: (x, y), value: (value - '0'))))
        //    .SelectMany(x => x)
        //    .ToDictionary(x => x.coords, x => x.value);

        //private static bool IsPossibleNew(Dictionary<(int x, int y), int> map,
        //                                 (int x, int y) coord,
        //                                 Dictionary<(int x, int y), int> values)
        //    => !map.ContainsKey(coord) && values.ContainsKey(coord);

        //private static IEnumerable<(int x, int y)> GetPossiblePaths((int x, int y) coord)
        //    => new (int x, int y)[]
        //    {
        //        (coord.x - 1, coord.y),
        //        (coord.x, coord.y + 1),
        //        (coord.x + 1, coord.y),
        //    };

        public static object AStar((int x, int y) start, (int x, int y) goal, Func<(int x, int y),int> h)
        {
            var openSet = new Dictionary<(int x, int y), int>() { { start, 0 } };
            var cameFrom = new Dictionary<(int x, int y), int>();
            var gScore = CreateMap(start, goal, int.MaxValue);
            gScore[start] = 0;

            var fScore = CreateMap(start, goal, int.MaxValue);
            fScore[start] = Heuristic(start, goal);

            throw new NotImplementedException();
        }

        private static int Heuristic((int x, int y) cell, (int x, int y) end)
            => Math.Max(Math.Abs(end.x - cell.x), Math.Abs(end.y - cell.y));

        public static Dictionary<(int x, int y), int> CreateMap((int x, int y) start, (int x, int y) end, int value)
            => Enumerable.Range(start.y, end.y).Select(y => Enumerable.Range(start.x, end.x).Select(x => (x, y)))
            .SelectMany(x => x)
            .ToDictionary(key => (key.x, key.y), v => value);
    }
}