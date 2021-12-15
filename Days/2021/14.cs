namespace Days._2021
{
    public static class ExtendedPolymerization
    {
        public static long GetSubstractMostAndLeastCommon(string[] datas, int step)
        {
            var (template, pairs) = datas.Format();
            var keys = GetKeys(template, pairs, step - 1).GetLastCharValues(pairs);
            return keys.Max(x => x.Value) - keys.Min(x => x.Value);
        }

        public static Dictionary<string, long> GetLastCharValues(this Dictionary<string, long> keys, Dictionary<string, string> pairs)
        {
            Dictionary<string, long> state = new()
            {
                { keys.First().Key[0].ToString(), keys.First().Value }
            };

            foreach (var key in keys)
            {
                if (state.ContainsKey(key.Key[1].ToString())) state[key.Key[1].ToString()] += key.Value;
                else state.Add(key.Key[1].ToString(), key.Value);

                if (state.ContainsKey(pairs[key.Key])) state[pairs[key.Key]] += key.Value;
                else state.Add(pairs[key.Key], key.Value);

            }
            return state;
        }

        public static Dictionary<string, long> GetKeys(Dictionary<string, long> template, Dictionary<string, string> pairs, int step)
        => Enumerable.Range(0, step)
                .Aggregate(template, (t, _) => t.NextStep(pairs));

        public static Dictionary<string, long> NextStep(this Dictionary<string, long> keys, Dictionary<string, string> pairs)
        {
            var newPairs = new Dictionary<string, long>();
            foreach (var (key, value) in keys)
            {
                var c = pairs[key];
                if (newPairs.ContainsKey(key[0] + c))
                    newPairs[key[0] + c] += value;
                else
                    newPairs.Add(key[0] + c, value);


                if (newPairs.ContainsKey(c + key[1]))
                    newPairs[c + key[1]] += value;
                else
                    newPairs.Add(c + key[1], value);
            }

            return newPairs;
        }

        private static Dictionary<string, long> ToDictionary(this string template)
            => Enumerable.Range(0, template.Length - 1)
            .Aggregate(Enumerable.Empty<(string, long)>(), (t, i) => t.Append(("" + template[i] + template[i + 1], 1)))
                                .GroupBy(x => x.Item1)
                                .ToDictionary(x => x.Key, x => x.Sum(y => y.Item2));

        public static (Dictionary<string, long> start, Dictionary<string, string> pairs) Format(this string[] datas)
            => (datas[0].ToDictionary(), datas.Skip(2).Select(x => x.Split(" -> ")).ToDictionary(x => x[0], x => x[1]));
    }
}