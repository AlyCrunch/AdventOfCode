namespace Days
{
    public static class StreamProcessing
    {
        static public int GetTotalScore(string str)
        {
            bool garbage = false;
            int score = 0;
            int depth = 1;

            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];
                if (c == '!') i++;
                else if (garbage && c != '>') continue;
                else if (c == '<') garbage = true;
                else if (c == '>') garbage = false;
                else if (c == '{') score += depth++;
                else if (c == '}') depth--;
            }

            return score;
        }
    }
}