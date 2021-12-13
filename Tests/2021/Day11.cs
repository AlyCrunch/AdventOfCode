using Xunit;
using Days._2021;

namespace Tests._2021
{
    public class Day11
    {
        private static readonly string[] test =
        {
            "5483143223",
            "2745854711",
            "5264556173",
            "6141336146",
            "6357385478",
            "4167524645",
            "2176841721",
            "6882881134",
            "4846848554",
            "5283751526"
        };

        [Fact]
        public void FirstStarExample()
        {
            var y = DumboOctopus.GetCountOfFlashes(test);
            Assert.Equal(1656, y);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2021\\11.txt");
            var y = DumboOctopus.GetCountOfFlashes(dataset);
            Assert.Equal(1702, y);
        }

        [Fact]
        public void SecondStarExample()
        {
            int y = DumboOctopus.GetStepAllFlash(test);
            Assert.Equal(195, y);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2021\\11.txt");
            var y = DumboOctopus.GetStepAllFlash(dataset);
            Assert.Equal(251, y);
        }
    }
}