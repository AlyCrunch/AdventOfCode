namespace Days
{
    public static class HighEntropyPassphrases
    {
        static public int CountValidPassphrases(string[] lines)
            => lines.Select(x => x.Split(' '))
                .Count(x => x.GroupBy(i => i).Count() == x.Length);


        static public int CountNewValidPassphrases(string[] lines)
        {
            var passphraseList = lines.Select(x => x.Split(' ').Select(s => string.Concat(s.OrderBy(c => c))));
            int unique_password = 0;
            foreach (var passphrase in passphraseList)
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