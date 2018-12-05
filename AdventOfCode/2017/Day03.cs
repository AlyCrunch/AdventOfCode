using System;
using System.Collections.Generic;

namespace AdventOfCode._2017
{
    public static class Day3
    {
        public static void GetSolution(int nb)
        {
            Console.WriteLine($"Answer is {Part1(nb)}");
        }

        static private int Part1(int nb)
        {
            var coord = new Coord();
            int main = 1;

            bool addOne = false;
            int moves = 0;
            int movesMax = 1;
            int savedValue = 0;            

            do
            {
                main++;
                moves++;
                coord.Move();
                if (moves == movesMax)
                {
                    coord.NextDir();
                    if (addOne)
                    {
                        movesMax++;
                    }
                    moves = 0;
                    addOne = !addOne;
                }
                if (savedValue == 0 && coord.LastValue > nb)
                    savedValue = coord.LastValue;
            }
            while (main < nb);

            Console.WriteLine($"{main} : x {coord.X} / y {coord.Y} - Steps : {Math.Abs(coord.Y) + Math.Abs(coord.X)} and part 2 : {savedValue}");

            return Math.Abs(coord.Y) + Math.Abs(coord.X);
        }
    }

    public class Coord
    {
        //0 => right, 1 => up, 2 => left, 3 => down
        public int Direction { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public Dictionary<(int X, int Y), int> ValuesMemory { get; set; } = new Dictionary<(int X, int Y), int>();

        public int LastValue { get; set; }

        public void NextDir()
        {
            if (Direction == 3) Direction = 0;
            else Direction++;
        }

        public void Move()
        {
            int val = 0;
            if (X == 0 && Y == 0) val = 1;
            else
            {
                if (ValuesMemory.ContainsKey((X, Y + 1))) val += ValuesMemory[(X, Y + 1)];
                if (ValuesMemory.ContainsKey((X, Y - 1))) val += ValuesMemory[(X, Y - 1)];

                if (ValuesMemory.ContainsKey((X + 1, Y))) val += ValuesMemory[(X + 1, Y)];
                if (ValuesMemory.ContainsKey((X + 1, Y + 1))) val += ValuesMemory[(X + 1, Y + 1)];
                if (ValuesMemory.ContainsKey((X + 1, Y - 1))) val += ValuesMemory[(X + 1, Y - 1)];

                if (ValuesMemory.ContainsKey((X - 1, Y))) val += ValuesMemory[(X - 1, Y)];
                if (ValuesMemory.ContainsKey((X - 1, Y + 1))) val += ValuesMemory[(X - 1, Y + 1)];
                if (ValuesMemory.ContainsKey((X - 1, Y - 1))) val += ValuesMemory[(X - 1, Y - 1)];
            }

            LastValue = val;
            ValuesMemory.Add((X, Y), LastValue);

            switch (Direction)
            {
                case 0: X++; break;
                case 1: Y++; break;
                case 2: X--; break;
                case 3: Y--; break;
            }
        }

    }
}
