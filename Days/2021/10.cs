namespace Days
{
    public static class SyntaxScoring
    {
        private static readonly (char opening, char closing, int value)[] _syntax =
        {
            ('(',')',3),
            ('[',']',57),
            ('{','}',1197),
            ('<','>',25137)
        };
        private static readonly Dictionary<char, int> _points = new()
        {
            { ')' , 1 },
            { ']' , 2 },
            { '}' , 3 },
            { '>' , 4 },
        };

        public static int GetScore(string[] data)
            => data.Select(x => GetCorruptedChar(x)).Where(x => x != '.')
                .Select(x => _syntax.First(s => s.closing == x).value).Sum();

        public static char GetCorruptedChar(string syntax)
        {
            var opening = new List<char>();
            foreach (var c in syntax)
            {
                if (_syntax.Any(x => x.opening == c))
                {
                    opening.Add(c);
                }
                else
                {
                    bool error = c switch
                    {
                        ')' => (opening.Last() != '('),
                        ']' => (opening.Last() != '['),
                        '}' => (opening.Last() != '{'),
                        '>' => (opening.Last() != '<'),
                        _ => throw new Exception("Char is not ()[]{}<>")
                    };

                    if (error) return c;
                    opening.RemoveAt(opening.Count - 1);
                }
            }
            return '.';
        }

        public static long GetMiddleScore(string[] data)
        {
            var allcompletions = data.Where(x => GetCorruptedChar(x) == '.').Select(x => GetIncompleteChars(x)
            .Aggregate((long)0, (sum, item) => sum * 5 + _points[item]));
            return allcompletions.OrderBy(x => x).ElementAt(allcompletions.Count() / 2);
        }
        public static IEnumerable<char> GetIncompleteChars(string syntax)
        {
            var opening = new List<char>();
            foreach (var c in syntax)
            {
                if (_syntax.Any(x => x.opening == c))
                {
                    opening.Add(c);
                }
                else
                {
                    bool closed = c switch
                    {
                        ')' => (opening.Last() == '('),
                        ']' => (opening.Last() == '['),
                        '}' => (opening.Last() == '{'),
                        '>' => (opening.Last() == '<'),
                        _ => throw new Exception("Char is not ()[]{}<>")
                    };
                    if (closed)
                        opening.RemoveAt(opening.Count - 1);
                }
            }
            return opening.Select(s => _syntax.First(x => x.opening == s).closing).Reverse();
        }

    }
}
