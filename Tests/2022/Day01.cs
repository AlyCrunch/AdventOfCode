using Days._2022;
using Xunit;

namespace Tests._2022
{
    public class Day01
    {
        private static readonly string[] test =
               {
            "1000",
            "2000",
            "3000",
            "",
            "4000",
            "",
            "5000",
            "6000",
            "",
            "7000",
            "8000",
            "9000",
            "",
            "10000"};

        [Fact]
        public void FirstStarExample()
        {
            var result = CalorieCounting.GetMaxCaloriesHeld(test);
            Assert.Equal(24000, result);

        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2022\\01.txt");
            var result = CalorieCounting.GetMaxCaloriesHeld(dataset);
            Assert.Equal(67658, result);
        }

        [Fact]
        public void SecondStarExample()
        {
            var result = CalorieCounting.GetTop3MaxHeld(test);
            Assert.Equal(45000, result);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2022\\01.txt");
            var result = CalorieCounting.GetTop3MaxHeld(dataset);
            Assert.Equal(200158, result);
        }
    }
}