using Days._2021;
using Xunit;

namespace Tests._2021
{
    public class Day16
    {
        [Fact]
        public void FirstStarExample()
        {
            Assert.Equal("110100101111111000101000", PacketDecoder.HexToBinary("D2FE28"));
            Assert.Equal(16, PacketDecoder.GetSumVersions("8A004A801A8002F478"));
            Assert.Equal(12, PacketDecoder.GetSumVersions("620080001611562C8802118E34"));
            Assert.Equal(23, PacketDecoder.GetSumVersions("C0015000016115A2E0802F182340"));
            Assert.Equal(31, PacketDecoder.GetSumVersions("A0016C880162017C3686B18A3D4780"));
        }

        [Fact]
        public void FirstStarSolution()
        {
            //var dataset = Days.Helpers.ReadFile("Inputs\\year\\day.txt");
        }

        [Fact]
        public void SecondStarExample()
        {
        }

        [Fact]
        public void SecondStarSolution()
        {
        }
    }
}