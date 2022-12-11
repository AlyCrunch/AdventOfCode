using Days._2022;
using Xunit;

namespace Tests._2022
{
    public class Day07
    {
        private static readonly string[] test = { 
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k" };

        [Fact]
        public void FirstStarExample()
        {
            var result = new NoSpaceLeftOnDevice().GetTotalSumDirectories(test);
            Assert.Equal(95437, result);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2022\\07.txt");
            var result = new NoSpaceLeftOnDevice().GetTotalSumDirectories(dataset);
            Assert.Equal(919137, result);
        }

        [Fact]
        public void SecondStarExample()
        {
            var result = new NoSpaceLeftOnDevice().GetDirectoryToDelete(test);
            Assert.Equal(24933642, result);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2022\\07.txt");
            var result = new NoSpaceLeftOnDevice().GetDirectoryToDelete(dataset);
            Assert.Equal(2877389, result);
        }
    }
}