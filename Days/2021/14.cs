using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days._2021
{
    public static class ExtendedPolymerization
    {

        public static long GetSubstractMostAndLeastCommon(string[] datas, int step)
        {
            var (template, pairs) = datas.Format();
            var templateFormatted = template.ToDictionary(pairs);

            var lastState = Enumerable.Range(0, step)
                .Aggregate(templateFormatted, (template, _) => template.NexStep(pairs));
            var test = lastState.Aggregate(new List<(string, int)>(), (dic, element)
                 => dic.Append((pairs[element.Key], element.Value)).ToList())
                                .GroupBy(x => x.Item1)
                                .ToDictionary(x => x.Key, x => x.Sum(z => z.Item2));
            //dic.Append(new KeyValuePair<string, int>(pairs[element.Key], element.Value)).ToList());


            return test.Max(x => x.Value) - test.Min(x => x.Value);
        }
        public static Dictionary<string, int> NexStep(this Dictionary<string, int> keys, Dictionary<string, string> pairs)
        {
            var newPairs = new Dictionary<string, int>();
            foreach (var (key, value) in keys)
            {
                var c = pairs[key];
                newPairs.Add(key[0] + c, value);
                newPairs.Add(c + key[1], value);
            }

            return newPairs;
        }

        private static Dictionary<string, int> ToDictionary(this string template, Dictionary<string, string> pairs)
            => Enumerable.Range(0, template.Length - 1)
            .Aggregate(Enumerable.Empty<(string, int)>(), (t, i) => t.Append(("" + template[i] + template[i + 1], 1)))
            .ToDictionary(x => x.Item1, x => x.Item2);

        private static (string start, Dictionary<string, string> pairs) Format(this string[] datas)
            => (datas[0], datas.Skip(2).Select(x => x.Split(" -> ")).ToDictionary(x => x[0], x => x[1]));
    }
}