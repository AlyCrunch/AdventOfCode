using Days._2017;
using Xunit;

namespace Tests._2017
{
    public class Day06
    {
        private readonly string test = "0 2 7 0";

        [Fact]
        public void FirstStarExample()
        {
            Assert.Equal(5, MemoryReallocation.GetCyclesBeforeConfiguration(test));
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadSingleLineFile("Inputs\\2017\\06.txt");
            Assert.Equal(7864, MemoryReallocation.GetCyclesBeforeConfiguration(dataset));
        }

        [Fact]
        public void SecondStarExample()
        {
            Assert.Equal(4, MemoryReallocation.GetCyclesInfiniteLoop(test));
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadSingleLineFile("Inputs\\2017\\06.txt");
            Assert.Equal(1695, MemoryReallocation.GetCyclesInfiniteLoop(dataset));
        }
    }
}