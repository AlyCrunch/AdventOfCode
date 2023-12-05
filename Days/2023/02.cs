namespace Days._2023
{
    public static class CubeConundrum
    {


        //            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
        public static int GetSumPossible(IEnumerable<string> input, int blue, int red, int green)
        {
            string[] delimiters = { "; ", ", " };
            var sum = 0;
            for (int i = 1; i <= input.Count(); i++)
            {
                var impossible = input.ElementAt(i - 1).Split(": ")[1].Split(delimiters, StringSplitOptions.None)
                    .Any(y =>
                    {
                        var param = y.Split(" ");
                        return param[1] switch
                        {
                            "blue" => int.Parse(param[0]) > blue,
                            "red" => int.Parse(param[0]) > red,
                            "green" => int.Parse(param[0]) > green,
                            _ => true
                        };
                    });
                if (!impossible) sum += i;
            }
            return sum;
        }

        public static int GetMinimumSetMultiplied(IEnumerable<string> input)
            => input.GetGame().Sum(x => x.Max(y => y.blue) * x.Max(y => y.red) * x.Max(y => y.green));


        private static IEnumerable<IEnumerable<(int blue, int red, int green)>> GetGame(this IEnumerable<string> games)
        {
            foreach (var game in games)
            {
                yield return game.Split(": ")[1].Split("; ").Select(x => x.GetDraw());
            }
        }

        private static (int blue, int red, int green) GetDraw(this string draw)
        {
            int r, g, b;
            r = g = b = 0;

            foreach (var ball in draw.Split(", "))
            {
                var param = ball.Split(" ");
                if (param[1] == "blue") b = int.Parse(param[0]);
                if (param[1] == "red") r = int.Parse(param[0]);
                if (param[1] == "green") g = int.Parse(param[0]);
            }
            return (b, r, g);
        }

    }
}
