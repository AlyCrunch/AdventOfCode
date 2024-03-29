﻿using Days._2023;
using Xunit;

namespace Tests._2023
{
    public class Day04
    {
        private static readonly string[] test =
        {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"

        };

        [Fact]
        public void FirstStarExample()
        {
            var result = Scratchcards.GetPoints(test);
            Assert.Equal(13, result);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2023\\04.txt");
            var result = Scratchcards.GetPoints(dataset);
            Assert.Equal(21105, result);
        }

        [Fact]
        public void SecondStarExample()
        {
            var result = Scratchcards.GetNumberCards(test);
            Assert.Equal(30, result);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Days.Helpers.ReadFile("Inputs\\2023\\04.txt");
            var result = Scratchcards.GetNumberCards(dataset);
            Assert.Equal(5329815, result);
        }
    }
}