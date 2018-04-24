using System;
using System.Linq;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            //handle potential upper case arguments
            args = args.Select(a => a.ToLower()).ToArray();

            //class
            ArgumentsClass argumentsClass = new ArgumentsClass(args);
            Console.WriteLine(argumentsClass.IsCommandLineValid
                ? argumentsClass.GetTotal().ToString()
                : "Invalid CommandLine.");

            //partial class
            ArgumentsPartialClass argumentsPartialClass = new ArgumentsPartialClass(args);
            Console.WriteLine(argumentsPartialClass.IsCommandLineValid
                ? argumentsPartialClass.GetTotal().ToString()
                : "Invalid CommandLine.");
        }
    }
}
