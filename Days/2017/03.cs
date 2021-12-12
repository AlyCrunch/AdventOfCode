using System;
using System.Collections.Generic;

namespace Days
{
    public static class SpiralMemory
    {
        static public int GetSteps(int input)
        {
            var map = CreateMap(input);
            var (x, y) = map.Last().Key;

            return Math.Abs(0 - x) + Math.Abs(0 - y);
        }

        static private Dictionary<(int x, int y), int> CreateMap(int input)
        {
            Dictionary<(int x, int y), int> map = new();
            map.Add((0, 0), 1);
            int direction = 3; //right = 0, top = 1, left = 2, bottom = 3

            for (int i = 2; i <= input; i++)
            {
                var turnLeft = TurnLeft(map.Last().Key, direction);
                var forward = Continue(map.Last().Key, direction);

                if (map.ContainsKey(turnLeft))
                {
                    map.Add(forward, i);
                }
                else
                {
                    map.Add(turnLeft, i);
                    direction = direction.TurnLeft();
                }
            }

            return map;
        }
        //right = 0, top = 1, left = 2, bottom = 3
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
