using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string doc = System.IO.File.ReadAllText("sample.txt");
            string[] line = doc.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            int[][] arr = new int[line.Length][];
            int result = 0;
            for (int i = 0; i < line.Length; i++)
            {
                var arrStr = line[i].Split(new string[] { "\t", " " }, StringSplitOptions.RemoveEmptyEntries);
                arr[i] = arrStr.Select(int.Parse).ToArray();
                result += arr[i].Max() - arr[i].Min();
            }

            Console.WriteLine($"Result is {result}");
            Console.Read();
        }
    }
}
