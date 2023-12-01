namespace Days._2023
{
    public class Trebuchet
    {
        private static readonly Dictionary<string, string> LiteralDigits = new()
        {
            ["zero"] = "0",
            ["one"] = "1",
            ["two"] = "2",
            ["three"] = "3",
            ["four"] = "4",
            ["five"] = "5",
            ["six"] = "6",
            ["seven"] = "7",
            ["eight"] = "8",
            ["nine"] = "9",
            ["0"] = "0",
            ["1"] = "1",
            ["2"] = "2",
            ["3"] = "3",
            ["4"] = "4",
            ["5"] = "5",
            ["6"] = "6",
            ["7"] = "7",
            ["8"] = "8",
            ["9"] = "9",
        };

        public static int GetFirstLastDigitSum(IEnumerable<string> input)
            => input.Aggregate(0, (sum, row) =>
            sum + int.Parse(row.First(c => char.IsDigit(c)).ToString() + row.Last(c => char.IsDigit(c))));

        public static int GetFirstLastDigitLiteralSum(IEnumerable<string> input)
        {
            var keywords = LiteralDigits.Keys.ToList();
            return input.Aggregate(0, (sum, row) =>  
                {
                    var indexes = GetKeywordsIndexes(keywords, row);
                    return sum + int.Parse(LiteralDigits[indexes.MinBy(x => x.index).key] + LiteralDigits[indexes.MaxBy(x => x.index).key]);
                }            
            );
        }

        private static IEnumerable<(int index, string key)> GetKeywordsIndexes(IEnumerable<string> keywords, string row)
            => keywords.Select(key => new List<(int index, string key)>(){
                (row.IndexOf(key), key),
                (row.LastIndexOf(key), key)
            }).SelectMany(i => i).Where(x => x.index != -1).Distinct();
    }
}
