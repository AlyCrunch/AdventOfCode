using Days._2022;
using Xunit;

namespace Tests._2022
{
    public class Day08
    {
        private static readonly string[] test = {
            "30373",
            "25512",
            "65332",
            "33549",
            "35390"};

        [Fact]
        public void FirstStarExample()
        {
            int result = Treetop.CountTreesVisible(test);
            Assert.Equal(21, result);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2022\\08.txt");
            int result = Treetop.CountTreesVisible(dataset);
            Assert.Equal(1807, result);
        }

        [Fact]
        public void SecondStarExample()
        {
            int result = Treetop.GetHighestScenicScore(test);
            Assert.Equal(8, result);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2022\\08.txt");
            int result = Treetop.GetHighestScenicScore(dataset);
            Assert.Equal(480000, result);
        }
    }
}