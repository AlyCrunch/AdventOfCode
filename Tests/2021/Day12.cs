using Days._2021;
using Xunit;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;

namespace Tests._2021
{
    public class Day12
    {
        private static readonly string[] test1 = new string[]
        {
            "start-A",
            "start-b",
            "A-c",
            "A-b",
            "b-d",
            "A-end",
            "b-end"
        };

        private static readonly string[] test2 = new string[]
        {
            "dc-end",
            "HN-start",
            "start-kj",
            "dc-start",
            "dc-HN",
            "LN-dc",
            "HN-end",
            "kj-sa",
            "kj-HN",
            "kj-dc"
        };

        private static readonly string[] test3 = new string[]
        {
            "fs-end",
            "he-DX",
            "fs-he",
            "start-DX",
            "pj-DX",
            "end-zg",
            "zg-sl",
            "zg-pj",
            "pj-he",
            "RW-he",
            "fs-DX",
            "pj-RW",
            "zg-RW",
            "start-pj",
            "he-WI",
            "zg-he",
            "pj-fs",
            "start-RW"
        };

        [Fact]
        public void FirstStarExample()
        {
            Assert.Equal(10, PassagePathing.CountAllPaths(test1));
            Assert.Equal(19, PassagePathing.CountAllPaths(test2));
            Assert.Equal(226, PassagePathing.CountAllPaths(test3));
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2021\\12.txt");
            Assert.Equal(5874, PassagePathing.CountAllPaths(dataset));
        }

        [Fact]
        public void SecondStarExample()
        {
            Assert.Equal(36, PassagePathing.CountAllPathsWithBonus(test1));
            Assert.Equal(103, PassagePathing.CountAllPathsWithBonus(test2));
            Assert.Equal(3509, PassagePathing.CountAllPathsWithBonus(test3));
        }

        [Fact] //180612 //180612
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2021\\12.txt");
            Assert.Equal(153592, PassagePathing.CountAllPathsWithBonus(dataset));
        }
    }
}