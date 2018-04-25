using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson2
{
    public class ArgumentsClass
    {
        private const char _nameSeperator = '=';
        private const char _valueSeperator = ',';
        private const string _addArgumentName = "-added";
        private const string _subtractArgumentName = "-subtracted";

        private List<string> _argumentsList = new List<string>();

        public ArgumentsClass(string[] arguments)
        {
            _argumentsList = arguments.ToList();
        }

        private List<double> NumbersToAdd { get => GetNumbers(_addArgumentName); }

        private List<double> NumbersToSubtract { get => GetNumbers(_subtractArgumentName); }

       /// <summary>
       /// GetNumbers: creates an list of numeric argument key values
       /// </summary>
       /// <param name="argumentNameValue">the argument name value</param>
       /// <returns>an list of numeric doubles</returns>
        private List<double> GetNumbers(string argumentNameValue)
        {
            List<double> argumentKeyValues = new List<double>();

            //find that namevalue
            argumentKeyValues = _argumentsList.SkipWhile(a => a != argumentNameValue)
                .Skip(1)
                .DefaultIfEmpty(string.Empty).First()
                .Split(_valueSeperator)
                .Where(a => Double.TryParse(a, out double value))
                .Select(Double.Parse)
                .ToList();

            return argumentKeyValues;
        }

        public bool IsCommandLineValid { get => _argumentsList.Any() && ( _argumentsList.Any(a => a == _addArgumentName) || _argumentsList.Any(a => a == _subtractArgumentName)); }

       /// <summary>
       /// GetTotal: returns the total for the numeric argument key values
       /// </summary>
       /// <returns>double numeric total</returns>
        public double GetTotal()
        {
            return Math.Round(NumbersToAdd.Sum(n => n) - NumbersToSubtract.Sum(n => n), 4);
        }
    }
}
