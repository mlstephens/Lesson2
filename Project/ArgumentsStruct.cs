using System;
using System.Linq;

namespace Lesson2
{
    public struct ArgumentsStruct
    {
        private const char _nameSeperator = '=';
        private const char _valueSeperator = ',';
        private const string _addArgumentName = "added=";
        private const string _subtractArgumentName = "subtracted=";

        public static string[] _arguments = Array.Empty<string>();

        public ArgumentsStruct(string[] arguments)
        {
            _arguments = arguments;
        }

        private double[] NumbersToAdd { get => GetNumbers(_addArgumentName); }

        private double[] NumbersToSubtract { get => GetNumbers(_subtractArgumentName); }

        private double[] GetNumbers(string argumentType)
        {
            double[] argumentArray = Array.Empty<double>();

            //if we have arguments then build an array of just the numeric values for specified argument type
            if (_arguments.Any(a => a.Contains(argumentType)))
            {
                argumentArray = _arguments.First(a => a.Contains(argumentType))
                    .Substring(argumentType.Length)
                    .Split(_valueSeperator)
                    .Where(a => Double.TryParse(a, out double value))
                    .Select(double.Parse)
                    .ToArray();
            }

            return argumentArray;
        }

        public bool IsCommandLineValid { get => _arguments.Any() && !_arguments.Any(a => a.Split(_nameSeperator).Length != 2); }

        public double GetTotal()
        {
            return Math.Round(NumbersToAdd.Sum(n => n) - NumbersToSubtract.Sum(n => n), 4);
        }
    }
}
