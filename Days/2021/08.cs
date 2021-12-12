namespace Days
{
    public static class SevenSegmentSearch
    {
        public static IEnumerable<IEnumerable<IEnumerable<string>>> Format(string[] datas)
            => datas.Select(x => x.Split(" | ").Select(y => y.Split(' ')));

        public static int GetNumberDigitsWithUniqueSegment(string[] datas)
            => Format(datas).Sum(x => x.ElementAt(1).Count(y => y.Length == 2 || y.Length == 3 || y.Length == 4 || y.Length == 7));

        public static int GetSumOfDigit(string[] datas)
            => Format(datas).Sum(x => GetFourDigit(x));
        public static int GetFourDigit(IEnumerable<IEnumerable<string>> digits)
        {
            var last4 = digits.ElementAt(1).ToArray();
            var code = Decode(digits.SelectMany(x => x));
            return 1000 * code.First(x => x.Value.Length == last4[0].Length && x.Value.All(last4[0].Contains)).Key +
                   100 * code.First(x => x.Value.Length == last4[1].Length && x.Value.All(last4[1].Contains)).Key +
                   10 * code.First(x => x.Value.Length == last4[2].Length && x.Value.All(last4[2].Contains)).Key +
                   code.First(x => x.Value.Length == last4[3].Length && x.Value.All(last4[3].Contains)).Key;
        }

        public static Dictionary<int, string> Decode(IEnumerable<string> all)
        {
            Dictionary<int, List<string>> grouped = all.GroupBy(x => x.Length)
                .ToDictionary(g => g.Key, g => g.ToList());

            Dictionary<int, string> display = new();

            display.Add(1, grouped[2].First());
            display.Add(7, grouped[3].First());
            display.Add(4, grouped[4].First());
            display.Add(8, grouped[7].First());
            display.Add(6, grouped[6].First(x => !display[1].All(c => x.Contains(c))));
            display.Add(9, grouped[6].First(x => x != display[6] && display[4].All(c => x.Contains(c))));
            display.Add(0, grouped[6].First(x => x != display[6] && x != display[9]));
            display.Add(3, grouped[5].First(x => display[1].All(c => x.Contains(c))));
            var c = display[1].Except(display[6]).First();
            display.Add(2, grouped[5].First(x => x != display[3] && x.Contains(c)));
            display.Add(5, grouped[5].First(x => x != display[3] && x != display[2]));


            return display;
        }
    }
}
