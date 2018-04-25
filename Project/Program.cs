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

            ////class
            //ArgumentsClass classArguments = new ArgumentsClass(args);
            //Console.WriteLine(classArguments.IsCommandLineValid
            //    ? classArguments.GetTotal().ToString()
            //    : "Invalid CommandLine.");

            //struct
            ArgumentsStruct structArguments = new ArgumentsStruct(args);
            Console.WriteLine(structArguments.IsCommandLineValid
                ? structArguments.GetTotal().ToString()
                : "Invalid CommandLine.");
        }
    }
}
