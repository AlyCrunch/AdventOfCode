using Days._2017;
using Xunit;

namespace Tests._2017
{
    public class Day08
    {
        private readonly static string[] test =
        {
            "b inc 5 if a > 1",
            "a inc 1 if b < 5",
            "c dec -10 if a >= 1",
            "c inc -20 if c == 10"
        };

        [Fact]
        public void FirstStarExample()
        {
            Assert.Equal(1, YouLikeRegisters.GetLargest(test));
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2017\\08.txt");
            Assert.Equal(4888, YouLikeRegisters.GetLargest(dataset));
        }

        [Fact]
        public void SecondStarExample()
        {
            Assert.Equal(10, YouLikeRegisters.GetHighestValue(test));
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2017\\08.txt");
            Assert.Equal(7774, YouLikeRegisters.GetHighestValue(dataset));
        }
    }
}