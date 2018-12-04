using System;
using static AdventOfCode.Helpers.Utilis;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2018
{
    enum GUARD_STATE
    {
        begin, asleep, awake
    }

    public static class Day4
    {
        static public void GetTest()
        {
            var file = GetFileToArray(GetFilePath(2018, 4, true));
            Console.WriteLine("Test one :");
            Console.WriteLine(Answer(file));
        }

        public static void GetSolution()
        {
            var file = GetFileToArray(GetFilePath(2018, 4));
            Console.WriteLine("\nSolution :");
            Console.WriteLine(Answer(file));
        }

        public static object Answer(string[] inputs)
        {
            List<(DateTime TimeStamp, string Information)> guards_records = new List<(DateTime TimeStamp, string Information)>();
            foreach (var timestamp in inputs)
            {
                string ts_str = timestamp.Substring(1, 16);
                string infos = timestamp.Substring(19, timestamp.Length - 19);
                DateTime ts = DateTime.ParseExact(ts_str, "yyyy-MM-dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                guards_records.Add((ts, infos));
            }

            guards_records = guards_records.OrderBy(x => x.TimeStamp).ToList();

            int guard = 0;
            DateTime asleepStart = new DateTime();
            Dictionary<int, List<DateTime>> SleepyGuards = new Dictionary<int, List<DateTime>>();

            foreach (var (TimeStamp, Information) in guards_records)
            {
                if (IsWakingUp(Information))
                {
                    TimeSpan span = TimeStamp.Subtract(asleepStart);
                    for (int i = 0; i < span.TotalMinutes; i++)
                    {
                        if (SleepyGuards.ContainsKey(guard)) SleepyGuards[guard].Add(asleepStart.AddMinutes(i));
                        else SleepyGuards.Add(guard, new List<DateTime>() { asleepStart.AddMinutes(i) });
                    }
                    continue;
                }

                if (IsFallingAsleep(Information))
                {
                    asleepStart = TimeStamp;
                    continue;
                }

                if (IsBeginningShift(Information))
                {
                    guard = GetGuardID(Information);
                    continue;
                }
            }

            var sleepiestGuard = SleepyGuards.OrderByDescending(i => i.Value.Count()).FirstOrDefault();

            var sleepiestGuardGrouped = sleepiestGuard.Value.GroupBy(x => x.Minute).ToList()
                                                            .OrderByDescending(x => x.Count())
                                                            .FirstOrDefault();


            var partTwoAnswer = PartTwo(SleepyGuards);

            return $"Part 1 : Guard #{sleepiestGuard.Key} likes to sleep at {sleepiestGuardGrouped.Key} min " +
                $": {sleepiestGuard.Key} x {sleepiestGuardGrouped.Key} = {sleepiestGuard.Key * sleepiestGuardGrouped.Key} \n{partTwoAnswer}";
        }

        public static object PartTwo(Dictionary<int, List<DateTime>> guards)
        {
            var guard = guards.Select(x => new
            {
                ID = x.Key,
                Value = x.Value.GroupBy(d => d.Minute)
                                            .Select(group => new
                                            {
                                                Minute = group.Key,
                                                Count = group.Count()
                                            }).OrderByDescending(y => y.Count).First()
            }).OrderByDescending(x => x.Value.Count).First();

            return $"Part 2 : Guard #{guard.ID} likes to sleep at {guard.Value.Minute} min " +
                $": {guard.ID} x {guard.Value.Minute} = {guard.ID * guard.Value.Minute}";
        }

        private static bool IsBeginningShift(string information) => information.Contains("begins shift");
        private static bool IsFallingAsleep(string information) => information.Equals("falls asleep");
        private static bool IsWakingUp(string information) => information.Equals("wakes up");

        private static int GetGuardID(string information) => int.Parse(information.Split(" #")[1].Split(" ")[0]);
    }
}
