using System;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            ArgumentsClass classArguments = new ArgumentsClass(args);

            Console.WriteLine(classArguments.IsCommandLineValid
                ? classArguments.GetTotal().ToString()
                : "Invalid CommandLine.");

            ArgumentsStruct structArguments = new ArgumentsStruct(args);

            Console.WriteLine(structArguments.IsCommandLineValid
                ? structArguments.GetTotal().ToString()
                : "Invalid CommandLine.");
        }
    }
}
