namespace Days._2017
{
    public static class YouLikeRegisters
    {
        static public int GetLargest(string[] result)
        {
            var instructions = result.Select(t => t.Split(' '));
            Dictionary<string, int> values = new();

            foreach (var inst in instructions)
            {
                if (!values.ContainsKey(inst[0])) values.Add(inst[0], 0);
                if (!values.ContainsKey(inst[4])) values.Add(inst[4], 0);
                values[inst[0]] = ExecuteInstruction(values, inst);
            }

            return values.Max(x => x.Value);
        }

        static public int GetHighestValue(string[] result)
        {
            var instructions = result.Select(t => t.Split(' '));
            Dictionary<string, int> values = new();
            int highestValue = int.MinValue;

            foreach (var inst in instructions)
            {
                if (!values.ContainsKey(inst[0])) values.Add(inst[0], 0);
                if (!values.ContainsKey(inst[4])) values.Add(inst[4], 0);
                values[inst[0]] = ExecuteInstruction(values, inst);
                if (values[inst[0]] > highestValue) highestValue = values[inst[0]];
            }

            return highestValue;
        }

        private static int ExecuteInstruction(Dictionary<string, int> values, string[] line)
        {
            if (Conditional(line[4], line[5], int.Parse(line[6]), values))
                return Operation(line[0], line[1], int.Parse(line[2]), values);
            return values[line[0]];
        }

        private static int Operation(string key, string op, int value, Dictionary<string, int> values)
            => op switch
            {
                "inc" => values[key] + value,
                "dec" => values[key] - value,
                _ => throw new Exception("Operation invalid : " + op)
            };
        private static bool Conditional(string key, string op, int value, Dictionary<string, int> values)
        => op switch
        {
            ">" => (values[key] > value),
            "<" => (values[key] < value),
            "==" => (values[key] == value),
            "!=" => (values[key] != value),
            ">=" => (values[key] >= value),
            "<=" => (values[key] <= value),
            _ => throw new Exception("Invalid conditional statement : " + op)
        };
    }
}