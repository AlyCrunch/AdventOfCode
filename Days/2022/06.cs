namespace Days._2022
{
    public static class TuningTrouble
    {
        public static int GetSOPMarker(string datastream)
            => datastream.Select((c, i) => new { data = c, index = i }).Skip(3)
            .First(x => datastream.Skip(x.index - 3).Take(4).Distinct().Count() == 4).index + 1;
        public static int GetSOMMarker(string datastream)
            => datastream.Select((c, i) => new { data = c, index = i }).Skip(13)
            .First(x => datastream.Skip(x.index - 13).Take(14).Distinct().Count() == 14).index + 1;
    }
}