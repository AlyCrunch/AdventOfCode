using Days._2017;
using Xunit;

namespace Tests._2017
{
    public class Day09
    {
        [Fact]
        public void FirstStarExample()
        {
            Assert.Equal(1, StreamProcessing.GetTotalScore("{}").score);
            Assert.Equal(6, StreamProcessing.GetTotalScore("{{{}}}").score);
            Assert.Equal(5, StreamProcessing.GetTotalScore("{{},{}}").score);
            Assert.Equal(16, StreamProcessing.GetTotalScore("{{{},{},{{}}}}").score);
            Assert.Equal(1, StreamProcessing.GetTotalScore("{<a>,<a>,<a>,<a>}").score);
            Assert.Equal(9, StreamProcessing.GetTotalScore("{{<ab>},{<ab>},{<ab>},{<ab>}}").score);
            Assert.Equal(9, StreamProcessing.GetTotalScore("{{<!!>},{<!!>},{<!!>},{<!!>}}").score);
            Assert.Equal(3, StreamProcessing.GetTotalScore("{{<a!>},{<a!>},{<a!>},{<ab>}}").score);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadSingleLineFile("Inputs\\2017\\09.txt");
            Assert.Equal(12505, StreamProcessing.GetTotalScore(dataset).score);
        }

        [Fact]
        public void SecondStarExample()
        {
            Assert.Equal(0, StreamProcessing.GetTotalScore("<>").garbageCount);
            Assert.Equal(17, StreamProcessing.GetTotalScore("<random characters>").garbageCount);
            Assert.Equal(3, StreamProcessing.GetTotalScore("<<<<>").garbageCount);
            Assert.Equal(2, StreamProcessing.GetTotalScore("<{!>}>").garbageCount);
            Assert.Equal(0, StreamProcessing.GetTotalScore("<!!>").garbageCount);
            Assert.Equal(0, StreamProcessing.GetTotalScore("<!!!>>").garbageCount);
            Assert.Equal(10, StreamProcessing.GetTotalScore("<{o\"i!a,<{i<a>").garbageCount);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadSingleLineFile("Inputs\\2017\\09.txt");
            Assert.Equal(6671, StreamProcessing.GetTotalScore(dataset).garbageCount);
        }
    }
}