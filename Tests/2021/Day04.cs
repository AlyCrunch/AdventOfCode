using Xunit;
using Days;

namespace Tests._2021
{
    public class Day04
    {
        private static readonly string[] test =
            {
            "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
            "",
            "22 13 17 11  0",
            " 8  2 23  4 24",
            "21  9 14 16  7",
            " 6 10  3 18  5",
            " 1 12 20 15 19",
            "",
            " 3 15  0  2 22",
            " 9 18 13 17  5",
            "19  8  7 25 23",
            "20 11 10 24  4",
            "14 21 16 12  6",
            "",
            "14 21 17 24  4",
            "10 16 15  9 19",
            "18  8 23 26 20",
            "22 11 13  6  5",
            " 2  0 12  3  7"};

        [Fact]
        public void FirstStarExample()
        {
            var x = GiantSquid.GetFirstWinner(test);
            Assert.Equal(4512, x);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Helpers.ReadFile("Inputs\\2021\\04.txt");
            var x = GiantSquid.GetFirstWinner(dataset);
            Assert.Equal(58374, x);
        }

        [Fact]
        public void SecondStarExample()
        {
            var x = GiantSquid.GetLastWinner(test);
            Assert.Equal(1924, x);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Helpers.ReadFile("Inputs\\2021\\04.txt");
            var x = GiantSquid.GetLastWinner(dataset);
            Assert.Equal(11377, x);
        }
    }
}