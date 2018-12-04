using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            _2017.Day1.GetSolution();
            
            _2017.Day1.GetTest("1212");
            _2017.Day1.GetTest("1221");
            _2017.Day1.GetTest("123425");
            _2017.Day1.GetTest("123123");
            _2017.Day1.GetTest("12131415");

            Console.ReadKey();
        }
    }
}
