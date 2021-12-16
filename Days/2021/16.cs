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
        //3 bits = version //3 bits = packet type ID
        // ID 4 = litteral value 
        // ID != 4 => operator
        //length type ID : 0 => next 15 bits => total length in bits sub packet
        //length type ID : 1 => next 11 bits => nb sub-packets immediately contained
        // after groups of 5 bits, start with 1 if not the last/ 0 if last
        public static int GetSumVersions(string v)
        {
            var binary = HexToBinary(v);

            throw new NotImplementedException();
        }

        public static (int version, int type, List<string> sub) GetPacket(string binary)
        {
            (int version, int type, List<string> sub) packet = new();
            packet.version = bin2hex["0" + binary[0..2]] - '0';
            packet.sub = new();
            if (binary[3..5] == "100")
            {
                packet.type = 4;
                int i = 0;
                do
                {
                    packet.sub.Add(binary[(7 + i)..(10 + i)]);
                    if (binary[6 + i] == '0') break;
                    i += 5;
                }
                while (true);
            }
            else
            {
                if(binary[6] == '1')
                {
                    int nbSub = Convert.ToInt32(binary[7..17], 2);
                    for (int i = 1; i <= nbSub; i++)
                    {
                        packet.sub.Add(binary[(7 + i * 11)..(17 + i * 11)]);
                    }
                }
                else
                {

                }
            }

            return packet;
        }


        public static string HexToBinary(string str)
            => str.Aggregate("", (bits, c)
                => bits + hex2bin[c]);
    }
}