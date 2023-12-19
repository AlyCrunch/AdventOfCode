namespace Days._2023
{
    public static class Fertilizer
    {
        private static (IEnumerable<long>, Dictionary<string, List<(Range d, Range s)>>) Format(IEnumerable<string> input)
        {
            var seeds = input.First().Split(": ")[1].Split(' ').Select(x => long.Parse(x));
            var maps = new Dictionary<string, List<(Range d, Range s)>>();
            var currMap = string.Empty;

            foreach (var str in input.Skip(2))
            {
                if (string.IsNullOrWhiteSpace(str)) continue;
                if (char.IsLetter(str[0]))
                {
                    currMap = str[..^6];
                    maps.TryAdd(currMap, new());
                }
                if (char.IsDigit(str[0]))
                {
                    var data = str.Split(" ").Select(x => long.Parse(x)).ToArray();
                    maps[currMap].Add((Range.RangeByLength(data[0], data[2]), Range.RangeByLength(data[1], data[2])));

                }
            }
            return (seeds, maps);
        }


        public static long GetLowestLocation(IEnumerable<string> input)
        {
            var (seeds, maps) = Format(input);
            return seeds.Select(x => maps.Aggregate(x, (curr, map) => FindDestination(curr, map.Value))).Min();
        }

        private static long FindDestination(long src, List<(Range d, Range s)> map)
        {
            var result = map.FirstOrDefault(x => x.s.x <= src && x.s.y >= src);
            if (result == (null, null)) return src;
            return result.d.x + (src - result.s.x);
        }


        public static long GetClosestLocationRange(IEnumerable<string> input)
        {
            var (seeds, maps) = Format(input);
            var locations = Enumerable.Range(0, seeds.Count() / 2)
                                      .Select(x => Range.RangeByLength(seeds.ElementAt(x * 2), seeds.ElementAt(x * 2 + 1)));
            var test = new List<List<Range>>
            {
                locations.OrderBy(x => x.x).ToList()
            };

            foreach (var map in maps)
            {
                var temp = new List<Range>();
                foreach (var range in test.Last())
                {
                    temp.AddRange(FindDestinationRanges(range, map.Value).ToList());
                }
                test.Add(temp.OrderBy(x => x.x).ToList());
            }

            return test.Last().Min(x => x.x);
        }

        private static IEnumerable<Range> FindDestinationRanges(Range src, List<(Range d, Range s)> map)
        {
            var results = map.Where(dest => Range.IsOverlapping(src, dest.s));

            if (!results.Any()) return new List<Range> { src };

            var nextRange = new List<Range>();
            var rest = new List<Range> { src };
            var allIntersec = new List<Range>();
            foreach (var (d, s) in results.OrderBy(x => x.s.x))
            {
                var adjust = d.x - s.x;
                var intersec = Range.GetIntersection(src, s);
                allIntersec.Add(intersec);
                nextRange.Add(new Range(intersec.x + adjust, intersec.y + adjust));
            }
            nextRange.AddRange(Range.Substract(src, allIntersec));

            return nextRange;
        }
    }
}