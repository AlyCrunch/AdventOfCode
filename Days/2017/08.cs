namespace Days
{
    public static class YouLikeRegisters
    {
        static public int GetLargest(string[] result)
        {
            var instructions = result.Select(t => t.Split(' '));
            Dictionary<string, int> values = new();

            //b inc 5 if a > 1
            //0 1   2 3  4 5 6
            foreach (var inst in instructions)
            {
                if (!values.ContainsKey(inst[0]))
                    values.Add(inst[0], 0);
                if (!values.ContainsKey(inst[4]))
                    values.Add(inst[4], 0);
                if (Conditional(inst[4], inst[5], int.Parse(inst[6])))
                    Operation(inst[0], inst[1], int.Parse(inst[2]));

            }

            bool Conditional(string key, string op, int value)
            {
                switch (op)
                {
                    case ">": return values[key] > value;
                    case "<": return values[key] < value;
                    case "==": return values[key] == value;
                    case "!=": return values[key] != value;
                    case ">=": return values[key] >= value;
                    case "<=": return values[key] <= value;
                    default:
                        break;
                }
                return false;
            }

            void Operation(string key, string op, int value)
            {
                switch (op)
                {
                    case "inc": values[key] += value; break;
                    case "dec": values[key] -= value; break;
                }
            }

            return values.Max(x => x.Value);
        }
    }
}