namespace Days._2017
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

        static public int FindAllCharactersInGarbage(string str)
        {

            int startAt = -1;
            List<string> garbages = new();

            for (int i = 0; i < str.Length; i++)
            {
                if (i != 0) if (str[i - 1] == '!') continue;
                if (str[i] == '<') startAt = i;
                else if (str[i] == '>') garbages.Add(str[startAt..i]);
            }

            return garbages.Select(x => GetGarbageCharactersCount(x)).Sum();
        }

        static public int GetGarbageCharactersCount(string str)
        {
            int count = 0;
            for (int i = 1; i < str.Length - 1; i++)
            {
                if (str[i] == '!') continue;
                if (i - 1 >= 0 && str[i - 1] == '!') continue;
                count++;
            }
            return count;
        }
        //=> Enumerable.Range(1, str.Length - 2).Aggregate(0, (sum, i)
        //    => (str[i] != '!') ? (i - 1 >= 0 && str[i - 1] != '!') ? sum + 1 : sum : sum);
    }
}