using Xunit;
using Days._2021;

namespace Tests._2021
{
    public class Day09
    {
        private static readonly string[] test =
        {
            "2199943210",
            "3987894921",
            "9856789892",
            "8767896789",
            "9899965678"
        };

        [Fact]
        public void FirstStarExample()
        {
            var x = SmokeBasin.GetRiskLevel(test);
            Assert.Equal(15, x);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2021\\09.txt");
            var x = SmokeBasin.GetRiskLevel(dataset);
            Assert.Equal(462, x);
        }

        [Fact]
        public void SecondStarExample()
        {
            var x = SmokeBasin.GetAllBasins(test);
            Assert.Equal(1134, x);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2021\\09.txt");
            var x = SmokeBasin.GetAllBasins(dataset);
            Assert.Equal(1397760, x);
        }
    }
}