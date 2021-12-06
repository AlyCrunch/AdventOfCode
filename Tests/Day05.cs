using Xunit;
using Days;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    public class Day05
    {
        private static readonly string[] test =
        {
            "0,9 -> 5,9",
            "8,0 -> 0,8",
            "9,4 -> 3,4",
            "2,2 -> 2,1",
            "7,0 -> 7,4",
            "6,4 -> 2,0",
            "0,9 -> 2,9",
            "3,4 -> 1,4",
            "0,0 -> 8,8",
            "5,5 -> 8,2"
        };

        [Fact]
        public void FirstStarExample()
        {
            var x = HydrothermalVenture.CountOverlaps(test);
            Assert.Equal(5, x);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Helpers.ReadFile("Inputs\\05.txt");
            var x = HydrothermalVenture.CountOverlaps(dataset);
            Assert.Equal(5608, x);
        }

        [Fact]
        public void SecondStarExample()
        {
            var x = HydrothermalVenture.CountOverlapsWithDiagonals(test);
            Assert.Equal(12, x);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Helpers.ReadFile("Inputs\\05.txt");
            var x = HydrothermalVenture.CountOverlapsWithDiagonals(dataset);
            Assert.Equal(20299, x);
        }
    }
}
