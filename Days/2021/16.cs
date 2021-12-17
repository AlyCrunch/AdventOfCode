namespace Days._2021
{
    public static class PacketDecoder
    {
        public static long GetSumVersions(string v)
            => GetAllPackets(HexToBinary(v)).GetSumVersion;
        public static Packet GetAllPackets(Queue<char> bits)
        {
            Packet packet = new(bits.ToList(), BinaryToInt(bits.DequeueChunk(3)), BinaryToInt(bits.DequeueChunk(3)));
            
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
                            var subpacket = GetAllPackets(bits);
                            packet.subPackets.Add(subpacket);
                            bits = new Queue<char>(subpacket.rest);
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
                        packet.rest = bits.ToList();
                    }
                    break;
            }
            return packet;
        }

        private static long BinaryToInt(IEnumerable<char> bits)
            => Convert.ToInt64(string.Join("", bits).PadLeft(4, '0'), 2);

        public static Queue<char> HexToBinary(string str)
            => new(str.Select(c => Convert.ToString(Convert.ToInt64(c.ToString(), 16), 2).PadLeft(4, '0')).SelectMany(x => x));
            
        public class Packet
        {
            public long version;
            public long type;
            public bool isNumberOfSub;
            public long length;
            public List<Packet> subPackets = new();
            public List<char> value = new();
            public List<char> rest = new();
            public List<char> source = new();
            public int GetLengthSize
                => (isNumberOfSub) ? 11 : 15;
            public long GetSumVersion
                => version + subPackets.Sum(x => x.GetSumVersion);
            public long GetNumber
                => value.Any() ? BinaryToInt(value) : 0 + subPackets.Sum(x => x.GetNumber);
            public Packet(List<char> source, long version, long type)
            {
                this.version = version;
                this.type = type;
                this.source = source;
            }
        }
    }
    public static class QueueExtensions
    {
        public static IEnumerable<T> DequeueChunk<T>(this Queue<T> queue, long chunkSize)
        {
            for (long i = 0; i < chunkSize && queue.Count > 0; i++)
            {
                yield return queue.Dequeue();
            }
        }
    }
}