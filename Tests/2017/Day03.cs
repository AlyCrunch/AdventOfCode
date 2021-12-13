using Days;
using Xunit;

namespace Tests._2017
{
    public class Day03
    {
        private readonly int input = 312051;

        [Fact]
        public void FirstStarExample()
        {
            Assert.Equal(3, SpiralMemory.GetSteps(12));
            Assert.Equal(0, SpiralMemory.GetSteps(1));
            Assert.Equal(2, SpiralMemory.GetSteps(23));
            Assert.Equal(31, SpiralMemory.GetSteps(1024));
        }

        [Fact]
        public void FirstStarSolution()
        {
            var x = SpiralMemory.GetSteps(input);
            Assert.Equal(430, x);
        }

        [Fact]
        public void SecondStarExample()
        {
            Assert.Equal(54, SpiralMemory.GetFirstLargerValue(26));
            Assert.Equal(806, SpiralMemory.GetFirstLargerValue(747));
        }

        [Fact]
        public void SecondStarSolution()
        {
            var x = SpiralMemory.GetFirstLargerValue(input);
            Assert.Equal(312453, x);
        }
    }
}