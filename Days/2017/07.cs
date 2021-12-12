namespace Days
{
    public static class RecursiveCircus
    {
        private static int CorrectNodeValue;

        public static string GetNameBottom(string[] lines)
            => GetParent(lines).Name;

        public static int Part2Tree(string[] lines)
        {
            var parent = GetParent(lines);
            var leafs = lines.Select(t => GetNode(t)).ToDictionary(k => k.Name);
            parent.FindChildren(leafs);
            RecursiveCorrection(parent);
            return CorrectNodeValue;
        }

        private static Node GetParent(string[] lines)
        {
            if (ParentNodes == null || ParentNodes.Count == 0) 
                ParentNodes = GetParentNodes(lines);

            var firstParent = ParentNodes.First(n => !ParentNodes.Any(c => c.Value.SubProgramNameList.Any(x => x.Equals(n.Value.Name))));
            return firstParent.Value;
        }

        private static Node GetNode(string node)
        {
            var twoParts = node.Split(" -> ");
            string[] programInfos = twoParts.First().Split(' ');
            List<string> subp = (twoParts.Length > 1) ? twoParts.Last().Split(", ").ToList() : new List<string>();

            string nodeName = programInfos.First();
            int weight = int.Parse(programInfos[1].Remove(0, 1).Remove(programInfos[1].Length - 2, 1));

            return new Node(nodeName, weight, subp);
        }
        private static void RecursiveCorrection(Node wrongNode, int goodvalue = 0)
        {
            var grouped = wrongNode.Children.GroupBy(x => x.FullNodeWeight);
            var goodNode = grouped.Where(g => g.Count() > 1).First().First();
            var valuesToGet = goodNode.FullNodeWeight;
            if (grouped.Count() > 1)
            {
                var falseNode = grouped.Where(g => g.Count() == 1).First().First();

                if (goodvalue == 0) goodvalue = goodNode.FullNodeWeight - falseNode.FullNodeWeight;

                CorrectNodeValue = falseNode.Weight + goodvalue;
                if (falseNode.StillHaveChildren() && falseNode.Children.GroupBy(x => x.FullNodeWeight).Count() > 1) RecursiveCorrection(falseNode, goodvalue);
            }
        }

        private static Dictionary<string, Node> ParentNodes = new();
        private static Dictionary<string, Node> GetParentNodes(string[] lines) => lines.Where(n => n.Contains("->"))
                                                                                       .Select(t => GetNode(t)).ToDictionary(x => x.Name);
    }

    class Node
    {
        public List<Node> Children { get; set; } = new List<Node>();
        public Node Parent { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public List<string> SubProgramNameList { get; set; } = new List<string>();
        public int ChildrenWeight { get => Children.Sum(x => x.FullNodeWeight); }
        public int FullNodeWeight { get => ChildrenWeight + Weight; }
        public string ChildrenToString { get => string.Join(",", Children.Select(x => $"{x.Name} ({x.FullNodeWeight})")) + " : " + FullNodeWeight; }

        public Node(string name, int weight, List<string> strProgList)
        {
            Name = name;
            Weight = weight;
            SubProgramNameList = strProgList;
        }

        public void FindChildren(Dictionary<string, Node> allnodes)
        {
            foreach (string c in SubProgramNameList)
            {
                var node = allnodes[c];
                node.Parent = this;
                Children.Add(allnodes[c]);
            }
            foreach (Node child in Children)
            {
                if (child.StillHaveChildren())
                    child.FindChildren(allnodes);
            }
        }

        public bool StillHaveChildren() => SubProgramNameList.Count > 0;
    }
}