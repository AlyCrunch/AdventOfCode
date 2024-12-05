namespace Days._2024
{
    public static class HistorianHysteria
    {
        public static string Part1(string path)
        {
            var (first, second) = GetLists(path);
            var secondOrdered = new Queue<int>(second.OrderBy(x => x));
            return first.OrderBy(x => x).Aggregate(0, (sum, curr) => sum + Math.Abs(curr - secondOrdered.Dequeue())).ToString();
        }

        public static string Part2(string path)
        {
            var (first, second) = GetLists(path);
            return first.Aggregate(0, (sum, curr) => sum + curr * second.Count(x => x == curr)).ToString();
        }

        private static (IEnumerable<int> first, IEnumerable<int> second) GetLists(string path)
        {
            var first = new List<int>();
            var second = new List<int>();

            StreamReader reader = new StreamReader(path);

            string s;

            while ((s = reader.ReadLine()) != null)
            {
                var parts = s.Split("   ");
                first.Add(int.Parse(parts[0]));
                second.Add(int.Parse(parts[1]));
            }

            reader.Close();

            return (first, second);
        }
    }
}
