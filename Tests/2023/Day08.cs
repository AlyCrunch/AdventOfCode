using Days._2023;
using Xunit;

namespace Tests._2023
{
    public class Day08
    {
        private static readonly string[] test1 =
        {
            "RL",
            "",
            "AAA = (BBB, CCC)",
            "BBB = (DDD, EEE)",
            "CCC = (ZZZ, GGG)",
            "DDD = (DDD, DDD)",
            "EEE = (EEE, EEE)",
            "GGG = (GGG, GGG)",
            "ZZZ = (ZZZ, ZZZ)"
        };
        private static readonly string[] test2 =
        {
            "LLR",
            "",
            "AAA = (BBB, BBB)",
            "BBB = (AAA, ZZZ)",
            "ZZZ = (ZZZ, ZZZ)",
        };

        [Fact]
        public void FirstStarExample()
        {
            Assert.Equal(2, HauntedWasteland.GetStepsToZZZ(test1));
            Assert.Equal(6, HauntedWasteland.GetStepsToZZZ(test2));
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2023\\08.txt");
            var result = HauntedWasteland.GetStepsToZZZ(dataset);
            Assert.Equal(21409, result);
        }

        [Fact]
        public void SecondStarExample()
        {
            Assert.Equal(2, HauntedWasteland.GetStepsToZZZ(test1));
            Assert.Equal(6, HauntedWasteland.GetStepsToZZZ(test2));
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2023\\08.txt");
            var result = HauntedWasteland.GetStepsToZZZ(dataset);
            Assert.Equal(21409, result);
        }
    }
}