namespace Days._2023
{
    public static class Scratchcards
    {
        public static int GetPoints(IEnumerable<string> input)
        => input.GetWinningCount().Select(x => x.GetPointByGame()).Sum();

        private static IEnumerable<int> GetWinningCount(this IEnumerable<string> list)
        {
            var delimiters = new string[] { ": ", " ", "|" };

            return list.Select(x => x.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .Skip(2).GroupBy(x => x).Count(x => x.Count() > 1));
        }

        private static int GetPointByGame(this int pairs)
            => 1 * (int)Math.Pow(2, pairs - 1);

        public static int GetNumberCards(IEnumerable<string> input)
        {
            var wonList = input.GetWinningCount();
            var all = Enumerable.Repeat(1, input.Count()).ToArray();

            for (int i = 0; i < input.Count(); i++)
            {
                int nb = wonList.ElementAt(i);
                if (nb == 0) continue;
                for (int j = i + 1; j < i + 1 + nb; j++)
                    all[j] += all[i];

            }
            return all.Sum();
        }
    }
}
