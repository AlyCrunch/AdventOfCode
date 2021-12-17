namespace Days._2021
{
    public static class PacketDecoder
    {
        public static int GetSumVersions(string v)
            => GetAllPackets(HexToBinary(v)).GetSumVersion;
        public static Packet GetAllPackets(Queue<char> bits)
        {
            Packet packet = new();
            packet.version = BinaryToInt(bits.DequeueChunk(3));
            packet.type = BinaryToInt(bits.DequeueChunk(3));
            switch (packet.type)
            {
                case 4:
                    do
                    {
                        var litteral = bits.DequeueChunk(5).ToArray();
                        packet.value.AddRange(litteral[1..]);
                        if (litteral[0] == '0') break;
                    }
                    while (true);
                    packet.rest = bits.ToList();
                    break;
                default:
                    packet.isNumberOfSub = bits.Dequeue() == '1';
                    packet.length = BinaryToInt(bits.DequeueChunk(packet.GetLengthSize));

                    if (packet.isNumberOfSub)
                    {
                        for (int i = 0; i < packet.length; i++)
                        {
                            packet.rest = bits.ToList();
                            var subpacket = GetAllPackets(new Queue<char>(packet.rest));
                            packet.subPackets.Add(subpacket);
                            packet.rest = subpacket.rest.ToList();
                        }
                    }
                    else
                    {
                        var subPackets = bits.DequeueChunk(packet.length);
                        do
                        {
                            var subpacket = GetAllPackets(new Queue<char>(subPackets));
                            packet.subPackets.Add(subpacket);
                            subPackets = subpacket.rest.ToList();
                        }
                        while (subPackets.Any());
                    }
                    break;
            }
            return packet;
        }

        private static int BinaryToInt(IEnumerable<char> bits)
            => Convert.ToInt32(string.Join("", bits).PadLeft(4, '0'), 2);

        public static Queue<char> HexToBinary(string str)
            => new(str.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')).SelectMany(x => x));
            
        public class Packet
        {
            public int version;
            public int type;
            public bool isNumberOfSub;
            public int length;
            public List<Packet> subPackets = new();
            public List<char> value = new();
            public List<char> rest = new();
            public int GetLengthSize
                => (isNumberOfSub) ? 11 : 15;
            public int GetSumVersion
                => version + subPackets.Sum(x => x.GetSumVersion);
            public int GetNumber
                => value.Any() ? BinaryToInt(value) : 0 + subPackets.Sum(x => x.GetNumber);
        }
    }
    public static class QueueExtensions
    {
        public static IEnumerable<T> DequeueChunk<T>(this Queue<T> queue, int chunkSize)
        {
            for (int i = 0; i < chunkSize && queue.Count > 0; i++)
            {
                yield return queue.Dequeue();
            }
        }
    }
}