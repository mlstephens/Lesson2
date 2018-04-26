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

        private List<string> _argumentsList = new List<string>();

        public Arguments(string[] arguments)
        {
            _argumentsList = arguments.ToList();
        }

        private List<double> NumbersToAdd { get => GetNumbers(_addNameValue); }

        private List<double> NumbersToSubtract { get => GetNumbers(_subtractNameValue); }

        private List<double> GetNumbers(string argumentNameValue)
        {
            List<double> argumentKeyValues = new List<double>();

            //find that namevalue
            argumentKeyValues = _argumentsList.SkipWhile(a => a != argumentNameValue)
                .Skip(1)
                .DefaultIfEmpty(string.Empty)
                .First()
                .Split(_valueSeperator)
                .Where(a => Double.TryParse(a, out double value))
                .Select(Double.Parse)
                .ToList();

            return argumentKeyValues;
        }

        public bool IsCommandLineValid { get => _argumentsList.Any() && ( _argumentsList.Any(a => a == _addNameValue) || _argumentsList.Any(a => a == _subtractNameValue)); }

        public double GetTotal()
        {
            return Math.Round(NumbersToAdd.Sum(n => n) - NumbersToSubtract.Sum(n => n), 4);
        }
    }
}
