using System;
using System.Collections.Generic;
using System.Linq;

namespace Days._2021
{
    public static class PassagePathing
    {
        public static int CountAllPaths(string[] datas)
        {
            return GetPaths(GetPossibilities(datas),
                new List<string>() { "start" }, "start",
                new List<List<string>>()).Count();
        }

        public static int CountAllPathsWithBonus(string[] datas)
        => GetPathsWithBonus(GetPossibilities(datas),
                new List<string>() { "start" }, "start",
                new List<List<string>>()).Count();
        public static Dictionary<string, IEnumerable<string>> GetPossibilities(string[] datas)
        {
            var links = datas.Select(x => x.Split('-')).Select(x => (x[0], x[1])).ToList();
            var reversedLinks = links.Where(x => x.Item1 != "start" && x.Item2 != "end")
                .Select(x => (x.Item2, x.Item1));

            links.AddRange(reversedLinks.ToList());

            return links.GroupBy(x => x.Item1).ToDictionary(x => x.Key, x => x.Select(s => s.Item2));
        }

        public static IEnumerable<IEnumerable<string>> GetPaths
            (Dictionary<string, IEnumerable<string>> links,
            IEnumerable<string> path, string curr, IEnumerable<IEnumerable<string>> paths)
        {
            if (curr == "end") return paths.Append(path);

            foreach (string p in links[curr])
            {
                if (p.All(char.IsLower) && path.Contains(p)) continue;
                paths = GetPaths(links, path.Append(p), p, paths);
            }

            return paths;
        }
        public static IEnumerable<IEnumerable<string>> GetPathsWithBonus
            (Dictionary<string, IEnumerable<string>> links,
            IEnumerable<string> path, string curr, IEnumerable<IEnumerable<string>> paths, bool extra = true)
        {
            if (curr == "end") return paths.Append(path);

            foreach (string p in links[curr])
            {
                if (p == "start") continue;

                var pIsExtra = extra;
                if (p.All(char.IsLower))
                {
                    var alreadyVisited = (pIsExtra) ? path.Count(x => x == p) > 1 : path.Contains(p);

                    if (pIsExtra && path.Contains(p)) pIsExtra = false;

                    if (alreadyVisited) continue;
                }
                paths = GetPathsWithBonus(links, path.Append(p), p, paths, pIsExtra);
            }
            return paths;
        }
    }
}