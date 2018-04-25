using System;
using System.Linq;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            //handle potential upper case argument name values
            args = args.Select(a => a.ToLower()).ToArray();

            ArgumentsClass arguments = new ArgumentsClass(args);

            Console.WriteLine(arguments.IsCommandLineValid
                ? arguments.GetTotal().ToString()
                : "Invalid CommandLine.");
        }
    }
}
