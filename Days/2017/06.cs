namespace Days._2017
{
    public static class MemoryReallocation
    {
        public static int GetCyclesBeforeConfiguration(string sample)
        {
            return GetMemoryBank(sample.Format()).Count - 1;
        }

        public static int GetCyclesInfiniteLoop(string sample)
        {
            var states = GetMemoryBank(sample.Format());
            var test = states.Where(x => Enumerable.SequenceEqual(x.State, states.Last().State));

            return test.Last().Cycle - test.First().Cycle;
        }
        
        private static List<(int Cycle, int[] State)> GetMemoryBank(int[] MB)
        {
            int cycles = 0;
            int lengthMB = MB.Length;
            List<(int Cycle, int[] State)> states = new() {};

            do
            {
                states.Add((cycles, MB.ToArray()));
                int max = MB.Max();
                int start = Array.IndexOf(MB, max);

                MB[start] = 0;

                int remainder = max % lengthMB;
                for (int i = 1; i <= lengthMB; i++)
                {
                    MB[(start + i) % lengthMB] += max / lengthMB + ((remainder > 0) ? 1 : 0);
                    remainder--;
                }

                cycles++;
            }
            while (!states.Any(x => Enumerable.SequenceEqual(x.State, MB)));
            states.Add((cycles, MB));

            return states;
        }

        private static int[] Format(this string banks)
            => banks.Split(new string[] { "\t", " " }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse).ToArray();
    }
}