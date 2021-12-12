using Xunit;
using Days;

namespace Tests._2021
{
    public class Day10
    {
        private static readonly string[] test =
        {
            "[({(<(())[]>[[{[]{<()<>>",
            "[(()[<>])]({[<{<<[]>>(",
            "{([(<{}[<>[]}>{[]{[(<()>",
            "(((({<>}<{<{<>}{[]{[]{}",
            "[[<[([]))<([[{}[[()]]]",
            "[{[{({}]{}}([{[{{{}}([]",
            "{<[[]]>}<{[{[{[]{()[[[]",
            "[<(<(<(<{}))><([]([]()",
            "<{([([[(<>()){}]>(<<{{",
            "<{([{{}}[<[[[<>{}]]]>[]]"
        };

        [Fact]
        public void FirstStarExample()
        {
            var x = SyntaxScoring.GetScore(test);
            Assert.Equal(26397, x);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Helpers.ReadFile("Inputs\\2021\\10.txt");
            var x = SyntaxScoring.GetScore(dataset);
            Assert.Equal(392421, x);
        }

        [Fact]
        public void SecondStarExample()
        {
            var x = SyntaxScoring.GetMiddleScore(test);
            Assert.Equal(288957, x);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Helpers.ReadFile("Inputs\\2021\\10.txt");
            var x = SyntaxScoring.GetMiddleScore(dataset);
            Assert.Equal(2769449099, x);
        }
    }
}