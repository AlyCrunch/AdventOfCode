using Days._2017;
using Xunit;

namespace Tests._2017
{
    public class Day04
    {
        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2017\\04.txt");
            var x = HighEntropyPassphrases.CountValidPassphrases(dataset);
            Assert.Equal(455, x);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2017\\04.txt");
            var x = HighEntropyPassphrases.CountNewValidPassphrases(dataset);
            Assert.Equal(186, x);
        }
    }
}