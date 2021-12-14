using Days._2021;
using Xunit;

namespace Tests._2021
{
    public class Day14
    {
        private readonly string[] test = new string[]
        {
            "NNCB",
            "",
            "CH -> B",
            "HH -> N",
            "CB -> H",
            "NH -> C",
            "HB -> C",
            "HC -> B",
            "HN -> C",
            "NN -> C",
            "BH -> H",
            "NC -> B",
            "NB -> B",
            "BN -> B",
            "BB -> N",
            "BC -> B",
            "CC -> N",
            "CN -> C"
        };

        [Fact]
        public void FirstStarExample()
        {
            Assert.Equal(1588, ExtendedPolymerization.GetSubstractMostAndLeastCommon(test, 10));
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2021\\14.txt");
            Assert.Equal(3306, ExtendedPolymerization.GetSubstractMostAndLeastCommon(dataset, 10));
        }

        [Fact]
        public void SecondStarExample()
        {
            Assert.Equal(1588, ExtendedPolymerization.GetSubstractMostAndLeastCommon(test, 40));
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2021\\14.txt");
            Assert.Equal(3306, ExtendedPolymerization.GetSubstractMostAndLeastCommon(dataset, 40));
        }
    }
}