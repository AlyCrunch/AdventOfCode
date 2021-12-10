namespace Days
{
    public static class SmokeBasin
    {
        public static int GetRiskLevel(string[] raw)
            => GetLowPoints(GetMap(raw)).Select(x => x.height + 1).Sum();
        private static IEnumerable<(int x, int y, int height)> GetLowPoints(int[][] map)
        {
            var lowPoints = new List<(int x, int y, int height)>();

            for (int x = 0; x < map.Length; x++)
            {
                for (int y = 0; y < map[x].Length; y++)
                {
                    if (IsLowPoint(map, x, y))
                        lowPoints.Add((x, y, map[x][y]));
                }
            };
            return lowPoints;
        }

        private static bool IsLowPoint(int[][] map, int x, int y)
            => map[x][y] < GetValue(map, x - 1, y)
            && map[x][y] < GetValue(map, x + 1, y)
            && map[x][y] < GetValue(map, x, y - 1)
            && map[x][y] < GetValue(map, x, y + 1);

        private static int GetValue(int[][] map, int x, int y)
            => (x < 0 || y < 0 || x >= map.Length || y >= map[x].Length) ? 10 : map[x][y];

        public static int GetAllBasins(string[] raw)
        {
            var map = GetMap(raw);
            return GetLowPoints(map).Select(x => GetBasin(map, x)).OrderByDescending(x => x)
                .Take(3).Aggregate(1,(mult, item) => mult * item);
        }

        public static int GetBasin(int[][] map, (int x, int y, int height) lowPoint)
        {
            var alreadyDone = new List<(int x, int y)>();
            var toTest = new List<(int x, int y)>() { (lowPoint.x, lowPoint.y) };

            do
            {
                var testedPoint = (toTest.First().x, toTest.First().y);
                var points = GetAllHorizontalAndVertical(map, testedPoint.x, testedPoint.y);
                alreadyDone.Add(testedPoint);
                toTest.Remove(testedPoint);
                toTest.AddRange(points.Except(alreadyDone));
                toTest = toTest.Distinct().ToList();
            }
            while (toTest.Count > 0);
            return alreadyDone.Distinct().Count();
        }

        public static IEnumerable<(int x, int y)> GetBasinList(int[][] map, (int x, int y, int height) lowPoint)
        {
            var alreadyDone = new List<(int x, int y)>();
            var toTest = new List<(int x, int y)>() { (lowPoint.x, lowPoint.y) };

            do
            {
                var testedPoint = toTest.First();
                var points = GetAllHorizontalAndVertical(map, testedPoint.x, testedPoint.y);
                alreadyDone.Add(testedPoint);
                toTest.Remove(testedPoint);
                toTest.AddRange(points.Except(alreadyDone));
                toTest = toTest.Distinct().ToList();
            }
            while (toTest.Count > 0);
            return alreadyDone.Distinct();
        }

        private static IEnumerable<(int x, int y)> GetAllHorizontalAndVertical(int[][] map, int x, int y)
        {
            var basin = new List<(int x, int y)>();
            basin.AddRange(GetOneDirection(map, x, y, true, 1));
            basin.AddRange(GetOneDirection(map, x, y, true, -1));
            basin.AddRange(GetOneDirection(map, x, y, false, 1));
            basin.AddRange(GetOneDirection(map, x, y, false, -1));

            return basin.Distinct();
        }

        private static IEnumerable<(int x, int y)> GetOneDirection(int[][] map, int x, int y, bool isX = true, int mult = 1)
        {
            var basin = new List<(int x, int y)>();
            while (GetValue(map, x, y) < 9)
            {
                basin.Add((x, y));
                x = (isX) ? x + mult : x;
                y = (isX) ? y : y + mult;
            }
            return basin;
        }

        public static int[][] GetMap(string[] raw)
            => raw.Select(r => r.Select(x => x - '0').ToArray()).ToArray();
    }
}