namespace Days
{
    public static class DumboOctopus
    {
        public static int GetCountOfFlashes(string[] input, int steps = 100)
        {
            var states = new List<Dictionary<(int x, int y), int>>() { Format(input) };

            for (int i = 0; i < steps; i++)
                states.Add(GetNextStep(states.Last()));

            return states.Sum(x => x.Count(y => y.Value == 0));
        }
        public static int GetStepAllFlash(string[] input)
        {
            var states = new List<Dictionary<(int x, int y), int>>() { Format(input) };
            int step = 0;
            do
            {
                step++;
                states.Add(GetNextStep(states.Last()));
            }
            while (states.Last().Any(x => x.Value != 0));

            return step;
        }

        private static Dictionary<(int x, int y), int> GetNextStep(Dictionary<(int x, int y), int> octopus)
        {
            octopus = octopus.ToDictionary(key => key.Key, v => v.Value + 1);
            var flashedOctopus = MakeFlash(octopus, new Dictionary<(int x, int y), int>());

            return flashedOctopus.ToDictionary(key => key.Key, v => (v.Value > 9) ? 0 : v.Value);
        }

        private static Dictionary<(int x, int y), int> MakeFlash
            (Dictionary<(int x, int y), int> octopus, Dictionary<(int x, int y), int> flashed, int flashAt = 9)
        {
            var newFlashed = octopus.Where(x => x.Value > flashAt && !flashed.ContainsKey(x.Key));
            
            if (!newFlashed.Any()) return octopus;


            foreach (var kv in newFlashed)
            {
                GetAdjacentsOctopuses(kv.Key).ToList().ForEach(x => { if (octopus.ContainsKey(x)) octopus[x] = octopus[x] + 1; } );
                flashed.Add(kv.Key, kv.Value);
            }

            return MakeFlash(octopus, flashed);
        }

        private static IEnumerable<(int x, int y)> GetAdjacentsOctopuses((int x, int y) coord)
            => new (int x, int y)[]
            {
                (coord.x - 1, coord.y - 1),
                (coord.x - 1, coord.y),
                (coord.x - 1, coord.y + 1),
                (coord.x, coord.y - 1),
                (coord.x, coord.y + 1),
                (coord.x + 1, coord.y - 1),
                (coord.x + 1, coord.y),
                (coord.x + 1, coord.y + 1)
            };

        private static IEnumerable<string> ToString(Dictionary<(int x, int y), int> state)
            => state.GroupBy(x => x.Key.x).Select(o => string.Join("", o.OrderBy(v => v.Key.y).Select(v => v.Value)));

        private static Dictionary<(int x, int y), int> Format(string[] input)
            => input.Select((line, x) => line.Select((value, y) => ((x, y), value - '0')))
                            .SelectMany(x => x)
                            .ToDictionary(key => key.Item1, value => value.Item2);
    }
}