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

        /// <summary>
        /// GetNumbers: creates an array of numeric argument values
        /// </summary>
        /// <param name="argumentNameValue">the argument name value</param>
        /// <returns>an array of numeric doubles</returns>
        private double[] GetNumbers(string argumentNameValue)
        {
            double[] argumentArray = Array.Empty<double>();

            //if we have arguments then build an array of just the numeric values for specified argument type
            if (_arguments.Any(a => a.Contains(argumentNameValue)))
            {
                argumentArray = _arguments.First(a => a.Contains(argumentNameValue))
                    .Substring(argumentNameValue.Length)
                    .Split(_valueSeperator)
                    .Where(a => Double.TryParse(a, out double value))
                    .Select(double.Parse)
                    .ToArray();
            }

            return argumentArray;
        }

        public bool IsCommandLineValid { get => _arguments.Any() && !_arguments.Any(a => a.Split(_nameSeperator).Length != 2); }

        /// <summary>
        /// GetTotal: returns the total for the numeric argument values
        /// </summary>
        /// <returns>double numeric total</returns>
        public double GetTotal()
        {
            return Math.Round(NumbersToAdd.Sum(n => n) - NumbersToSubtract.Sum(n => n), 4);
        }
    }
}
