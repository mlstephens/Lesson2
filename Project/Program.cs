using System;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            ArgumentsStruct arguments = new ArgumentsStruct(args);

            Console.WriteLine(arguments.IsCommandLineValid
                ? arguments.GetTotal().ToString()
                : "Invalid CommandLine.");
        }
    }
}
