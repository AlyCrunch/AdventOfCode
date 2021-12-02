using Xunit;
using Days;

namespace Tests
{
    public class Day02
    {

        private static readonly string[] test = 
            {
            "forward 5",
            "down 5",
            "forward 8",
            "up 3",
            "down 8",
            "forward 2"};

        [Fact]
        public void FirstStarExample()
        {
            var (depth, hPosition) = Dive.GetFinalPosition(test);
            Assert.Equal(150, depth * hPosition);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Helpers.ReadFile("Inputs\\02.txt");
            var (depth, hPosition) = Dive.GetFinalPosition(dataset);
            Assert.Equal(1507611, depth * hPosition);
        }

        [Fact]
        public void SecondStarExample()
        {
            var (depth, hPosition, _) = Dive.GetFinalPositionWithAim(test);
            Assert.Equal(900, depth * hPosition);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Helpers.ReadFile("Inputs\\02.txt");
            var (depth, hPosition, _) = Dive.GetFinalPositionWithAim(dataset);
            Assert.Equal(1880593125, depth * hPosition);
        }
    }
}