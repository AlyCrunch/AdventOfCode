using Days._2023;
using Xunit;

namespace Tests._2023
{
    public class Day02
    {
        private static readonly string[] test =
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
        };

        [Fact]
        public void FirstStarExample()
        {
            var result = CubeConundrum.GetSumPossible(test, 14, 12, 13);
            Assert.Equal(8, result);

        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2023\\02.txt");
            var result = CubeConundrum.GetSumPossible(dataset, 14, 12, 13);
            Assert.Equal(2716, result);
        }

        [Fact]
        public void SecondStarExample()
        {
            var result = CubeConundrum.GetMinimumSetMultiplied(test);
            Assert.Equal(2286, result);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2023\\02.txt");
            var result = CubeConundrum.GetMinimumSetMultiplied(dataset);
            Assert.Equal(72227, result);
        }
    }
}