namespace Days._2023
{
    public static class Scratchcards
    {
        public static int GetPoints(IEnumerable<string> input)
        {
            // "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53"
            var delimiters = new string[] { ": ", " ", "|" };

            return input.Select(x => x.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                .Skip(2).GroupBy(x => x).Count(x => x.Count() > 1).GetPointByGame()).Sum();
        }

        private static int GetPointByGame(this int pairs)
            => 1 * (int)Math.Pow(2, pairs - 1);
    }
}
