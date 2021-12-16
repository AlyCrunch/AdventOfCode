using Days._2017;
using Xunit;

namespace Tests._2017
{
    public class Day10
    {
        private static readonly string test = "3,4,1,5";

        [Fact]
        public void FirstStarExample()
        {
            Assert.Equal(12, KnotHash.GetMultiplicationTwoFirst(4, test));
        }

        [Fact]
        public void FirstStarSolution()
        {
            //var dataset = Days.Helpers.ReadSingleLineFile("Inputs\\2017\\10.txt");
            //Assert.Equal(12, KnotHash.GetMultiplicationTwoFirst(255, dataset));
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