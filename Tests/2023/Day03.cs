using Days._2023;
using Xunit;

namespace Tests._2023
{
    public class Day03
    {
        private static readonly string[] test =
        {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.."
        };

        [Fact]
        public void FirstStarExample()
        {
            var result = GearRatios.SumPartNumbers(test);
            Assert.Equal(4361, result);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2023\\03.txt");
            var result = GearRatios.SumPartNumbers(dataset);
            Assert.Equal(520019, result);
        }

        [Fact]
        public void SecondStarExample()
        {
            var result = GearRatios.GetGearRatioSum(test);
            Assert.Equal(467835, result);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2023\\03.txt");
            var result = GearRatios.GetGearRatioSum(dataset);
            Assert.Equal(75519888, result);
        }
    }
}