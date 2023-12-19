namespace Days
{
    public class Range
    {
        public long x { get; set; }
        public long y { get; set; }

        public Range() { }
        public Range(long x, long y) { this.x = x; this.y = y; }

        public static Range RangeByLength(long x, long r)
            => new(x, x + r - 1);

        public static bool IsOverlapping(Range a, Range b)
            => Math.Max(a.x, b.x) <= Math.Min(a.y, b.y);

        public static Range GetIntersection(Range a, Range b)
            => new(Math.Max(a.x, b.x), Math.Min(a.y, b.y));

        public static IEnumerable<Range> Substract(Range a, Range b)
        {
            if (!IsOverlapping(a, b)) return new Range[] { a };

            if (a.x < b.x && a.y <= b.y)
                return new Range[] { new(a.x, b.x - 1) };

            if (a.x < b.x && a.y > b.y)
                return new Range[] { new(a.x, b.x - 1), new(b.y + 1, a.y) };

            if (a.x >= b.x && a.y <= b.y) return Array.Empty<Range>();

            return new Range[] { new(b.y + 1, a.y) };
        }


        public static List<Range> Substract(Range mainRange, List<Range> subRanges)
        {
            List<Range> remainingRanges = new();

            long currentStart = mainRange.x;

            foreach (var subRange in subRanges)
            {
                if (subRange.y < currentStart || subRange.x >= mainRange.y)
                    continue;

                if (subRange.x > currentStart)
                    remainingRanges.Add(new Range(currentStart, subRange.x - 1));

                currentStart = subRange.y + 1;
            }

            if (currentStart <= mainRange.y)
                remainingRanges.Add(new Range(currentStart, mainRange.y));

            return remainingRanges;
        }

        public override bool Equals(object? obj)
        {
            return obj is Range range &&
                   x == range.x &&
                   y == range.y;
        }

        public override string ToString()
            => $"[{x}, {y}]";

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
    }
}
