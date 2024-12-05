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

        private static readonly string[] test3 =
        {
            "LR",
            "",
            "11A = (11B, XXX)",
            "11B = (XXX, 11Z)",
            "11Z = (11B, XXX)",
            "22A = (22B, XXX)",
            "22B = (22C, 22C)",
            "22C = (22Z, 22Z)",
            "22Z = (22B, 22B)",
            "XXX = (XXX, XXX)",
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
            Assert.Equal(21409, HauntedWasteland.GetStepsToZZZ(dataset));
        }

        [Fact]
        public void SecondStarExample()
        {
            Assert.Equal(6, HauntedWasteland.GetSimultaneousToZZZ(test3));
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2023\\08.txt");
            var result = HauntedWasteland.GetSimultaneousToZZZ(dataset);
            Assert.Equal(21409, result);
        }
    }
}