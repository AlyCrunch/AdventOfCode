using System;
using System.Collections.Generic;
using System.IO;

namespace Days
{
    public static class Helpers
    {
        public static string[] ReadFile(string fileName)
            => File.ReadAllLines(fileName);
        public static int[] ArrToInt(string[] arr)
            => Array.ConvertAll(arr, s => int.Parse(s));
        public static int[] ReadFileAsInteger(string fileName)
            => Array.ConvertAll(File.ReadAllLines(fileName), s => int.Parse(s));
        public static T[] ReadFileAs<T>(string filename)
            => Array.ConvertAll(File.ReadAllLines(filename), s => (T)Convert.ChangeType(s, typeof(T)));
        public static string ReadSingleLineFile(string fileName)
            => File.ReadLines(fileName).First();
        public static void SaveInFile(string path, string[] lines)
            => File.WriteAllLines(path, lines);
    }
}