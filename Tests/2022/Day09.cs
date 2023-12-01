using Days._2022;
using Xunit;

namespace Tests._2022
{
    public class Day09
    {
        private static readonly string[] test =
        {
            "R 4",
            "U 4",
            "L 3",
            "D 1",
            "R 4",
            "D 1",
            "L 5",
            "R 2"
        };
        [Fact]
        public void FirstStarExample()
        {
            int result = RopeBridge.GetCountPositionsTail(test);
            Assert.Equal(13, result);
        }

        [Fact]
        public void FirstStarSolution()
        {
            //var dataset = Days.Helpers.ReadFile("Inputs\\2022\\09.txt");
            //int result = RopeBridge.GetCountPositionsTail(dataset);
            //Assert.Equal(13, result);
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