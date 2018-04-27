using System;
using System.Linq;

namespace Lesson2
{
    public struct Arguments
    {
        private const char _valueSeperator = ',';
        private const string _addNameValue = "-added";
        private const string _subtractNameValue = "-subtracted";

        private string[] _arguments;

        public Arguments(string[] arguments)
        {
            _arguments = arguments;
        }

        public bool IsCommandLineValid { get => _arguments.Any(a => String.Compare(a, _addNameValue, true) == 0) || _arguments.Any(a => String.Compare(a, _subtractNameValue, true) == 0); }

        private double[] NumbersToAdd { get => GetNumbers(_addNameValue); }

        private double[] NumbersToSubtract { get => GetNumbers(_subtractNameValue); }

        private double[] GetNumbers(string argumentNameValue)
        {
            //build array of numeric keyvalues
            double[] argumentKeyValues = _arguments.SkipWhile(a => a.ToLower() != argumentNameValue.ToLower())
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
            return Math.Round(NumbersToAdd.Sum() - NumbersToSubtract.Sum(),4);
        }
    }
}
