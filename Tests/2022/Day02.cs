using Days._2022;
using System;
using System.Linq;
using Xunit;

namespace Tests._2022
{
    public class Day02
    {
       private static readonly string[] test =
       {
            "A Y",
            "B X",
            "C Z"
        };

        [Fact]
        public void FirstStarExample()
        {
            var result = RockPaperScissors.GetTotalScore(test);
            Assert.Equal(15, result);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2022\\02.txt");
            var result = RockPaperScissors.GetTotalScore(dataset);
            Assert.Equal(15523, result);
        }

        [Fact]
        public void SecondStarExample()
        {
            var result = RockPaperScissors.GetTotalScoreFixed(test);
            Assert.Equal(12, result);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2022\\02.txt");
            var result = RockPaperScissors.GetTotalScoreFixed(dataset);
            Assert.Equal(15702, result);
        }
    }
}