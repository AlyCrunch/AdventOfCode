namespace Days._2021
{
    public static class TrickShot
    {


        public static int GetTheHighestY(string input)
        {
            var target = FormatTarget(input);
            Dictionary<(int x, int y), int> MaxYValues = new();
            return 0;
        }

        public static ((int min, int max) x, (int min, int max) y) FormatTarget(string line)
        {
            var arr = line.Replace("target area: x=", "").Split(", y=")
            .Select(x => x.Split("..")).ToArray();
            return ((int.Parse(arr[0][0]), int.Parse(arr[0][1])), (int.Parse(arr[1][0]), int.Parse(arr[1][1])));
        }

        private static ((int x, int y) probe, (int x, int y) velocity) NextStep((int x, int y) probe, (int x, int y) velocity, ((int min, int max) x, (int min, int max) y) target)
        {
            probe.Add(velocity);
            velocity.x = (velocity.x > 0) ? velocity.x - 1 : (velocity.x < 1) ? velocity.x + 1 : velocity.x;
            velocity.y--;

            return (probe, velocity);
        }
        private static (int x, int y) Add(this (int x, int y) a, (int x, int y) b)
        => (a.x + b.x, a.y + b.y);

    }
}