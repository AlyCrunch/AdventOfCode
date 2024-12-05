using Days._2024;
using Xunit;

namespace Tests._2024
{
    public class Day01
    {
        [Fact]
        public void FirstStarSolution()
        {
            var x = HistorianHysteria.Part1("Inputs\\2024\\01.txt");
            Assert.Equal("1388114", x);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var x = HistorianHysteria.Part2("Inputs\\2024\\01.txt");
            Assert.Equal("23529853", x);
        }
    }
}
