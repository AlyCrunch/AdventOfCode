using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days
{
    public static class SmokeBasin
    {
        public static int GetRiskLevel(string[] raw)
            => GetLowPoint(GetMap(raw)).Select(x => x.height + 1).Sum();
        public static IEnumerable<(int x, int y, int height)> GetLowPoint(int[][] map)
        {
            var lowPoints = new List<(int x, int y, int height)>();

            for (int x = 0; x < map.Length; x++)
            {
                for (int y = 0; y < map[x].Length; y++)
                {
                    if (IsLowPoint(map, x, y))
                        lowPoints.Add((x, y, map[x][y]));
                }
            }
            return lowPoints;
        }

        public static bool IsLowPoint(int[][] map, int x, int y)
            => map[x][y] < GetValue(map, x - 1, y)
            && map[x][y] < GetValue(map, x + 1, y)
            && map[x][y] < GetValue(map, x, y - 1)
            && map[x][y] < GetValue(map, x, y + 1);

        public static int GetValue(int[][] map, int x, int y)
            => (x < 0 || y < 0 || x >= map.Length || y >= map[x].Length) ? 10 : map[x][y];

        public static int[][] GetMap(string[] raw)
            => raw.Select(r => r.Select(x => x - '0').ToArray()).ToArray();
    }
}