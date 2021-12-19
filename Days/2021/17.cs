namespace Days._2021
{
    public static class TrickShot
    {
        public static int GetTheHighestY(string input)
            => RangeShoot(input).Max(x => x.max);

        public static int GetTheHits(string input)
            => RangeShoot(input).Count(x => x.max != int.MinValue);

        public static List<(List<((int x, int y) probe, (int x, int y) velocity)>, int max)> RangeShoot(string input)
        {
            var target = FormatTarget(input);
            var range = new List<(List<((int x, int y) probe, (int x, int y) velocity)>, int max)>();
            
            for (int y = target.y.min; y <= -target.y.min; y++)
                for (int x = 0; x <= target.x.max; x++)
                    range.Add(SendProbe((x, y), target));

            return range;
        }

        public static ((int x, int y) probe, (int x, int y) velocity) NextStep((int x, int y) probe, (int x, int y) velocity, ((int min, int max) x, (int min, int max) y) target)
        {
            probe = (probe.x + velocity.x, probe.y + velocity.y);
            velocity.x = (velocity.x > 0) 
                ? velocity.x - 1 
                : (velocity.x < 0) 
                    ? velocity.x + 1 
                    : velocity.x;
            velocity.y--;

            return (probe, velocity);
        }

        public static (List<((int x, int y) probe, (int x, int y) velocity)> states, int max) SendProbe((int x, int y) velocity, ((int min, int max) x, (int min, int max) y) target)
        {
            (int x, int y) probe = (0,0);
            List<((int x, int y) probe, (int x, int y) velocity)> states = new();
            do
            {
                (probe, velocity) = NextStep(probe, velocity, target);
                states.Add((probe, velocity));
            }
            while (!IsMissing(probe, target) && !IsHitting(probe, target));

            if (IsHitting(probe, target)) return (states, states.Max(x => x.probe.y));

            return (states, int.MinValue);
        }

        private static bool IsMissing((int x, int y) probe, ((int min, int max) x, (int min, int max) y) target)
            => probe.x > target.x.max || probe.y < target.y.min;
        private static bool IsHitting((int x, int y) probe, ((int min, int max) x, (int min, int max) y) target)
            => (target.x.max >= probe.x && probe.x >= target.x.min) 
            && (target.y.max >= probe.y && probe.y >= target.y.min);

        public static ((int min, int max) x, (int min, int max) y) FormatTarget(string line)
        {
            var arr = line.Replace("target area: x=", "").Split(", y=").Select(x => x.Split("..")).ToArray();
            return ((int.Parse(arr[0][0]), int.Parse(arr[0][1])), (int.Parse(arr[1][0]), int.Parse(arr[1][1])));
        }
    }
}