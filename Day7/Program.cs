using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            string allnodesstr = System.IO.File.ReadAllText("sample.txt");
            string[] result = allnodesstr.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            var parentsNodes = result.Where(n => n.Contains("->")).Select(t => Node(t));
            var megaparent = parentsNodes.First(n => parentsNodes.Count(c => c.Item2.Any(x => x.Equals(n.Item1))) == 0);
            Console.WriteLine($"Result is {megaparent.Item1} with child {string.Join(", ", megaparent.Item2)}");

            Console.Read();
        }

        static Tuple<string, List<string>> Node(string node)
        {
            var twoParts = node.Split(" -> ");
            string nodeName = twoParts[0].Split(' ').First();
            return new Tuple<string, List<string>>(nodeName, twoParts[1].Split(", ").ToList());
        }

    }
}

