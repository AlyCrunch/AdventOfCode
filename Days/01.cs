using System.Linq;

namespace Days
{
    public static class SonarSweep
    {
        public static int GetDepthNumberInc(int[] values)
        {
            var increased = 0;
            int memory = values[0];

            values.Skip(1).ToList().ForEach(x =>
            {
                if (x > memory) increased++;
                memory = x;
            });

            return increased;
        }

        public static int GetDepthNumberIncGroupedBy3(int[] values)
        {
            var increased = 0;
            for (int i = 1; i < values.Length - 2; i++)
            {
                var a = values[i - 1] + values[i] + values[i + 1];
                var b = values[i] + values[i + 1] + values[i + 2];
                if (b > a) increased++;
            }
            return increased;
        }
    }
}