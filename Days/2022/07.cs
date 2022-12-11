namespace Days._2022
{
    public class NoSpaceLeftOnDevice
    {
        private Directory GetRoot(Directory dir)
            => (dir.Name == "/") ? dir : GetRoot(dir.Ancestor);    

        public static Directory Format(string cmd, Directory curr)
        {
            var param = cmd.Split(" ");
            if (param[0] == "$")
            {
                if (param[1] == "ls") return curr;
                if (param[1] == "cd")
                {
                    if (param[2] == "..")
                        return curr.Ancestor;
                    else
                        return curr.Children.First(x => x.Name == param[2]);
                }
            }
            else
            {
                if (param[0] == "dir")
                {
                    curr.Children.Add(new Directory(param[1], curr));
                    return curr;
                }
                else
                {
                    curr.Files.Add((long.Parse(param[0]), param[1]));
                    return curr;
                }
            }

            throw new Exception("oopsie");
        }

        public long GetTotalSumDirectories(string[] input)
        {
            var formatted = input.Skip(1).Aggregate(new Directory("/"), (dir, i) => Format(i, dir));
            var root = GetRoot(formatted);
            var flat = root.Flatten();

            return flat.Sum(x => x.SizeHundredK()) + root.SizeHundredK();
        }

        public long GetDirectoryToDelete(string[] input)
        {
            var formatted = input.Skip(1).Aggregate(new Directory("/"), (dir, i) => Format(i, dir));
            var root = GetRoot(formatted);
            var maxSize = root.Size();
            var flat = root.Flatten();
            var bigEnough = flat.Where(x => x.IsBigEnough(30000000 - (70000000 - maxSize)));

            return bigEnough.Min(x => x.Size());
        }
    }

    public class Directory
    {
        public string Name { get; set; } = "";
        public Directory Ancestor { get; set; }
        public List<Directory> Children { get; set; } = new();
        public HashSet<(long, string)> Files { get; set; } = new();

        public Directory(string name) => Name = name;
        public Directory(string name, Directory ancestor) { Name = name; Ancestor = ancestor; }

        public IEnumerable<Directory> Flatten()
            => Children.SelectMany(c => c.Flatten()).Concat(Children);

        public bool IsBigEnough(long need)
            => need <= Size();

        public long Size()
            => Files.Sum(x => x.Item1) + Children.Sum(x => x.Size());
        public long SizeHundredK()
            => (Size() > 100000) ? 0 : Size();
    }
}
