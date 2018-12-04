using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace AdventOfCode.Helpers
{
    static public class Utilis
    {
        public static string GetFilePath(int year, int day, bool test = false, int nb = 0) 
            => $"./Samples/{year}/{(day < 10 ? "0" + day.ToString() : day.ToString())}" +
            $"_sample{(test ? "_test" : "")}{(nb > 0 ? nb.ToString() : "")}.txt";

        public static string[] GetFileToArray(string filename)
            => GetFileToString(filename).Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        
        public static string GetFileToString(string filename)
            => System.IO.File.ReadAllText(filename);

        public static T[] Slice<T>(this T[] source, int start, int end)
        {
            // Handles negative ends.
            if (end < 0)
            {
                end = source.Length + end;
            }
            int len = end - start;

            // Return new array.
            T[] res = new T[len];
            for (int i = 0; i < len; i++)
            {
                res[i] = source[i + start];
            }
            return res;
        }

        public static void GetSolution(int year, int day)
        {
            string[] file = GetFileToArray(GetFilePath(year, day));
            
            Type dayT = Type.GetType($"AdventOfCode._{year}.Day{day}");
            if (dayT is null)
                Console.WriteLine($"Exercice of day {day} or/and {year} not found.");
            else
            {
                MethodInfo methodInfo = dayT.GetMethod("GetSolution");
                if(methodInfo is null)
                    Console.WriteLine($"Method of {day}/{year} not found.");
                methodInfo.Invoke(null, new[] { file });
            }

            Console.ReadKey();
        }

        public static void GetTest(int year, int day, bool test = false, int nb = 0)
        {
            var file = GetFileToArray(GetFilePath(year,day,test,nb));

        }
    }
}
