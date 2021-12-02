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
                .Aggregate((depth: 0, hPosition: 0), (sum, item) =>
                ((item.name != "forward") ? sum.depth + ((item.name != "up") ? item.nb : item.nb * -1) : sum.depth,
                (item.name == "forward") ? sum.hPosition + item.nb : sum.hPosition));

        public static (int depth, int hPosition, int aim) GetFinalPositionWithAim(IEnumerable<string> datas)
            => FormatData(datas)
                .Aggregate((depth: 0, hPosition: 0, aim: 0), (sum, item) =>
                       (
                       (item.name == "forward") ? sum.depth + sum.aim * item.nb : sum.depth,
                       (item.name == "forward") ? item.nb + sum.hPosition : sum.hPosition,
                       (item.name != "forward") ? sum.aim + ((item.name != "up") ? item.nb : item.nb * -1) : sum.aim
                       ));

    }
}