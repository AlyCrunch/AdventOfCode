namespace Days._2024
{
    public static class RedNosedReports
    {
        public static string Part1(string[] input)
        {
            var safe = 0;
            foreach (var line in input)
            {
                var report = line.Split(" ").Select(x => int.Parse(x)).ToArray();
                bool direction = report[0] < report[1]; //true == asc
                bool isSafe = true;

                var diffBase = Math.Abs(report[0] - report[1]);
                if (diffBase < 0 || diffBase > 4) break;

                for (int i = 1; i < report.Count() - 1; i++)
                {
                    if ((report[i] < report[i + 1]) != direction)
                    { isSafe = false; break; }

                    var diff = Math.Abs(report[i] - report[i + 1]);

                    if (diff <= 0 || diff >= 4)
                    { isSafe = false; break; }
                }
                if (isSafe) safe++;
            }
            return safe.ToString();
        }

        public static string Part2(string[] input)
        {
            return string.Empty;
        }
    }
}
