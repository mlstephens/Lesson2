using System;
using System.Linq;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            Arguments arguments = new Arguments(args.Select(a => a.ToLower()).ToArray());
            Console.WriteLine(arguments.IsCommandLineValid
                ? arguments.GetTotal().ToString()
                : "Invalid CommandLine.");
        }
    }
}
