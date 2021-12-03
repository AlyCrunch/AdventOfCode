using System.Linq;

namespace Days
{
    public static class BinaryDiagnostic
    {

        public static int[][] SwapArr(IEnumerable<string> datas)
        {
            var nbBits = datas.First().Length;
            var swapped = new int[nbBits][];
            Parallel.For(0, nbBits,
                i => swapped[i] = datas.Select(c => c[i] - '0').ToArray());
            return swapped;
        }

        public static int GetConsumption(IEnumerable<string> datas)
        {
            var gamma = GetGammaRateWithSwap(datas);
            return Convert.ToInt32(gamma, 2) *
                Convert.ToInt32(string.Concat(gamma.Select(x => (x == '0') ? '1' : '0')), 2);
        }

        private static string GetGammaRateWithSwap(IEnumerable<string> datas)
            => string.Join("", SwapArr(datas)
                .Select(x => (x.Sum() > datas.Count() / 2) ? '1' : '0'));
    }
}
