using Days._2023;
using Xunit;

namespace Tests._2023
{
    public class Day07
    {
        private static readonly string[] test =
        {
            "32T3K 765",
            "T55J5 684",
            "KK677 28",
            "KTJJT 220",
            "QQQJA 483",
        };

        [Fact]
        public void FirstStarExample()
        {
            var result = CamelCards.GetTotalBids(test);
            Assert.Equal(6440, result);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2023\\07.txt");
            var result = CamelCards.GetTotalBids(dataset);
            Assert.Equal(250347426, result);
        }

        [Fact]
        public void SecondStarExample()
        {
            var result = CamelCards.GetTotalBidsJoker(test);
            Assert.Equal(5905, result);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2023\\07.txt");
            var result = CamelCards.GetTotalBidsJoker(dataset);
            Assert.Equal(251224870, result);
        }
    }
}