namespace Days
{
    public static class LCM
    {
        public static int Find(int a, int b)
        {
            return (a / GCD(a, b)) * b;
        }

        public static int GCD(int x, int y)
        {
            while (y != 0)
            {
                int tmp = x % y;
                x = y;
                y = tmp;
            }

            return x;
        }
    }
}