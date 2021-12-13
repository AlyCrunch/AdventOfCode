using Xunit;
using Days._2021;


namespace Tests._2021
{
    public class Day01
    {
        [Fact]
        public void FirstStarExample()
        {
            var datas = new int[] {
                199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            var result = SonarSweep.GetDepthNumberInc(datas);
            Assert.Equal(7, result);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var datas = Days.Helpers.ReadFileAsInteger("Inputs\\2021\\01.txt");
            var result = SonarSweep.GetDepthNumberInc(datas);
            Assert.Equal(1624, result);
        }

        [Fact]
        public void SecondStarExample()
        {
            var datas = new int[] {
                199, 200, 208, 210, 200, 207, 240, 269, 260, 263 };
            var result = SonarSweep.GetDepthNumberIncGroupedBy3(datas);
            Assert.Equal(5, result);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var datas = Days.Helpers.ReadFileAsInteger("Inputs\\2021\\01.txt");
            var result = SonarSweep.GetDepthNumberIncGroupedBy3(datas);
            Assert.Equal(1653, result);
        }
    }
}