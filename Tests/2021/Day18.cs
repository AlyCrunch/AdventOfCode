using Days._2021;
using System.Linq;
using Xunit;

namespace Tests._2021
{
    public class Day18
    {
        [Fact]
        public void FirstStarExample()
        {
            var test = new SnailFish.Pair("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]");
            test.TryExplode();

            Assert.Equal("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", test.ToString());
        }

        [Fact]
        public void FirstStarSolution()
        {
            //var dataset = Days.Helpers.ReadFile("Inputs\\year\\day.txt");
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