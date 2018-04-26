using System;
using System.Linq;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            Arguments structArguments = new Arguments(args.Select(a => a.ToLower()).ToArray());
            Console.WriteLine(structArguments.IsCommandLineValid
                ? structArguments.GetTotal().ToString()
                : "Invalid CommandLine.");
        }
    }
}
