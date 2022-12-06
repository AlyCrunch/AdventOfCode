using Days._2022;
using Xunit;

namespace Tests._2022
{
    public class Day05
    {
        private static readonly string[] test =
        {
            "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3 ",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2"
        };

        [Fact]
        public void FirstStarExample()
        {
            var result = SupplyStacks.ExecuteProcedure(test);
            Assert.Equal("CMZ", result);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2022\\05.txt");
            var result = SupplyStacks.ExecuteProcedure(dataset);
            Assert.Equal("RTGWZTHLD", result);
        }

        [Fact]
        public void SecondStarExample()
        {
            var result = SupplyStacks.ExecuteProcedure(test, true);
            Assert.Equal("MCD", result);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2022\\05.txt");
            var result = SupplyStacks.ExecuteProcedure(dataset, true);
            Assert.Equal("STHGRZZFR", result);
        }
    }
}