namespace Days
{
    public static class CorruptionChecksum
    {
        static public int GetChecksum(string[] lines)
        => lines.Format()
            .Aggregate(0, (sum, val) => sum + (val.Max() - val.Min()));

        static public int GetEvenChecksum(string[] lines)
        => lines.Format().Aggregate(0, (sum, val)
                 => sum + val
                 .Aggregate(0, (o, p)
                 => (val.Any(x => p != x && p % x == 0)) ?
                 (o + (p / val.First(x => p != x && p % x == 0)))
                 : o));

        static private int[][] Format(this string[] lines)
        => lines.Select(x => x.Split(new string[] { "\t", " " }, StringSplitOptions.RemoveEmptyEntries)
                              .Select(int.Parse).ToArray()).ToArray();
    }
}