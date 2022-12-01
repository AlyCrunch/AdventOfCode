namespace Days._2022
{
    public static class CalorieCounting
    {
        public static IEnumerable<int> GetListSumCalories(IEnumerable<string> calories)
            => calories.Append(string.Empty).Aggregate((new List<int>(), 0), (acc, s)
                 => string.IsNullOrEmpty(s) ?
                     (acc.Item1.Append(acc.Item2).ToList(), 0)
                 : (acc.Item1, acc.Item2 + int.Parse(s))).Item1;

        public static int GetMaxCaloriesHeld(IEnumerable<string> calories)
            => GetListSumCalories(calories).Max();


        public static int GetTop3MaxHeld(IEnumerable<string> calories)
            => GetListSumCalories(calories).OrderByDescending(x => x).Take(3).Sum();
    }
}