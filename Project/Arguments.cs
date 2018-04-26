using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson2
{
    public class Arguments
    {
        private const string _addNameValue = "-added";
        private const string _subtractNameValue = "-subtracted";

        private string[] _arguments = Array.Empty<string>();

        public Arguments(string[] arguments)
        {
            _arguments = arguments;
        }

        public bool IsCommandLineValid { get => (_arguments.Any(a => a == _addNameValue) || _arguments.Any(a => a == _subtractNameValue)); }

        private double[] NumbersToAdd { get => GetNumbers(_addNameValue); }

        private double[] NumbersToSubtract { get => GetNumbers(_subtractNameValue); }

        private double[] GetNumbers(string argumentNameValue)
        {
            //find that namevalue
            double[] argumentKeyValues = _arguments.SkipWhile(a => a != argumentNameValue)
                .Skip(1)
                .DefaultIfEmpty(string.Empty)
                .First()
                .Split(',')
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
