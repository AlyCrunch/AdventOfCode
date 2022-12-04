using Days._2022;
using Xunit;

namespace Tests._2022
{
    public class Day04
    {
        private readonly string[] test = {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8" 
        };

        [Fact]
        public void FirstStarExample()
        {
            var result = CampCleanup.CountContained(test);
            Assert.Equal(2, result);
        }

        [Fact]
        public void FirstStarSolution() 
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2022\\04.txt");
            var result = CampCleanup.CountContained(dataset);
            Assert.Equal(462, result);
        }

        [Fact]
        public void SecondStarExample()
        {
            var result = CampCleanup.CountOverlap(test);
            Assert.Equal(4, result);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2022\\04.txt");
            var result = CampCleanup.CountOverlap(dataset);
            Assert.Equal(835, result);
        }
    }
}