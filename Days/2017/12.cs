namespace Days
{
    public static class DigitalPlumber
    {
        public static int GetNumberProgramZero(string[] v)
        => PartOne(v.Select(x => x.GetSubPrograms()).ToDictionary(x => x.Key, x => x.Value));

        private static KeyValuePair<int, HashSet<int>> GetSubPrograms(this string programs)
        {
            var program = programs.Split(" <-> ");
            var progs = program[1].Split(", ").Select(x => int.Parse(x)).ToHashSet();
            return new KeyValuePair<int, HashSet<int>>(int.Parse(program[0]), progs);
        }

        private static int PartOne(Dictionary<int, HashSet<int>> programs)
        {
            HashSet<int> toExclude = new() { 0 };
            int old_count = 0;

            do
            {
                HashSet<int> containsID = programs.Where(x => x.Value.Intersect(toExclude).Any())
                                                  .Select(id => id.Key).ToHashSet();

                if (old_count == containsID.Count) return toExclude.Count;
                old_count = containsID.Count;
                toExclude.UnionWith(containsID);
            }
            while (true);
        }
    }
}
