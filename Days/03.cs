using System.Linq;

namespace Days
{
    public static class BinaryDiagnostic
    {
        private static int[][] SwapArr(IEnumerable<string> datas)
        {
            var nbBits = datas.First().Length;
            var swapped = new int[nbBits][];
            Parallel.For(0, nbBits,
                i => swapped[i] = datas.Select(c => c[i] - '0').ToArray());
            return swapped;
        }

        private static string GetGammaRate(IEnumerable<string> datas)
            => string.Join("", SwapArr(datas)
                .Select(x => (x.Sum() > datas.Count() / 2) ? '1' : '0'));

        public static int GetConsumption(IEnumerable<string> datas)
        {
            var gamma = GetGammaRate(datas);
            return Convert.ToInt32(gamma, 2) *
                Convert.ToInt32(string.Concat(gamma.Select(x => (x == '0') ? '1' : '0')), 2);
        }

        public static int GetLifeSupportRating(IEnumerable<string> datas)
            => Convert.ToInt32(Rating(datas.ToArray()), 2) *
            Convert.ToInt32(Rating(datas.ToArray(), false), 2);

        private static string Rating(IEnumerable<string> datas, bool oxygen = true)
        {
            for (int i = 0; i < datas.First().Length; i++)
            {
                var key = Ordering(datas.GroupBy(x => x[i]),oxygen)
                    .First().Key;
                datas = datas.Where(s => s[i] == key).ToArray();
            }
            return datas.First();
        }

        private static IOrderedEnumerable<IGrouping<char, string>> Ordering(IEnumerable<IGrouping<char, string>> value, bool o = true)
            => (o) ? value.OrderByDescending(x => x.Count())
                    .ThenByDescending(x => x.Key) :
                    value.OrderBy(x => x.Count())
                    .ThenBy(x => x.Key);
    }
}