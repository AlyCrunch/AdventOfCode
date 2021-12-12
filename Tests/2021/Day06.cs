using Xunit;
using Days;

namespace Tests._2021
{
    public class Day06
    {
        private static readonly string test = "3,4,3,1,2";

        [Fact]
        public void FirstStarExample()
        {
            var x = Lanternfish.GetLanterfish(test);
            Assert.Equal(5934, x);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Helpers.ReadSingleLineFile("Inputs\\2021\\06.txt");
            var x = Lanternfish.GetLanterfish(dataset);
            Assert.Equal(350917, x);
        }

        [Fact]
        public void SecondStarExample()
        {
            var x = Lanternfish.GetLanterfish(test, 256);
            Assert.Equal(26984457539, x);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Helpers.ReadSingleLineFile("Inputs\\2021\\06.txt");
            var x = Lanternfish.GetLanterfish(dataset, 256);
            Assert.Equal(1592918715629, x);
        }
    }
}
