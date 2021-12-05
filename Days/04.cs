using System.Linq;
using System.Diagnostics;

namespace Days
{
    public static class GiantSquid
    {
        public static (IEnumerable<int> bingo, List<List<(int value, int line, int col)>> boards) FormatDatas(IEnumerable<string> datas)
        {
            var bingo = datas.First().Split(',').Select(x => int.Parse(x));
            var board = new List<(int value, int line, int col)>();
            var boards = new List<List<(int value, int line, int col)>>();
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

        public static int GetFirstWinner(IEnumerable<string> datas)
        {
            var (bingo, boards) = FormatDatas(datas);
            var winner = new List<(int value, int line, int col)>();
            var draw = bingo.Take(5).ToList();
            foreach (int nb in bingo.Skip(5))
            {
                draw.Add(nb);
                winner = boards.FirstOrDefault(x => IsBoardBingo(x, draw));

                if (winner is not null) break;
            }
            return winner.Where(x => !draw.Contains(x.value)).Sum(x => x.value) * draw.Last();
        }

        public static int GetLastWinner(IEnumerable<string> datas)
        {
            var (bingo, boards) = FormatDatas(datas);
            var lastWinnerBoards = new List<List<(int value, int line, int col)>>();
            var lastWinnerDraw = new List<int>();
            var draw = bingo.Take(5).ToList();
            foreach (int nb in bingo.Skip(5))
            {
                draw.Add(nb);
                var grouped = boards.GroupBy(x => IsBoardBingo(x, draw));
                if (grouped.Any(x => x.Key))
                {
                    lastWinnerDraw = draw.ToList();
                    lastWinnerBoards = grouped.Where(x => x.Key).First().ToList();
                    if (grouped.Any(x => !x.Key))
                        boards = grouped.Where(x => !x.Key).First().ToList();
                    else
                        break;
                }
            }
            return lastWinnerBoards.First().Where(x => !lastWinnerDraw.Contains(x.value)).Sum(x => x.value) * lastWinnerDraw.Last();
        }
    }
}