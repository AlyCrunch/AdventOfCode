using Days._2023;
using Xunit;

namespace Tests._2023
{
    public class Day06
    {
        private static readonly string[] test =
        {
            "Time:      7  15   30",
            "Distance:  9  40  200"
        };

        private static readonly string[] dataset =
        {
            "Time:        49     97     94     94",
            "Distance:   263   1532   1378   1851"
        };

        [Fact]
        public void FirstStarExample()
        {
            var result = WaitForIt.GetProductRecords(test);
            Assert.Equal(288, result);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var result = WaitForIt.GetProductRecords(dataset);
            Assert.Equal(4403592, result);
        }

        [Fact]
        public void SecondStarExample()
        {
            var result = WaitForIt.GetConcatRecord(test);
            Assert.Equal((long)71503, result);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var result = WaitForIt.GetConcatRecord(dataset);
            Assert.Equal((long)38017587, result);
        }
    }
}