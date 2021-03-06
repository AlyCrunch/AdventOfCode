﻿using System;
using static AdventOfCode.Helpers.Utilis;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2017
{
    public static class Day11
    {
        static public void GetTest(int nb = 0)
        {
            var path = GetFilePath(2017, 11, true, nb);
            Console.WriteLine($"Answer is {MakeMagic(GetFileToString(path))}");
        }

        public static void GetSolution()
        {
            var path = GetFilePath(2017, 11);
            Console.WriteLine($"Answer is {MakeMagic(GetFileToString(path))}");
        }

        static private int MakeMagic(string input)
        {
            List<string> moves = input.Split(",").ToList();
            List<int> nb_steps = new List<int>();


            double N = 0, E = 0;

            foreach (string var in moves)
            {
                switch (var)
                {
                    case "n": N++; break;
                    case "s": N -= 1; break;
                    case "ne": N += 0.5; E += 0.5; ; break;
                    case "se": N -= 0.5; E += 0.5; ; break;
                    case "nw": N += 0.5; E -= 0.5; ; break;
                    case "sw": N -= 0.5; E -= 0.5; ; break;
                }
                nb_steps.Add(GetSteps(N, E));
            }

            nb_steps.Max();
            return nb_steps.Max();
        }

        static private int GetSteps(double N, double E)
        {

            var count = Math.Abs(N) + Math.Abs(E);
            return (int)count;
        }
    }
}
