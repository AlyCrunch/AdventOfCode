using Days._2022;
using System.Linq;
using Xunit;

namespace Tests._2022
{
    public class Day03
    {
        public readonly string[] test = {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"};

        [Fact]
        public void FirstStarExample()
        {
            var result = RucksackReorganization.GetSumPriorities(test);
            Assert.Equal(157, result);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2022\\03.txt");

            var result = RucksackReorganization.GetSumPriorities(dataset);
            Assert.Equal(8153, result);
        }

        [Fact]
        public void SecondStarExample()
        {
            var result = RucksackReorganization.GetGroupPriorities(test);

            Assert.Equal(70, result);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2022\\03.txt");
            var result = RucksackReorganization.GetGroupPriorities(dataset);

            Assert.Equal(2342, result);
        }
    }
}