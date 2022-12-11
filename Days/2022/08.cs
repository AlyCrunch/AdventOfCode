namespace Days._2022
{
    public static class Treetop
    {
        private static int[][] Format(this string[] input)
            => Enumerable.Range(0, input.Length)
            .Aggregate(new List<int[]>(), (map, i) =>
                { map.Add(input[i].Select(x => x - '0').ToArray()); return map; }).ToArray();

        private static bool IsVisible(int x, int y, int[][] map)
        {
            if (x == 0 || y == 0 || x == map.Length - 1 || y == map.Length - 1) return true;
            return GetAllSights(x, y, map).Any(m => map[x][y] > m.Max());
        }

        private static IEnumerable<IEnumerable<int>> GetAllSights(int x, int y, int[][] map)
        {
            var ToTop = Enumerable.Range(0, x).Select(i => map[i][y]).Reverse();
            var ToBottom = Enumerable.Range(x + 1, map.Length - (x + 1)).Select(i => map[i][y]);
            var ToLeft = Enumerable.Range(0, y).Select(i => map[x][i]).Reverse();
            var ToRight = Enumerable.Range(y + 1, map.Length - (y + 1)).Select(i => map[x][i]);

            return new List<IEnumerable<int>>() { ToTop, ToBottom, ToLeft, ToRight };
        }

        private static int GetScenicScore(int x, int y, int[][] map)
        {
            if (x == 0 || y == 0 || x == map.Length - 1 || y == map.Length - 1) return 0;
            return GetAllSights(x, y, map).Aggregate(1, (s, sight) => s * GetNbOfTreeInSight(sight, map[x][y]));
        }

        private static int GetNbOfTreeInSight(IEnumerable<int> sight, int height)
        {
            var element = sight.Select((x, i) => new { Index = i, Height = x }).FirstOrDefault(x => height <= x.Height);
            if (element == null) return sight.Count();
            return element.Index + 1;
        }

        public static int CountTreesVisible(string[] test)
        {
            var formatted = Format(test);

            return Enumerable.Range(0, test.Length).Aggregate(0, (sum, x)
                => sum + Enumerable.Range(0, test.Length).Count(y => IsVisible(x, y, formatted)));
        }

        public static int GetHighestScenicScore(string[] test)
        {
            var formatted = Format(test);

            return Enumerable.Range(0, test.Length).Aggregate(new List<int>(), (lines, x)
                => { lines.Add(
                    Enumerable.Range(0, test.Length).Max(y => GetScenicScore(x, y, formatted))); return lines; })
                                                    .Max();
        }
    }
}