using Days._2017;
using Xunit;

namespace Tests._2017
{
    public class Day05
    {
        private readonly string[] test = new string[]
        {
            "0",
            "3",
            "0",
            "1",
            "-3"
        };

        [Fact]
        public void FirstStarExample()
        {
            Assert.Equal(5, MazeTwistyTrampolines.GetSteps(test));
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2017\\05.txt");
            Assert.Equal(339351, MazeTwistyTrampolines.GetSteps(dataset));
        }

        [Fact]
        public void SecondStarExample()
        {
            Assert.Equal(10, MazeTwistyTrampolines.GetStepsOffset(test));
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2017\\05.txt");
            Assert.Equal(24315397, MazeTwistyTrampolines.GetStepsOffset(dataset));
        }
    }
}