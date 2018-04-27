using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson2
{
    public class Arguments
    {
        private const char _valueSeperator = ',';
        private const string _addNameValue = "-added";
        private const string _subtractNameValue = "-subtracted";

        private string[] _arguments = null;

        public Arguments(string[] arguments)
        {
            _arguments = arguments.Select(a => a.ToLower()).ToArray();
        }

        //public bool IsCommandLineValid { get => (_arguments.Length >= 1 && _arguments.Length <= 4) && (_arguments.Any(a => a == _addNameValue) || _arguments.Any(a => a == _subtractNameValue)) ; }
        public bool IsCommandLineValid { get => _arguments.Any(a => a == _addNameValue) || _arguments.Any(a => a == _subtractNameValue); }

        private double[] NumbersToAdd { get => GetNumbers(_addNameValue); }

        private double[] NumbersToSubtract { get => GetNumbers(_subtractNameValue); }

        private double[] GetNumbers(string argumentNameValue)
        {
            //find that namevalue
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
            return Math.Round(NumbersToAdd.Sum() - NumbersToSubtract.Sum(),4);
        }
    }
}
