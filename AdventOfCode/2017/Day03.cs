using System;

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

            }
            while (main < nb);

            Console.WriteLine($"{main} : x {coord.X} / y {coord.Y} - Steps : {Math.Abs(coord.Y) + Math.Abs(coord.X)}");

            return Math.Abs(coord.Y) + Math.Abs(coord.X);
        }
    }

    public class Coord
    {
        //0 => right, 1 => up, 2 => left, 3 => down
        public int Direction { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public void NextDir()
        {
            if (Direction == 3) Direction = 0;
            else Direction++;
        }

        public void Move()
        {
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
