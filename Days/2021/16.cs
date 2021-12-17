namespace Days._2021
{
    public static class PacketDecoder
    {
        private static readonly Dictionary<char, string> hex2bin = new()
        {
            { '0', "0000" },
            { '1', "0001" },
            { '2', "0010" },
            { '3', "0011" },
            { '4', "0100" },
            { '5', "0101" },
            { '6', "0110" },
            { '7', "0111" },
            { '8', "1000" },
            { '9', "1001" },
            { 'A', "1010" },
            { 'B', "1011" },
            { 'C', "1100" },
            { 'D', "1101" },
            { 'E', "1110" },
            { 'F', "1111" }
        };
        private static readonly Dictionary<string, char> bin2hex = new()
        {
            { "0000", '0' },
            { "0001", '1' },
            { "0010", '2' },
            { "0011", '3' },
            { "0100", '4' },
            { "0101", '5' },
            { "0110", '6' },
            { "0111", '7' },
            { "1000", '8' },
            { "1001", '9' },
            { "1010", 'A' },
            { "1011", 'B' },
            { "1100", 'C' },
            { "1101", 'D' },
            { "1110", 'E' },
            { "1111", 'F' }
        };

        public static int GetSumVersions(string v)
            => GetAllPackets(HexToBinary(v)).GetSumVersion;
        //000000000111111111222222222233333333334444444444555
        //01234567890123456789012345678901234567890123456789012
        //VVVTTTAAAAABBBBBCCCCC                                       (4)
        //VVVTTTILLLLLLLLLLLAAAAAAAAAAABBBBBBBBBBBCCCCCCCCCCC       1 (not 4)
        //VVVTTTILLLLLLLLLLLLLLLAAAAAAAAAAABBBBBBBBBBBBBBBB         0 (not 4)
        // V = Version
        // T = Type 4 => read packet / type != 4 subpacket
        // if type 4 => groups of 5 bits, start with 1 if !last / 0 if last
        // if type != 4
        // I = Length Type ID (0 = 15 bits=> length(L) of sum sub packet)
        //                    (1 = 11 bits=> 11bits of subpackets n times (L))
        // L = 15/11 bits represent the length or count 
        // ABCD.. subpackets
        public static Packet GetAllPackets(string binary)
        {
            Packet packet = new();
            packet.source = binary;
            packet.version = bin2hex[ToBits(binary[0..3])] - '0';
            packet.type = bin2hex[ToBits(binary[3..6])] - '0';
            switch (packet.type)
            {
                case 4:
                    foreach (var group in binary[6..].Select((c, i) => new { Key = i / 5, Value = c }).GroupBy(x => x.Key, x => x.Value))
                    {
                        packet.value += string.Join("", group)[1..];
                        if (group.ElementAt(0) == '0')
                            break;
                    }
                    packet.rest = packet.source.Replace(packet.value, "");
                    break;
                default:
                    packet.isContainingSubpackets = binary[6] == '1';
                    try
                    {
                        packet.length = Convert.ToInt32(binary[7..(7 + packet.GetLengthSize)], 2);
                    }
                    catch
                    {
                        throw new Exception($"{binary}[7..{packet.GetLengthSize}]");
                    }

                    if (packet.isContainingSubpackets)
                    {
                        foreach (var group in binary[18..].Select((c, i) => new { Key = i / 11, Value = c })
                            .GroupBy(x => x.Key, x => x.Value).Take(packet.length))
                        {
                            packet.SubPackets.Add(GetAllPackets(string.Join("", group)));
                        }
                    }
                    else
                    {
                        string substring = binary[22..(22 + packet.length)];
                        do
                        {
                            var subpacket = GetAllPackets(substring);
                            packet.SubPackets.Add(subpacket);
                            substring = subpacket.rest;
                        }
                        while (substring.Length >= packet.length);
                    }
                    break;
            }
            return packet;
        }

        private static string ToBits(string str)
            => str.PadLeft(4, '0');

        public static string HexToBinary(string str)
            => str.Aggregate("", (bits, c)
                => bits + hex2bin[c]);
        public class Packet
        {
            public int version;
            public int type;
            public bool isContainingSubpackets;
            public int length;
            public List<Packet> SubPackets = new();
            public string value = string.Empty;
            public string rest = string.Empty;
            public string source = string.Empty;
            public int GetLengthSize
                => (isContainingSubpackets) ? 11 : 15;
            public int GetSumVersion
                => version + SubPackets.Sum(x => x.GetSumVersion);
        }
    }
}