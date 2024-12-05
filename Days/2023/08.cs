namespace Days._2023
{
    public static class HauntedWasteland
    {
        //"AAA = (BBB, BBB)",
        private static readonly string[] separators = { " = (", ", ", ")" };
        private static (List<char>, Dictionary<string, (string L, string R)>) Format(string[] input)
        {
            return (input[0].ToList(), input.Skip(2).Select(x =>
            {
                var test = x.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                return (test[0], (test[1], test[2]));
            }).ToDictionary(x => x.Item1, x => x.Item2));
        }

        public static int GetStepsToZZZ(string[] input)
        {
            var (direction, nodes) = Format(input);

            int i = 0;
            var currNode = "AAA";
            var dir = new Queue<char>(direction);
            while (currNode != "ZZZ")
            {
                var nextDir = dir.Dequeue();
                currNode = (nextDir == 'L') ? nodes[currNode].L : nodes[currNode].R;
                i++;
                if(dir.Count == 0) dir = new Queue<char>(direction);
            }

            return i;
        }

    }
}
