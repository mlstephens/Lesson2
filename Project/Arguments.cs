using System;
using System.Linq;

namespace Lesson2
{
    public struct Arguments
    {
        private const char _valueSeperator = ',';
        private const string _addNameValue = "-added";
        private const string _subtractNameValue = "-subtracted";

        private static string[] _arguments = Array.Empty<string>();

        public Arguments(string[] arguments)
        {
            _arguments = arguments.Select(a => a.ToLower()).ToArray();
        }

        public bool IsCommandLineValid { get => _arguments.Any(a => a == _addNameValue) || _arguments.Any(a => a == _subtractNameValue); }

        private double[] NumbersToAdd { get => GetNumbers(_addNameValue); }

        private double[] NumbersToSubtract { get => GetNumbers(_subtractNameValue); }

        private double[] GetNumbers(string argumentNameValue)
        {
            //build array of numeric keyvalues
            double[] argumentKeyValues = _arguments.SkipWhile(a => a != argumentNameValue)
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
            return NumbersToAdd.Sum(n => n) - NumbersToSubtract.Sum(n => n);
        }
    }
}
