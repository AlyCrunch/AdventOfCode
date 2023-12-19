namespace Days._2023
{
    public static class WaitForIt
    {
        private static List<(int time, int distance)> Format(string[] input)
        {
            var parse = input.Select(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                               .Skip(1)
                               .Select(y => int.Parse(y)));

            return parse.ElementAt(0).Zip(parse.ElementAt(1), (x, y) => (x, y)).ToList();
        }

        private static (long time, long distance) FormatLong(string[] input)
        {
            var parse = input.Select(x => 
            long.Parse(x.Split(":", StringSplitOptions.RemoveEmptyEntries)[1].Replace(" ", "")));

            return (parse.ElementAt(0), parse.ElementAt(1));

        }

        public static int GetProductRecords(string[] input)
        {
            var records = Format(input);
            
            return records.Select(x => Enumerable.Range(0, x.time + 1)
                                                     .Select(y => DistanceByMs(y, x.time))
                                                     .Count(y => y > x.distance))
                               .Aggregate(1, (product, item) => product * item);
        }

        public static object GetConcatRecord(string[] input)
        {
            var (time, distance) = FormatLong(input);
            long i;
            for (i = 0; i < time; i++)
            {
                if (DistanceByMs(i, time) > distance)
                    break;
            }

            return time + 1 - (i) * 2;
        }

        private static int DistanceByMs(int push, int time)
            => (time - push) * push;
        private static long DistanceByMs(long push, long time)
            => (time - push) * push;
    }
}
