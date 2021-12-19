using Days._2021;
using Xunit;

namespace Tests._2021
{
    public class Day17
    {
        private static readonly string test = "target area: x=20..30, y=-10..-5";
        private static readonly string dataset = "target area: x=277..318, y=-92..-53";

        [Fact]
        public void FirstStarExample()
        {
            Assert.Equal(45, TrickShot.GetTheHighestY(test));
        }

        [Fact]
        public void FirstStarSolution()
        {
            Assert.Equal(4186, TrickShot.GetTheHighestY(dataset));
        }

        [Fact]
        public void SecondStarExample()
        {
            Assert.Equal(112, TrickShot.GetTheHits(test));
        }

        [Fact]
        public void SecondStarSolution()
        {
            Assert.Equal(2709, TrickShot.GetTheHits(dataset));
        }
    }
}