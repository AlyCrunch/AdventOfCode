namespace Days._2023
{
    public static class CamelCards
    {
        private static readonly Dictionary<char, int> VALUES = new()
        {
            { '2', 0 },
            { '3', 1 },
            { '4', 2 },
            { '5', 3 },
            { '6', 4 },
            { '7', 5 },
            { '8', 6 },
            { '9', 7 },
            { 'T', 8 },
            { 'J', 9 },
            { 'Q', 10 },
            { 'K', 11 },
            { 'A', 12 }
        };

        private static readonly Dictionary<char, int> VALUES_J = new()
        {
            { 'J', -1 },
            { '2', 0 },
            { '3', 1 },
            { '4', 2 },
            { '5', 3 },
            { '6', 4 },
            { '7', 5 },
            { '8', 6 },
            { '9', 7 },
            { 'T', 8 },
            { 'Q', 10 },
            { 'K', 11 },
            { 'A', 12 }
        };

        private static List<(string cards, List<(char card, int nb)> figure, int bids)> Format(string[] input)
        {
            return input.Select(x =>
            {
                var s = x.Split(" ");
                return (s[0], s[0].GroupBy(y => y).Select(y => (y.Key, y.Count())).ToList(), int.Parse(s[1]));
            }).ToList();
        }

        public static int GetTotalBids(string[] input)
        => Format(input).OrderBy(x => TypeOfHands(x.figure))
                             .ThenBy(x => VALUES[x.cards[0]])
                             .ThenBy(x => VALUES[x.cards[1]])
                             .ThenBy(x => VALUES[x.cards[2]])
                             .ThenBy(x => VALUES[x.cards[3]])
                             .ThenBy(x => VALUES[x.cards[4]])
                             .Select((x, i) => (i + 1) * x.bids)
                             .Sum(x => x);

        public static int GetTotalBidsJoker(string[] input)
        => Format(input).OrderBy(x => TypeOfHandsJoker(x.figure))
                             .ThenBy(x => VALUES_J[x.cards[0]])
                             .ThenBy(x => VALUES_J[x.cards[1]])
                             .ThenBy(x => VALUES_J[x.cards[2]])
                             .ThenBy(x => VALUES_J[x.cards[3]])
                             .ThenBy(x => VALUES_J[x.cards[4]])
                             .Select((x, i) => (i + 1) * x.bids)
                             .Sum(x => x);

        private static int TypeOfHands(List<(char card, int nb)> figure)
        {
            var nbCards = figure.Select(x => x.nb).OrderBy(x => x).ToArray();

            if (nbCards.SequenceEqual(new int[] { 1, 1, 1, 1, 1 })) return 0;
            if (nbCards.SequenceEqual(new int[] { 1, 1, 1, 2 })) return 1;
            if (nbCards.SequenceEqual(new int[] { 1, 2, 2 })) return 2;
            if (nbCards.SequenceEqual(new int[] { 1, 1, 3 })) return 3;
            if (nbCards.SequenceEqual(new int[] { 2, 3 })) return 4;
            if (nbCards.SequenceEqual(new int[] { 1, 4 })) return 5;
            if (nbCards.SequenceEqual(new int[] { 5 })) return 6;

            throw new IndexOutOfRangeException();
        }
        private static int TypeOfHandsJoker(List<(char card, int nb)> figure)
        {
            var joker = figure.FirstOrDefault(x => x.card == 'J').nb;

            var nbCards = figure.Where(x => x.card != 'J')
                .Select(x => x.nb)
                .OrderBy(x => x).ToArray();
            var last = nbCards.Length - 1;

            if (joker != 5) nbCards[last] += joker;
            else nbCards = nbCards.Append(5).ToArray();

            if (nbCards.SequenceEqual(new int[] { 1, 1, 1, 1, 1 })) return 0;
            if (nbCards.SequenceEqual(new int[] { 1, 1, 1, 2 })) return 1;
            if (nbCards.SequenceEqual(new int[] { 1, 2, 2 })) return 2;
            if (nbCards.SequenceEqual(new int[] { 1, 1, 3 })) return 3;
            if (nbCards.SequenceEqual(new int[] { 2, 3 })) return 4;
            if (nbCards.SequenceEqual(new int[] { 1, 4 })) return 5;
            if (nbCards.SequenceEqual(new int[] { 5 })) return 6;

            throw new Exception();
        }
    }
}
