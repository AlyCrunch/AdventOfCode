namespace Days._2022
{
    public static class RockPaperScissors
    {
        /*
         * A Rock : 1
         * B Paper : 2
         * C Scissors : 3
         * X Rock
         * Y Paper
         * Z Scissors
         * win : 6
         * tie : 3
         * lost : 0
         */
        private static int ScoreModulo(Shape a, Shape b)
        {
            if (a == b) return 3 + ((int)b);
            if (b == (Shape)GetIndex(a, 1)) return 6 + ((int)b);
            if (b == (Shape)GetIndex(a, 2)) return 0 + ((int)b);

            return -1;
        }

        private static int GetIndex(Shape s, int i)
        {
            var val = ((int)s + i) % 3;
            return (val == 0) ? 3 : val;
        }

        private static int Score(Shape a, Shape b)
            => b switch
            {
                Shape.Rock => a switch
                {
                    Shape.Rock => 3 + (int)b,
                    Shape.Paper => 0 + (int)b,
                    Shape.Scissors => 6 + (int)b,
                    _ => throw new Exception()
                },
                Shape.Paper => a switch
                {
                    Shape.Rock => 6 + (int)b,
                    Shape.Paper => 3 + (int)b,
                    Shape.Scissors => 0 + (int)b,
                    _ => throw new Exception()
                },
                Shape.Scissors => a switch
                {
                    Shape.Rock => 0 + (int)b,
                    Shape.Paper => 6 + (int)b,
                    Shape.Scissors => 3 + (int)b,
                    _ => throw new Exception()
                },
                _ => throw new Exception()
            };

        // X: lose, Y: tie, Z: win
        private static int Score(Shape a, char b)
            => b switch
            {
                'X' => Score(a, (Shape)GetIndex(a, 2)),
                'Y' => Score(a, a),
                'Z' => Score(a, (Shape)GetIndex(a, 1)),
                _ => throw new Exception()
            };

        private static Shape ToShape(this char x)
            => x switch
            {
                'A' => Shape.Rock,
                'B' => Shape.Paper,
                'C' => Shape.Scissors,
                'X' => Shape.Rock,
                'Y' => Shape.Paper,
                'Z' => Shape.Scissors,
                _ => throw new Exception()
            };

        public static int GetTotalScore(IEnumerable<string> guide)
            => guide.Select(x => Score(x[0].ToShape(), x[2].ToShape())).Sum();

        public static int GetTotalScoreFixed(IEnumerable<string> guide)
            => guide.Select(x => Score(x[0].ToShape(), x[2])).Sum();
    }

    public enum Shape : int
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }
}