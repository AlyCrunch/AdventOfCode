using Days._2017;
using Xunit;

namespace Tests._2017
{
    public class Day09
    {
        [Fact]
        public void FirstStarExample()
        {
            Assert.Equal(1, StreamProcessing.GetTotalScore("{}"));
            Assert.Equal(6, StreamProcessing.GetTotalScore("{{{}}}"));
            Assert.Equal(5, StreamProcessing.GetTotalScore("{{},{}}"));
            Assert.Equal(16, StreamProcessing.GetTotalScore("{{{},{},{{}}}}"));
            Assert.Equal(1, StreamProcessing.GetTotalScore("{<a>,<a>,<a>,<a>}"));
            Assert.Equal(9, StreamProcessing.GetTotalScore("{{<ab>},{<ab>},{<ab>},{<ab>}}"));
            Assert.Equal(9, StreamProcessing.GetTotalScore("{{<!!>},{<!!>},{<!!>},{<!!>}}"));
            Assert.Equal(3, StreamProcessing.GetTotalScore("{{<a!>},{<a!>},{<a!>},{<ab>}}"));
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadSingleLineFile("Inputs\\2017\\09.txt");
            Assert.Equal(12505, StreamProcessing.GetTotalScore(dataset));
        }

        [Fact]
        public void SecondStarExample()
        {
            Assert.Equal(0, StreamProcessing.GetGarbageCharactersCount("<>"));
            Assert.Equal(17, StreamProcessing.GetGarbageCharactersCount("<random characters>"));
            Assert.Equal(3, StreamProcessing.GetGarbageCharactersCount("<<<<>"));
            Assert.Equal(2, StreamProcessing.GetGarbageCharactersCount("<{!>}>"));
            Assert.Equal(0, StreamProcessing.GetGarbageCharactersCount("<!!>"));
            Assert.Equal(0, StreamProcessing.GetGarbageCharactersCount("<!!!>>"));
            Assert.Equal(10, StreamProcessing.GetGarbageCharactersCount("<{o\"i!a,<{i<a>"));
        }

        [Fact]
        public void SecondStarSolution()
        {
            //var dataset = Days.Helpers.ReadSingleLineFile("Inputs\\2017\\09.txt");
            //Assert.Equal(3, StreamProcessing.FindAllCharactersInGarbage(dataset));
        }
    }
}