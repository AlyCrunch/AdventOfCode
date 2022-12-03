namespace Days._2022
{
    public static class RucksackReorganization
    {
        public static (string, string) SplitInHalf(string str)
            => (str[..(str.Length / 2)], str[(str.Length / 2)..]);

        public static char GetItem((string first, string second) compartment)
            => compartment.first.Intersect(compartment.second).First();

        public static int GetPriority(this char c)
            => (char.IsLower(c)) ? c - 96 : c - 38;

        public static int GetSumPriorities(IEnumerable<string> input)
            => input.Select(x => GetItem(SplitInHalf(x)).GetPriority()).Sum();

        public static char GetItem(IEnumerable<string> group)
            => group
                .Skip(1)
                .Aggregate(
                    new HashSet<char>(group.First()),
                    (h, e) => { h.IntersectWith(e); return h; }
                ).First();

        public static int GetGroupPriorities(IEnumerable<string> input)
            => input.Chunk(3).Select(x => GetItem(x).GetPriority()).Sum();
    }
}