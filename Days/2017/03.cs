namespace Days._2017
{
    public static class SpiralMemory
    {
        static public int GetSteps(int input)
        {
            var map = CreateMap(input);
            var (x, y) = map.Last().Key;

            return Math.Abs(0 - x) + Math.Abs(0 - y);
        }
        static public int GetFirstLargerValue(int input)
            => CreateMapAdjacent(input).Last().Value;

        static private Dictionary<(int x, int y), int> CreateMap(int input)
        {
            Dictionary<(int x, int y), int> map = new();
            map.Add((0, 0), 1);
            (int x, int y) lastkey = (0, 0);
            int direction = 3; //right = 0, top = 1, left = 2, bottom = 3

            for (int i = 2; i <= input; i++)
            {
                var turnLeft = TurnLeft(lastkey, direction);
                var forward = Continue(lastkey, direction);

                if (map.ContainsKey(turnLeft))
                {
                    lastkey = forward;
                    map.Add(forward, i);
                }
                else
                {
                    lastkey = turnLeft;
                    map.Add(turnLeft, i);
                    direction = direction.TurnLeft();
                }
            }

            return map;
        }
        static private Dictionary<(int x, int y), int> CreateMapAdjacent(int input)
        {
            Dictionary<(int x, int y), int> map = new();
            map.Add((0, 0), 1);
            (int x, int y) lastkey = (0, 0);
            int direction = 3; //right = 0, top = 1, left = 2, bottom = 3
            int i = 1;

            while (i <= input)
            {
                var turnLeft = TurnLeft(lastkey, direction);
                var forward = Continue(lastkey, direction);

                if (map.ContainsKey(turnLeft))
                {
                    lastkey = forward;
                    i = GetAdjacent(lastkey).Select(x => map.ContainsKey(x) ? map[x] : 0).Sum();
                    map.Add(forward, i);
                }
                else
                {
                    lastkey = turnLeft;
                    i = GetAdjacent(lastkey).Select(x => map.ContainsKey(x) ? map[x] : 0).Sum();
                    map.Add(turnLeft, i);
                    direction = direction.TurnLeft();
                }
            }

            return map;
        }

        static private (int x, int y) Continue((int x, int y) coords, int direction)
            => direction switch
            {
                0 => (coords.x, coords.y + 1),
                1 => (coords.x + 1, coords.y),
                2 => (coords.x, coords.y - 1),
                3 => (coords.x - 1, coords.y),
                _ => throw new Exception("Invalid direction.")
            };
        static private (int x, int y) TurnLeft((int x, int y) coords, int direction)
            => direction switch
            {
                0 => (coords.x + 1, coords.y),
                1 => (coords.x, coords.y - 1),
                2 => (coords.x - 1, coords.y),
                3 => (coords.x, coords.y + 1),
                _ => throw new Exception("Invalid direction.")
            };
        static private int TurnLeft(this int direction)
            => direction switch
            {
                0 => 1,
                1 => 2,
                2 => 3,
                3 => 0,
                _ => throw new Exception()
            };
        static private (int x, int y)[] GetAdjacent((int x, int y) coord)
        => new (int x, int y)[]
            {
                (coord.x - 1, coord.y - 1),
                (coord.x - 1, coord.y),
                (coord.x - 1, coord.y + 1),
                (coord.x, coord.y - 1),
                (coord.x, coord.y + 1),
                (coord.x + 1, coord.y - 1),
                (coord.x + 1, coord.y),
                (coord.x + 1, coord.y + 1)
            };
    }
}