using System.Linq;

namespace Days
{
    public static class SonarSweep
    {
        public static int GetDepthNumberInc(IEnumerable<int> values)
            => values.Skip(1).Zip(values).Count(x => x.First > x.Second);

        public static int GetDepthNumberIncGroupedBy3(IEnumerable<int> values)
            => GetDepthNumberInc(values.Skip(2)
                .Zip(values.Skip(1).Zip(values))
                .Select(x => x.First + x.Second.First + x.Second.Second));
    }
}