namespace Days._2017
{
    public static class RecursiveCircus
    {
        public static string GetNameBottom(string[] lines)
            => GetTree(lines).Name;

        private static Node GetTree(string[] lines)
        {
            var ParentNodes = GetParentNodes(lines);
            return ParentNodes.First(n => !ParentNodes
            .Any(c => c.Value.SubProgramNameList
            .Any(x => x.Equals(n.Value.Name)))).Value;
        }

        public static int WeightToBeBalanced(string[] lines)
        {
            var parent = GetTree(lines);
            var leafs = lines.Select(t => GetNode(t)).ToDictionary(k => k.Name);
            parent.FindChildren(leafs);
            return RecursiveCorrection(parent);
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
        private static int RecursiveCorrection(Node wrongNode, int goodvalue = 0, int correctNodeValue = -1)
        {
            var grouped = wrongNode.Children.GroupBy(x => x.FullNodeWeight);
            var goodNode = grouped.Where(g => g.Count() > 1).First().First();
            var valuesToGet = goodNode.FullNodeWeight;
            if (grouped.Count() > 1)
            {
                var falseNode = grouped.Where(g => g.Count() == 1).First().First();

                if (goodvalue == 0) goodvalue = goodNode.FullNodeWeight - falseNode.FullNodeWeight;

                correctNodeValue = falseNode.Weight + goodvalue;
                if (falseNode.StillHaveChildren() 
                    && falseNode.Children.GroupBy(x => x.FullNodeWeight).Count() > 1) 
                    return RecursiveCorrection(falseNode, goodvalue);
            }

            return correctNodeValue;
        }

        private static Dictionary<string, Node> GetParentNodes(string[] lines) 
            => lines.Where(n => n.Contains("->"))
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