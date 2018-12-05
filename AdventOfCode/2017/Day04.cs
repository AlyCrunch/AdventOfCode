using System;
using System.Linq;
using static AdventOfCode.Helpers.Utilis;

namespace AdventOfCode._2017
{
    public static class Day4
    {
        static public void GetTest(int nb = 0)
        {
            var file = GetFileToArray(GetFilePath(2017, 4, true, nb));
            Console.WriteLine($"Answer is Part 1 : {Part2(file)} & Part 2 : {Part2(file)}");
        }

        public static void GetSolution()
        {
            var file = GetFileToArray(GetFilePath(2017, 4));
            Console.WriteLine($"Answer is Part 1 : {Part2(file)} & Part 2 : {Part2(file)}");
        }

        static private int Part1(string[] lines)
        {
            var passwordsList = lines.Select(x => x.Split(' ')).ToList();
            return passwordsList.Count(x => x.GroupBy(i => i).Count() == x.Count());
        }

        static private int Part2(string[] lines)
        {
            var passphraseList = lines.Select(x => x.Split(' ')
                                                   .Select(s => string.Concat(s.OrderBy(c => c)))).ToList();
            int unique_password = 0;
            foreach(var passphrase in passphraseList)
            {
                var grouped_passwords = passphrase.GroupBy(d => d)
                                            .Select(group => new
                                            {
                                                Group = group.Key,
                                                Count = group.Count()
                                            });
                var password_is_not_unique = grouped_passwords.Any(x => x.Count > 1);
                if (!password_is_not_unique)
                    unique_password++;
            }

            return unique_password;
        }
    }
}
