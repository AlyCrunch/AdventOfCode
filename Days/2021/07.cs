namespace Days
{
    public static class TheTreacheryofWhales
    {
        public static int GetLeastFuelPossible(string datas)
        {
            var pos = datas.Split(',').Select(x => int.Parse(x));
            List<int> result = new();
            Parallel.For(pos.Min(), pos.Max(),
                i => result.Add(pos.Aggregate(0, (sum, item) => sum + Math.Abs(item - i))));
            return result.Min(x => x);
        }
        public static int GetLeastFuelPossibleInc(string datas)
        {
            var pos = datas.Split(',').Select(x => int.Parse(x));
            List<int> result = new();
            Parallel.For(pos.Min(), pos.Max(),
                i => result.Add(pos.Aggregate(0, (sum, item)
                => sum + (Math.Abs(item - i) * (Math.Abs(item - i) + 1) / 2))));
            return result.Min(x => x);
        }
    }
}