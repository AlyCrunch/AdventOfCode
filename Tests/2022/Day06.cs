using Days._2022;
using Xunit;

namespace Tests._2022
{
    public class Day06
    {
        private static readonly string datastream1 = "mjqjpqmgbljsphdztnvjfqwrcgsmlb";
        private static readonly string datastream2 = "bvwbjplbgvbhsrlpgdmjqwftvncz";
        private static readonly string datastream3 = "nppdvjthqldpwncqszvftbrmjlhg";
        private static readonly string datastream4 = "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg";
        private static readonly string datastream5 = "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw";


        [Fact]
        public void FirstStarExample()
        {
            int result1 = TuningTrouble.GetSOPMarker(datastream1);
            Assert.Equal(7, result1);

            int result2 = TuningTrouble.GetSOPMarker(datastream2);
            Assert.Equal(5, result2);

            int result3 = TuningTrouble.GetSOPMarker(datastream3);
            Assert.Equal(6, result3);

            int result4 = TuningTrouble.GetSOPMarker(datastream4);
            Assert.Equal(10, result4);

            int result5 = TuningTrouble.GetSOPMarker(datastream5);
            Assert.Equal(11, result5);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadSingleLineFile("Inputs\\2022\\06.txt");
            var result = TuningTrouble.GetSOPMarker(dataset);
            Assert.Equal(1109, result);
        }

        [Fact]
        public void SecondStarExample()
        {
            int result1 = TuningTrouble.GetSOMMarker(datastream1);
            Assert.Equal(19, result1);

            int result2 = TuningTrouble.GetSOMMarker(datastream2);
            Assert.Equal(23, result2);

            int result3 = TuningTrouble.GetSOMMarker(datastream3);
            Assert.Equal(23, result3);

            int result4 = TuningTrouble.GetSOMMarker(datastream4);
            Assert.Equal(29, result4);

            int result5 = TuningTrouble.GetSOMMarker(datastream5);
            Assert.Equal(26, result5);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadSingleLineFile("Inputs\\2022\\06.txt");
            var result = TuningTrouble.GetSOMMarker(dataset);
            Assert.Equal(3965, result);
        }
    }
}