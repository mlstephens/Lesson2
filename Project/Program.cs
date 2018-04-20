using System;

namespace Lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            ArgumentsClass arguments = new ArgumentsClass(args);

            Console.WriteLine(arguments.IsCommandLineValid
                ? arguments.GetTotal().ToString()
                : "Invalid CommandLine.");
        }
    }
}
