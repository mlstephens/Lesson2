using System;
using System.Linq;

namespace Lesson2
{
    public class ArgumentsClass
    {
        private const char _nameSeperator = '=';
        private const char _valueSeperator = ',';
        private const string _addArgumentName = "added=";
        private const string _subtractArgumentName = "subtracted=";

        private string[] _arguments = Array.Empty<string>();

        public ArgumentsClass(string[] arguments)
        {
            _arguments = arguments;
        }

        private double[] NumbersToAdd { get => GetNumbers(_addArgumentName); }

        private double[] NumbersToSubtract { get => GetNumbers(_subtractArgumentName); }

        public bool IsCommandLineValid { get => _arguments.Any() && !_arguments.Any(a => a.Split(_nameSeperator).Length != 2); }

        private double[] GetNumbers(string argumentType)
        {
            double[] argumentArray = Array.Empty<double>();

            //if we have arguments then build an array of just the numeric values for specified argument type
            if (_arguments.Any(a => a.Contains(argumentType)))
            {
                argumentArray = _arguments.ToList()
                    .Find(a => a.Contains(argumentType))
                    .Substring(argumentType.Length)
                    .Split(_valueSeperator)
                    .Where(a => Double.TryParse(a, out double value))
                    .Select(double.Parse)
                    .ToArray();
            }

            return argumentArray;
        }

        public double GetTotal()
        {
            return (NumbersToAdd.Sum(n => n) - NumbersToSubtract.Sum(n => n));
        }
    }
}
