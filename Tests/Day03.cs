using Xunit;
using Days;
using System.Linq;

namespace Tests
{
    public class Day03
    {

        private static readonly string[] test =
            {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"};

        [Fact]
        public void FirstStarExample()
        {
            var c = BinaryDiagnostic.GetConsumption(test);
            Assert.Equal(198, c);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Helpers.ReadFile("Inputs\\03.txt");
            var c = BinaryDiagnostic.GetConsumption(dataset);
            Assert.Equal(4191876, c);
        }
        
        [Fact]
        public void SecondStarExample()
        {
            var o = BinaryDiagnostic.GetLifeSupportRating(test);
            Assert.Equal(230, o);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Helpers.ReadFile("Inputs\\03.txt");
            var o = BinaryDiagnostic.GetLifeSupportRating(dataset);
            Assert.Equal(3414905, o);
        }
    }
}