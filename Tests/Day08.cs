using Xunit;
using Days;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    public class Day08
    {
        private static readonly string[] test =
        {
            "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
            "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
            "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
            "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
            "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
            "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
            "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
            "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
            "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
            "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
        };
        private static readonly string[] test2 =
            {"acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf"};

        [Fact]
        public void FirstStarExample()
        {
            var x = SevenSegmentSearch.GetNumberDigitsWithUniqueSegment(test);
            Assert.Equal(26, x);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Helpers.ReadFile("Inputs\\08.txt");
            var x = SevenSegmentSearch.GetNumberDigitsWithUniqueSegment(dataset);
            Assert.Equal(367, x);
        }

        [Fact]
        public void SecondStarExample()
        {
            var line = SevenSegmentSearch.GetSumOfDigit(test2);
            Assert.Equal(5353, line);
            var x = SevenSegmentSearch.GetSumOfDigit(test);
            Assert.Equal(61229, x);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Helpers.ReadFile("Inputs\\08.txt");
            var x = SevenSegmentSearch.GetSumOfDigit(dataset);
            Assert.Equal(974512, x);
        }
    }
}