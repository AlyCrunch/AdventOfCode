namespace Days._2023
{
    public static class GearRatios
    {
        private static readonly List<(int, int)> _adjacents = new()
        {
            (-1, -1),
            (-1, 0),
            (-1, 1),
            (0, -1),
            (0, 1),
            (1, -1),
            (1, 0),
            (1, 1),
        };

        public static int SumPartNumbers(IEnumerable<string> input)
        {
            List<int> PartNumbers = new();
            string temp = string.Empty;
            bool isTempPart = false;

            for (int line = 0; line < input.Count(); line++)
            {
                for (int col = 0; col < input.ElementAt(line).Length; col++)
                {
                    if (!char.IsDigit(input.ElementAt(line)[col])) continue;
                    temp += input.ElementAt(line)[col];

                    isTempPart = isTempPart || IsPartNumber(line, col, input);

                    if (!char.IsDigit(input.Get(line, col + 1)))
                    {
                        if (isTempPart)
                        {
                            PartNumbers.Add(int.Parse(temp));
                            isTempPart = false;
                        }
                        temp = string.Empty;
                    }

                }
            }
            return PartNumbers.Sum();
        }

        private static char Get(this IEnumerable<string> map, int row, int col)
            => map.ElementAtOrDefault(row)?.ElementAtOrDefault(col) ?? '.';

        private static bool IsSymbolExceptDot(this char c)
            => c != '.' && c != '\0' && !char.IsDigit(c);

        private static bool IsPartNumber(int row, int col, IEnumerable<string> input)
            => _adjacents.Any(cords => input.Get(row + cords.Item1, col + cords.Item2).IsSymbolExceptDot());

        public static int GetGearRatioSum(IEnumerable<string> input)
        {
            var (numbers, gears) = Format(input);
            return gears.Aggregate(0, (sum, cords) => 
            {
                var adj = GetAdjacentsNumber(numbers, cords);
                if (adj.Count() == 2)
                    return sum + int.Parse(adj.ElementAt(0)) * int.Parse(adj.ElementAt(1));
                return sum;
            });
        }

        private static IEnumerable<string> GetAdjacentsNumber(List<(string num, (int row, int col))> numbers,(int row, int col) coord)
        => _adjacents.Select(adjcoord => numbers.Where(x => x.Item2.row == coord.row + adjcoord.Item1
                                   && coord.col + adjcoord.Item2 >= x.Item2.col 
                                   && coord.col + adjcoord.Item2 < x.Item2.col + x.num.Length)
                                .Select(x => x.num)).SelectMany(x => x).Distinct();

        private static (List<(string num, (int row, int col))>, List<(int row, int col)>) Format(IEnumerable<string> input)
        {
            string temp = string.Empty;
            List<(string num, (int row, int col))> numbers = new();
            List<(int row, int col)> gears = new();

            for (int line = 0; line < input.Count(); line++)
            {
                for (int col = 0; col < input.ElementAt(line).Length; col++)
                {
                    if (input.ElementAt(line)[col] == '*') gears.Add((line, col));
                    if (!char.IsDigit(input.ElementAt(line)[col])) continue;

                    if (!char.IsDigit(input.ElementAt(line)[col])) continue;
                    temp += input.ElementAt(line)[col];

                    if (!char.IsDigit(input.Get(line, col + 1)))
                    {
                        numbers.Add((temp, (line,col - (temp.Length -1))));
                        temp = string.Empty;
                    }
                }
            }

            return (numbers, gears);
        }

    }
}
