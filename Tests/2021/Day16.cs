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
            Assert.Equal(16, PacketDecoder.GetSumVersions("8A004A801A8002F478"));
            Assert.Equal(12, PacketDecoder.GetSumVersions("620080001611562C8802118E34"));
            Assert.Equal(23, PacketDecoder.GetSumVersions("C0015000016115A2E0802F182340"));
            Assert.Equal(31, PacketDecoder.GetSumVersions("A0016C880162017C3686B18A3D4780"));
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadSingleLineFile("Inputs\\2021\\16.txt");
            Assert.Equal(920, PacketDecoder.GetSumVersions(dataset));
        }

        [Fact]
        public void SecondStarExample()
        {

            Assert.Equal(3, PacketDecoder.GetEvaluationExpression("C200B40A82"));
            Assert.Equal(54, PacketDecoder.GetEvaluationExpression("04005AC33890"));
            Assert.Equal(7, PacketDecoder.GetEvaluationExpression("880086C3E88112"));
            Assert.Equal(9, PacketDecoder.GetEvaluationExpression("CE00C43D881120"));
            Assert.Equal(1, PacketDecoder.GetEvaluationExpression("D8005AC2A8F0"));
            Assert.Equal(0, PacketDecoder.GetEvaluationExpression("F600BC2D8F"));
            Assert.Equal(0, PacketDecoder.GetEvaluationExpression("9C005AC2F8F0"));
            Assert.Equal(1, PacketDecoder.GetEvaluationExpression("9C0141080250320F1802104A08"));
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadSingleLineFile("Inputs\\2021\\16.txt");
            Assert.Equal(10185143721112, PacketDecoder.GetEvaluationExpression(dataset));
        }
    }
}