using Days._2024;
using Xunit;

namespace Tests._2024
{
    public class Day02
    {

        public readonly string[] example1 = {
            "7 6 4 2 1",
            "1 2 7 8 9",
            "9 7 6 2 1",
            "1 3 2 4 5",
            "8 6 4 4 1",
            "1 3 6 7 9"};

        [Fact]
        public void FirstStarExample()
        {
            var x = RedNosedReports.Part1(example1);
            Assert.Equal("2", x);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2024\\02.txt");
            var x = RedNosedReports.Part1(dataset);
            Assert.Equal("1388114", x);
        }

        [Fact]
        public void SecondStarExample()
        {
            var x = RedNosedReports.Part2(example1);
            Assert.Equal("1388114", x);
        }
        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2024\\02.txt");
            var x = RedNosedReports.Part2(dataset);
            Assert.Equal("1388114", x);
        }
    }
}
