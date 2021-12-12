using Days;
using Xunit;

namespace Tests._2017
{
    public class Day02
    {
        [Fact]
        public void FirstStarExample()
        {
            var test = new string[]
            {
                "5 1 9 5",
                "7 5 3",
                "2 4 6 8"
            };
            Assert.Equal(18, CorruptionChecksum.GetChecksum(test));
        }

        [Fact]
        public void FirstStarSolution()
        {
            var x = CorruptionChecksum.GetChecksum(Helpers.ReadFile("Inputs\\2017\\02.txt"));
            Assert.Equal(34925, x);
        }

        [Fact]
        public void SecondStarExample()
        {
            var test = new string[]
            {
                "5 9 2 8",
                "9 4 7 3",
                "3 8 6 5"
            };
            Assert.Equal(9, CorruptionChecksum.GetEvenChecksum(test));
        }

        [Fact]
        public void SecondStarSolution()
        {
            var x = CorruptionChecksum.GetEvenChecksum(Helpers.ReadFile("Inputs\\2017\\02.txt"));
            Assert.Equal(221, x);
        }
    }
}