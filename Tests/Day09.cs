using Xunit;
using Days;

namespace Tests
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
        public void Debug()
        {
        }

        [Fact]
        public void FirstStarExample()
        {
            var x = SmokeBasin.GetRiskLevel(test);
            Assert.Equal(15, x);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Helpers.ReadFile("Inputs\\09.txt");
            var x = SmokeBasin.GetRiskLevel(dataset);
            Assert.Equal(462, x);
        }

        [Fact]
        public void SecondStarExample()
        {
        }

        [Fact]
        public void SecondStarSolution()
        {
        }
    }
}