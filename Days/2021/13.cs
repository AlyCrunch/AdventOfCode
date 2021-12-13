using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Days._2021
{
    public static class TransparentOrigami
    {
        public static int CountPoints(string[] datas, int maxFold)
            => FoldAll(datas, maxFold).Count;

        public static HashSet<(int x, int y)> FoldAll(string[] datas, int maxFold = -1)
        {
            var (paper, fold) = FormatDatas(datas);
            var nbFolds = (maxFold > fold.Count() || maxFold == -1) ? fold.Count() : maxFold;

            return fold.Take(nbFolds).Aggregate(paper, (p, f) => p.Fold(f));
        }

        public static string[] GetCode(string[] data)
        {
            var points = FoldAll(data);
            var maxY = points.Max(x => x.y);
            var maxX = points.Max(x => x.x);

            return Enumerable.Range(0, maxY + 1).Select(y => new string(Enumerable.Range(0, maxX + 1)
            .Select(x => (points.Contains((x, y))) ? '#' : '.').ToArray())).ToArray();
        }

        public static HashSet<(int x, int y)> Fold(this HashSet<(int x, int y)> paper, (char dir, int value) fold)
        {
            var lambdaWhere = (fold.dir == 'x') 
                ? new Func<(int x, int y), bool>(x => x.x > fold.value) 
                : new Func<(int x, int y), bool>(x => x.y > fold.value);
            var lambdaSelect = (fold.dir == 'x') 
                ? new Func<(int x, int y), (int x, int y)>(x => (Math.Abs(x.x - fold.value * 2), x.y))
                : new Func<(int x, int y), (int x, int y)>(x => (x.x, Math.Abs(x.y - fold.value * 2)));

            var folding = paper.ToList().Where(lambdaWhere).Select(lambdaSelect);
            paper.RemoveWhere(new Predicate<(int x, int y)>(lambdaWhere));
            paper.UnionWith(folding);

            return paper;
        }

        public static (HashSet<(int x, int y)> points, IEnumerable<(char direction, int value)> folds) FormatDatas(string[] datas)
            => (datas.Take(Array.IndexOf(datas, "")).Select(x => x.Split(',')).Select(x => (int.Parse(x[0]), int.Parse(x[1]))).ToHashSet(),
                datas.Skip(Array.IndexOf(datas, "") + 1).Select(x => x[11..].Split('=')).Select(x => (x[0].First(), int.Parse(x[1]))));
    }
}