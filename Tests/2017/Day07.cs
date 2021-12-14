using Days._2017;
using Xunit;

namespace Tests._2017
{
    public class Day07
    {
        private readonly static string[] test =
        {
            "pbga (66)",
            "xhth (57)",
            "ebii (61)",
            "havc (66)",
            "ktlj (57)",
            "fwft (72) -> ktlj, cntj, xhth",
            "qoyq (66)",
            "padx (45) -> pbga, havc, qoyq",
            "tknk (41) -> ugml, padx, fwft",
            "jptl (61)",
            "ugml (68) -> gyxo, ebii, jptl",
            "gyxo (61)",
            "cntj (57)"
        };
        [Fact]
        public void FirstStarExample()
        {
            Assert.Equal("tknk", RecursiveCircus.GetNameBottom(test));
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2017\\07.txt");
            Assert.Equal("hlhomy", RecursiveCircus.GetNameBottom(dataset));
        }

        [Fact]
        public void SecondStarExample()
        {
            Assert.Equal(60, RecursiveCircus.WeightToBeBalanced(test));
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2017\\07.txt");
            Assert.Equal(1505, RecursiveCircus.WeightToBeBalanced(dataset));
        }
    }
}