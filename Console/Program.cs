using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            var outputs = GetOutputs();
            Console.WriteLine("");
        }

        public static IEnumerable<Tuple<string, string, string>> GetOutputs()
        {
            var assembly = Assembly.Load("Days");
            var types = assembly.GetTypes();

            var methodName1 = "OutputFirst";
            var methodName2 = "OutputSecond";

            foreach (var type in types)
            {
                if (type.Name == "Helpers") yield break;
                var method1 = type.GetMethod(methodName1);
                var method2 = type.GetMethod(methodName2);

                var output1 = method1.Invoke(null, null);
                var output2 = method2.Invoke(null, null);
                yield return new Tuple<string, string, string>(type.Name, (string)output1, (string)output2);
            }
        }
    }
}
