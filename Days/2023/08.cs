namespace Days._2023
{
    public static class HauntedWasteland
    {
        private static readonly string[] separators = { " = (", ", ", ")" };
        private static (List<char>, Dictionary<string, (string L, string R)>) Format(string[] input)
        {
            return (input[0].ToList(), input.Skip(2).Select(x =>
            {
                var test = x.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                return (test[0], (test[1], test[2]));
            }).ToDictionary(x => x.Item1, x => x.Item2));
        }

        public static int GetStepsToZZZ(string[] input, string start = "AAA")
        {
            var (direction, nodes) = Format(input);

            int i = 0;
            var currNode = start;
            var dir = new Queue<char>(direction);
            var end = start.Replace('A', 'Z');

            while (currNode != end)
            {
                var nextDir = dir.Dequeue();
                currNode = (nextDir == 'L') ? nodes[currNode].L : nodes[currNode].R;
                i++;
                if (dir.Count == 0) dir = new Queue<char>(direction);
            }
            return i;
        }

        public static int GetSimultaneousToZZZ(string[] input)
        {
            var (direction, nodes) = Format(input);
            var currNode = nodes.Where(x => x.Key[^1] == 'A').Select(x => x.Key);
            var results = currNode.Select(x => GetStepsToZZZ(input, x)).ToList();

            return results.Skip(1).Aggregate(results.First(), (x, next) => LCM.Find(x, next));
        }
    }
}
