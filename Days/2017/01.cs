namespace Days._2017
{
    public static class InverseCaptcha
    {
        static public int GetCaptcha(string str)
        {
            int sum = 0;
            str += str[0];

            for (int i = 0; i < str.Length - 1; i++)
            {
                if (str[i] == str[i + 1])  sum += (str[i] - '0');
            }
            return sum;
        }

        static public int GetNewCaptcha(string str)
        {
            int sum = 0;
            int step = str.Length / 2;
            for (int i = 0; i < step; i++)
            {
                if (str[i] == str[i + step]) sum += (str[i] - '0') * 2;
            }

            return sum;
        }
    }
}