using Xunit;
using Days._2021;
using System.Linq;

namespace Tests._2021
{
    public class Day13
    {
        private readonly string[] test = new string[]
        {
            "6,10",
            "0,14",
            "9,10",
            "0,3",
            "10,4",
            "4,11",
            "6,0",
            "6,12",
            "4,1",
            "0,13",
            "10,12",
            "3,4",
            "3,0",
            "8,4",
            "1,10",
            "2,14",
            "8,10",
            "9,0",
            "",
            "fold along y=7",
            "fold along x=5"
        };

        [Fact]
        public void FirstStarExample()
        {
            Assert.Equal(17, TransparentOrigami.CountPoints(test, 1));
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2021\\13.txt");
            Assert.Equal(724, TransparentOrigami.CountPoints(dataset, 1));
        }

        [Fact]
        public void SecondStarExample()
        {
            string[] result = new string[]
            {
                "#####",
                "#...#",
                "#...#",
                "#...#",
                "#####"
            };

            Assert.Equal(result, TransparentOrigami.GetCode(test));
        }
    }
}
