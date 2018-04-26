using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson2
{
    public class Arguments
    {
        private const char _nameSeperator = '=';
        private const char _valueSeperator = ',';
        private const string _addNameValue = "-added";
        private const string _subtractNameValue = "-subtracted";

        private string[] _argumentsList = Array.Empty<string>();

        public Arguments(string[] arguments)
        {
            _argumentsList = arguments;
        }

        public bool IsCommandLineValid { get => _argumentsList.Any() && (_argumentsList.Any(a => a == _addNameValue) || _argumentsList.Any(a => a == _subtractNameValue)); }

        private double[] NumbersToAdd { get => GetNumbers(_addNameValue); }

        private double[] NumbersToSubtract { get => GetNumbers(_subtractNameValue); }

        private double[] GetNumbers(string argumentNameValue)
        {
            double[] argumentKeyValues = Array.Empty<double>();

            //find that namevalue
            argumentKeyValues = _argumentsList.SkipWhile(a => a != argumentNameValue)
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
