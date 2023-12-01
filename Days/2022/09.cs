namespace Days._2022
{
    public static class RopeBridge
    {
        //"R 4", "U 4", "L 3", "D 1",
        public static int GetCountPositionsTail(string[] input)
            => input.Aggregate(((0, 0), (0, 0), new HashSet<(int, int)>()), (coords, input) => NextMove(coords, input)).Item3.Count + 1;

        private static ((int x, int y) head, (int x, int y) tail, HashSet<(int x, int y)> tailP) NextMove(((int x, int y) head, (int x, int y) tail, HashSet<(int x, int y)> tailP) coords, string move)
        {
            var step = int.Parse(move.Split(" ")[1]);
            var direction = move[0] switch
            {
                'R' => (1, 0),
                'L' => (-1, 0),
                'U' => (0, 1),
                'D' => (0, -1),
                _ => throw new Exception("Incorrect direction.")
            };

            return Enumerable.Range(0, step).Aggregate(coords, (c, i) =>
            {
                var head = c.head.Add(direction);
                c.head = head;
                if (IsCloseEnough(head, c.tail)) return c;
                c.tail = c.tail.Add(GetCoordsDirection(head, c.tail));
                c.tailP.Add(c.tail);
                return c;
            });
        }

        private static (int x, int y) Add(this (int x, int y) a, (int x, int y) b) => (a.x + b.x, a.y + b.y);

        private static bool IsCloseEnough((int x, int y) head, (int x, int y) tail)
            => head.x - 1 <= tail.x && head.x + 1 >= tail.x &&
               head.y - 1 <= tail.y && head.y + 1 >= tail.y;

        private static (int x, int y) GetCoordsDirection((int x, int y) head, (int x, int y) tail)
            => (GetDirection(head.x, tail.x), GetDirection(head.y, tail.y));

        private static int GetDirection(int head, int tail)
            => (head - tail) switch
            {
                0 => 0,
                _ => (head - tail) > 0 ? 1 : -1
            };
    }
}