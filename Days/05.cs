using System.Linq;

namespace Days
{
    public static class HydrothermalVenture
    {
        public static int CountOverlaps(IEnumerable<string> datas)
        => GetVerticalsAndHorizontals(FormatDatas(datas))
            .SelectMany(vent => GetPositions(vent))
            .GroupBy(x => x)
            .Where(x => x.Count() >= 2)
            .Count();

        public static int CountOverlapsWithDiagonals(IEnumerable<string> datas)
        => GetVerticalsHorizontalsDiagonals(FormatDatas(datas))
            .SelectMany(vent => GetPositions(vent))
            .GroupBy(x => x)
            .Where(x => x.Count() >= 2)
            .Count();

        public static IEnumerable<((int x, int y) from, (int x, int y) to)> FormatDatas(IEnumerable<string> datas)
         => datas.Select(x => x.Split(" -> ")
         .Select(y => y.Split(',')
         .Select(z => int.Parse(z))))
            .Select(x => ((x.ElementAt(0).ElementAt(0), x.ElementAt(0).ElementAt(1)),
                          (x.ElementAt(1).ElementAt(0), x.ElementAt(1).ElementAt(1))));

        public static IEnumerable<((int x, int y) from, (int x, int y) to)> GetVerticalsAndHorizontals(IEnumerable<((int x, int y) from, (int x, int y) to)> list)
            => list.Where(x => (x.from.x == x.to.x) || (x.from.y == x.to.y));

        public static IEnumerable<((int x, int y) from, (int x, int y) to)> GetVerticalsHorizontalsDiagonals(IEnumerable<((int x, int y) from, (int x, int y) to)> list)
            => list.Where(x => Math.Abs(x.from.x - x.to.x) == Math.Abs(x.from.y - x.to.y) 
                            || (x.from.x == x.to.x) || (x.from.y == x.to.y));

        public static IEnumerable<(int x, int y)> GetPositions(((int x, int y) from, (int x, int y) to) point)
        {
            var a = point.from;
            var b = point.to;
            var rangeX = GetRange(a.x, b.x, Math.Abs(a.y - b.y));
            var rangeY = GetRange(a.y, b.y, Math.Abs(a.x - b.x));

            return rangeX.Zip(rangeY).Select(x => (x.First,x.Second));
        }

        private static IEnumerable<int> GetRange(int from, int to, int maxOther)
            => (from == to) ? Enumerable.Range(0, maxOther + 1).Select(_ => from) :
                (to > from) ? Enumerable.Range(from, to + 1 - from) : Enumerable.Range(to, from + 1 - to).Reverse();
    }
}