namespace Days._2017
{
    public static class KnotHash
    {
        static public int GetMultiplicationTwoFirst(int length, string input)
        {
            List<int> RevertSizes = input.Split(",").Select(x => int.Parse(x)).ToList();
            List<int> Values = Enumerable.Range(0, length + 1).ToList();
            int skipSize = 0;
            int index = 0;

            foreach (int size in RevertSizes)
            {
                List<int> currValues = new();
                List<int> skipValues = new();

                currValues = Values.GetRange(0, size);

                Values.RemoveRange(0, size);
                currValues.Reverse();

                Values.AddRange(currValues);

                skipValues = Values.GetRange(0, skipSize);
                Values.RemoveRange(0, skipSize);

                Values.AddRange(skipValues);
                index += size + skipSize;
                skipSize++;
            }

            var position = index % length + 1;
            var finalLength = (length + 1) - position;
            return Values[finalLength] * Values[finalLength + 1];
        }

        static public int GetKnotHash(int length, string input)
        {
            List<int> RevertSizes = input.Split(",").Select(x => int.Parse(x)).ToList();
            int[] Values = Enumerable.Range(0, length + 1).ToArray();
            int index = 0;
            int skipSize = 0;

            foreach (int size in RevertSizes)
            {
                Values.ReverseRange(index, size, length);
                index = (index + size + skipSize) % (length + 1);

                skipSize++;
            }

            return Values[0] * Values[1];
        }

        static private void ReverseRange(this int[] arr, int index, int size, int length)
        {
            List<int> subIndex = new();

            for (int i = 0; i < size; i++)
            {
                int n_index = index + i;
                subIndex.Add((n_index <= length) ? n_index : n_index - (length + 1));
            }

            for (int i = 0; i < size / 2; i++)
            {
                int tempFirst = arr[subIndex[i]];
                arr[subIndex[i]] = arr[subIndex[(size -1) - i]];
                arr[subIndex[(size - 1) - i]] = tempFirst;
            }
        }
    }
}
