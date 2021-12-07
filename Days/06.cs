using System;
using System.Linq;

namespace Days
{
    public static class Lanternfish
    {
        public static long GetLanterfish(string fishes, int days = 80)
        {
            var states = InitStates(fishes.Split(',').Select(x => int.Parse(x)));

            for (int i = 0; i < days; i++)
                states = NextDay(states);

            return states.Sum(x => x.Value);
        }

        public static Dictionary<int,long> InitStates(IEnumerable<int> fishes)
        {
            Dictionary<int, long> states = new();
            for (int i = 0; i <= 8; i++)
            {
                states.Add(i, fishes.Count(x => x == i));
            }
            return states;
        }

        public static Dictionary<int, long> NextDay(Dictionary<int, long> states)
        {
            Dictionary<int, long> newState = new();

            for (int i = 1; i <= 8 ; i++)
            {
                newState.Add(i - 1, states[i]);
            }
            newState[6] = newState[6] + states[0];
            newState.Add(8,states[0]);

            return newState;
        }

    }
}
