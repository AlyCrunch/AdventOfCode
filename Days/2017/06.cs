namespace Days
{
    public static class MemoryReallocation
    {
        public static int GetCyclesBeforeConfiguration(string sample)
        {
            if (States == null) States = GetMemoryBank(sample);

            return States.Count - 1;
        }

        public static int GetCyclesInfiniteLoop(string sample)
        {

            if (States == null) States = GetMemoryBank(sample);
            var test = States.Where(x => x.State.Equals(States.Last().State));

            return test.Last().Cycle - test.First().Cycle;
        }
        
        private static List<(int Cycle, string State)> GetMemoryBank(string sample)
        {
            var memoryBlocks = sample
                   .Split(new string[] { "\t", " " }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse).ToArray();

            List<(int Cycle, string State)> states = new();
            int cycles = 0;
            int lengthMB = memoryBlocks.Length;

            do
            {
                states.Add((cycles, string.Join("", memoryBlocks)));
                int max = memoryBlocks.Max();
                int index = Array.IndexOf(memoryBlocks, max);

                memoryBlocks[index] = 0;

                for (int i = 1; i <= max; i++)
                {
                    if (index + i < lengthMB)
                        memoryBlocks[index + i]++;
                    else
                        memoryBlocks[(index + i) % lengthMB]++;
                }

                cycles++;
            }
            while (!states.Any(x => x.State.Equals(string.Join("", memoryBlocks))));
            states.Add((cycles, string.Join("", memoryBlocks)));            

            return states;
        }

        private static List<(int Cycle, string State)> _states;
        private static List<(int Cycle, string State)> States
        {
            get { return _states; }
            set { _states = value; }
        }
    }
}