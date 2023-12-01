using Days._2023;
using Xunit;

namespace Tests._2023
{
    public class Day01
    {
        private static readonly string[] test =
               {
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"};

        private static readonly string[] test2 =
               {
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"};

        [Fact]
        public void FirstStarExample()
        {
            var result = Trebuchet.GetFirstLastDigitSum(test);
            Assert.Equal(142, result);

        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2023\\01.txt");
            var result = Trebuchet.GetFirstLastDigitSum(dataset);
            Assert.Equal(56108, result);
        }

        [Fact]
        public void SecondStarExample()
        {
            var result = Trebuchet.GetFirstLastDigitLiteralSum(test2);
            Assert.Equal(281, result);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2023\\01.txt");
            var result = Trebuchet.GetFirstLastDigitLiteralSum(dataset);
            Assert.Equal(55652, result);
        }
    }
}