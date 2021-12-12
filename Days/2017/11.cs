namespace Days
{
    public static class HexEd
    {
        static public int GetFewestStepsToReach(string input)
        {
            List<int> nb_steps = new();

            double N = 0, E = 0;

            foreach (string var in input.Split(","))
            {
                switch (var)
                {
                    case "n": N++; break;
                    case "s": N -= 1; break;
                    case "ne": N += 0.5; E += 0.5; ; break;
                    case "se": N -= 0.5; E += 0.5; ; break;
                    case "nw": N += 0.5; E -= 0.5; ; break;
                    case "sw": N -= 0.5; E -= 0.5; ; break;
                }
                nb_steps.Add(GetSteps(N, E));
            }

            return nb_steps.Max();
        }

        static private int GetSteps(double N, double E)
            => (int)(Math.Abs(N) + Math.Abs(E));
    }
}