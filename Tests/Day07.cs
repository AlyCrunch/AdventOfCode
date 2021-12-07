﻿using Xunit;
using Days;

namespace Tests
{
    public class Day07
    {
        private static readonly string test = "16,1,2,0,4,2,7,1,2,14";

        [Fact]
        public void FirstStarExample()
        {
            var x = TheTreacheryofWhales.GetLeastFuelPossible(test);
            Assert.Equal(37, x);
        }

        [Fact]
        public void FirstStarSolution()
        {
            var dataset = Helpers.ReadSingleLineFile("Inputs\\07.txt");
            var x = TheTreacheryofWhales.GetLeastFuelPossible(dataset);
            Assert.Equal(355521, x);
        }

        [Fact]
        public void SecondStarExample()
        {
            var x = TheTreacheryofWhales.GetLeastFuelPossibleInc(test);
            Assert.Equal(168, x);
        }

        [Fact]
        public void SecondStarSolution()
        {
            var dataset = Helpers.ReadSingleLineFile("Inputs\\07.txt");
            var x = TheTreacheryofWhales.GetLeastFuelPossibleInc(dataset);
            Assert.Equal(100148777, x);
        }
    }
}