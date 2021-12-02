using System.Linq;

namespace Days
{
    public static class Dive
    {
        public static (string, int) StringToCommand(string str)
            => str.Split(' ').Aggregate(("", 0), (cmd, item)
                => cmd = string.IsNullOrEmpty(cmd.Item1) ? (item, cmd.Item2) : (cmd.Item1, int.Parse(item)));

        public static IEnumerable<(string name, int nb)> FormatData(IEnumerable<string> cmds)
            => cmds.Select(x => StringToCommand(x));

        public static (int depth, int hPosition) GetFinalPosition(IEnumerable<string> datas)
            => FormatData(datas)
                .Select(x => x.name switch
                {
                    "forward" => (0, x.nb),
                    "down" => (x.nb, 0),
                    "up" => (-1 * x.nb, 0),
                    _ => (0, 0),
                })
                .Aggregate((depth: 0, hPosition: 0), (sum, item) => (sum.depth + item.Item1, sum.hPosition + item.Item2));

        public static (int depth, int hPosition, int aim) GetFinalPositionWithAim(IEnumerable<string> datas)
            => FormatData(datas)
                .Select(x => x.name switch
                {
                    "forward" => (0, x.nb),
                    "down" => (x.nb, 0),
                    "up" => (-1 * x.nb, 0),
                    _ => (0, 0),
                })
                .Aggregate((depth: 0, hPosition: 0, aim: 0), (sum, item) =>
                       (
                       (item.Item2 != 0 && sum.aim != 0) ? sum.depth + sum.aim * item.Item2 : sum.depth,
                       (item.Item2 != 0) ? item.Item2 + sum.hPosition : sum.hPosition,
                       sum.aim + item.Item1
                       ));

    }
}
