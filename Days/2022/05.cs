namespace Days._2022
{
    public static class SupplyStacks
    {
        public static string ExecuteProcedure(IEnumerable<string> input, bool stackable = false)
        {
            var (Init, Procedure) = Format(input);
            var end = Procedure.Aggregate(Init, (stack, p) => (stackable)?
            ProceedMoveStack(stack, p): Proceed(stack, p)).Select(x => x.Peek());

            return string.Join("", end);
        }

        public static (Stack<char>[] Init, IEnumerable<int[]> Procedure) Format(IEnumerable<string> input)
        {
            var space = input.ToList().IndexOf("");
            var init = GetInitCrates(input.Take(space - 1));
            var delimiters = new string[] { "move "," from ", " to" };
            var procedures = input.Skip(space + 1)
                .Select(x => x.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Select(y => int.Parse(y)).ToArray());
            return (init, procedures);
        }

        public static Stack<char>[] GetInitCrates(IEnumerable<string> input)
        {
            var index = Enumerable.Range(0, input.Last().Length -1 )
                .Aggregate(new List<int>(), (indexes, x) => { 
                    if (char.IsLetter(input.Last()[x])) indexes.Add(x); return indexes; });

            return index.Aggregate(new List<Stack<char>>(), (stacks, i) =>
                {
                    stacks.Add(
                      Enumerable.Range(0, input.Count()).Reverse()
                      .Aggregate(new Stack<char>(), (stack, x) =>
                      { if (char.IsLetter(input.ElementAt(x)[i])) stack.Push(input.ElementAt(x)[i]); return stack; })
                      ); return stacks;
                }).ToArray();
        }

        public static Stack<char>[] Proceed(Stack<char>[] cranes, int[] p)
            => Enumerable.Range(0, p[0])
            .Aggregate(cranes, (c, x) => { cranes[p[2] - 1].Push(cranes[p[1] - 1].Pop()); return cranes; });

        public static Stack<char>[] ProceedMoveStack(Stack<char>[] cranes, int[] p)
        {
            return cranes[p[1] - 1].ToList().Take(p[0]).Reverse().Aggregate(cranes, (c, x) => { c[p[2] -1].Push(x); c[p[1] -1].Pop(); return c; });
        }
    }
}