namespace Days
{
    public static class MazeTwistyTrampolines
    {
        public static int GetSteps(string[] lines)
        {
            int[] maze = lines.Select(int.Parse).ToArray();

            int position = 0;
            int OOMaze = maze.Length;
            int moves = 0;

            while (position < OOMaze)
            {
                moves++;
                int temp_position = maze[position];
                maze[position]++;
                position += temp_position;
            }

            return moves;
        }

        private static int GetStepsOffset(string[] lines)
        {
            int[] maze = lines.Select(int.Parse).ToArray();

            int position = 0;
            int OOMaze = maze.Length;
            int moves = 0;

            while (position < OOMaze)
            {
                moves++;
                int temp_position = maze[position];
                if (temp_position >= 3) maze[position]--;
                else maze[position]++;
                position += temp_position;
            }

            return moves;
        }
    }
}