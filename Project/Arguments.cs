using System;
using System.Linq;

namespace Lesson2
{
    public struct Arguments
    {
        private const char _nameSeperator = '=';
        private const char _valueSeperator = ',';
        private const string _addNameValue = "-added";
        private const string _subtractNameValue = "-subtracted";

        private static string[] _arguments = Array.Empty<string>();

        public Arguments(string[] arguments)
        {
            _arguments = arguments;
        }

        public bool IsCommandLineValid { get => _arguments.Any() && (_arguments.Any(a => a == _addNameValue) || _arguments.Any(a => a == _subtractNameValue)); }

        private double[] NumbersToAdd { get => GetNumbers(_addNameValue); }

        private double[] NumbersToSubtract { get => GetNumbers(_subtractNameValue); }

        private double[] GetNumbers(string argumentNameValue)
        {
            double[] argumentKeyValues = Array.Empty<double>();

            //build array of numeric keyvalues
            argumentKeyValues = _arguments.ToArray().SkipWhile(a => a != argumentNameValue)
                .Skip(1)
                .DefaultIfEmpty(string.Empty)
                .First()
                .Split(_valueSeperator)
                .Where(a => Double.TryParse(a, out double value))
                .Select(Double.Parse)
                .ToArray();

            return argumentKeyValues;
        }

        public double GetTotal()
        {
            return Math.Round(NumbersToAdd.Sum(n => n) - NumbersToSubtract.Sum(n => n), 4);
        }
    }
}
