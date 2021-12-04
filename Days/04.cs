using System.Linq;
using System.Diagnostics;

namespace Days
{
    public static class GiantSquid
    {
        public static (IEnumerable<int> bingo, List<List<(int value, int line, int col)>> boards) FormatDatas(IEnumerable<string> datas)
        {
            var bingo = datas.First().Split(',').Select(x => int.Parse(x));
            var boards = new List<List<(int value, int line, int col)>>();
            var board = new List<(int value, int line, int col)>();
            int y = 0;
            foreach (var line in datas.Skip(2))
            {
                if (line == "")
                {
                    boards.Add(board);
                    board = new List<(int value, int line, int col)>();
                    y = 0;
                    continue;
                }
                var lineB = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                for (int x = 0; x < lineB.Length; x++)
                {
                    board.Add((lineB[x], y, x));
                }
                y++;
            }
            boards.Add(board);
            return (bingo, boards);
        }

        private static bool IsBoardBingo(List<(int value, int line, int col)> board, IEnumerable<int> bingo)
        {
            var bingoValues = board.Where(x => bingo.Contains(x.value));
            if (bingoValues.Count() < 5) return false;

            var col = bingoValues.GroupBy(x => x.col).Any(g => g.Count() == 5);
            var line = bingoValues.GroupBy(x => x.line).Any(g => g.Count() == 5);
            return col || line;
        }

        public static int GetSumUnmarked(IEnumerable<string> datas)
        {
            var (bingo, boards) = FormatDatas(datas);
            var winner = new List<(int value, int line, int col)>();
            var draw = new List<int>();
            foreach (int nb in bingo)
            {
                draw.Add(nb);
                if (draw.Count < 5)
                    continue;
                winner = boards.FirstOrDefault(x => IsBoardBingo(x, draw));

                if (winner is not null) break;
            }
            return winner.Where(x => !draw.Contains(x.value)).Sum(x => x.value) * draw.Last();
        }

        public static int GetLastWinner(IEnumerable<string> datas)
        {
            var (bingo, boards) = FormatDatas(datas);
            int total = boards.Count;
            var lastWinner = new List<List<(int value, int line, int col)>>();
            var lastDrawWinner = -1;
            var draw = new List<int>();
            foreach (int nb in bingo)
            {
                draw.Add(nb);
                if (draw.Count < 5) continue;
                var last = boards.Where(x => IsBoardBingo(x, draw)).ToList();
                boards.RemoveAll(x => IsBoardBingo(x, draw));
                if (last.Count != 0) { lastDrawWinner = nb; lastWinner = last; }
                if (boards.Count == 0) break;
            }
            var lastD = draw.Take(draw.IndexOf(lastDrawWinner) + 1);
            return lastWinner.First().Where(x => !lastD.Contains(x.value)).Sum(x => x.value) * lastDrawWinner;
        }
    }
}
