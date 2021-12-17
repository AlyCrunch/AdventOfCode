using Days._2021;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests._2021
{
    public class Day16
    {
        [Fact]
        public void FirstStarExample()
        {
            //Assert.Equal(20, PacketDecoder.GetSumVersions("38006F45291200"));
            var packet = PacketDecoder.GetAllPackets(PacketDecoder.HexToBinary("38006F45291200"));
            Assert.Equal(1, packet.version); // 6 - 2
            Assert.Equal("110100010100101001000100100", packet.SubPackets.First().source);
            //Assert.Equal("11010001010", packet.SubPackets.First().value);
            //Assert.Equal("0101001000100100", packet.SubPackets.First().rest);
            //0101001000100100
            //1010101010000010

            //Assert.Equal(12, PacketDecoder.GetSumVersions("8A004A801A8002F478"));
            //Assert.Equal(12, PacketDecoder.GetSumVersions("620080001611562C8802118E34"));
            //Assert.Equal(23, PacketDecoder.GetSumVersions("C0015000016115A2E0802F182340"));
            //Assert.Equal(31, PacketDecoder.GetSumVersions("A0016C880162017C3686B18A3D4780"));
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