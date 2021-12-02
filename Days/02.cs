using System.Linq;

namespace Days
{
    public static class Dive
    {
        public static (string name, int nb) FormatData(string cmd)
        { 
            var s = x.Split(' ');
            return (s[0], int.Parse(s[1])); 
        }

        public static (int depth, int hPosition) GetFinalPosition(IEnumerable<string> datas)
            => datas.Select(FormatData)
                .Aggregate((depth: 0, hPosition: 0), (sum, item) => item.name switch
                {
                    "forward" => (sum.depth, sum.hPosition + item.nb),
                    "up" => (sum.depth - item.nb, sum.hPosition),
                    "down" => (sum.depth + item.nb, sum.hPosition)
                });

        public static (int depth, int hPosition, int aim) GetFinalPositionWithAim(IEnumerable<string> datas)
            => datas.Select(FormatData)
                .Aggregate((depth: 0, hPosition: 0, aim: 0), (sum, item) => item.name switch
                {
                    "forward" => (sum.depth + sum.aim * item.nb, sum.hPosition + item.nb, sum.aim),
                    "up" => (sum.depth, sum.hPosition, sum.aim - item.nb),
                    "down" => (sum.depth, sum.hPosition, sum.aim + item.nb)
                });
    }
}
