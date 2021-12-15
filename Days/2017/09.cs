namespace Days._2017
{
    public static class StreamProcessing
    {
        static public (int score, int garbageCount) GetTotalScore(string str)
        {
            bool garbage = false;
            int score = 0;
            int depth = 1;
            int garbageCount = 0;

            for (int i = 0; i < str.Length; i++)
            {
                var c = str[i];
                if (c == '!') i++;
                else if (garbage && c != '>') garbageCount++;
                else if (c == '<') garbage = true;
                else if (c == '>') garbage = false;
                else if (c == '{') score += depth++;
                else if (c == '}') depth--;
            }

            return (score, garbageCount);
        }
    }
}