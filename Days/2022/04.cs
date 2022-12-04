namespace Days._2022
{
    public static class CampCleanup
    {
        public static int CountContained(IEnumerable<string> input)
            => input.Count(x => IsContained(GetRanges(x).ToArray()));

        public static IEnumerable<int> GetRanges(string line)
            => line.Split(',', '-').Select(x => int.Parse(x));

        public static bool IsContained(int[] r)
            => (r[0] >= r[2] && r[1] <= r[3]) ||
               (r[2] >= r[0] && r[3] <= r[1]);


        public static int CountOverlap(IEnumerable<string> input)
            => input.Count(x => IsOverlapping(GetRanges(x).ToArray()));

        public static bool IsOverlapping(int[] r)
            => !(r[0] > r[3] || r[1] < r[2]);

    }
}