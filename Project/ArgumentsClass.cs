using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson2
{
    public class ArgumentsClass
    {
        private const char _nameSeperator = '=';
        private const char _valueSeperator = ',';
        private const string _addArgumentName = "added=";
        private const string _subtractArgumentName = "subtracted=";

        private List<string> _arguments = new List<string>();

        public ArgumentsClass(string[] arguments)
        {
            _arguments = arguments.ToList();
        }

        private List<double> NumbersToAdd { get => GetNumbers(_addArgumentName); }

        private List<double> NumbersToSubtract { get => GetNumbers(_subtractArgumentName); }

        public bool IsCommandLineValid { get => _arguments.Any() && !_arguments.Any(a => a.Split(_nameSeperator).Length != 2); }

        private List<double> GetNumbers(string argumentType)
        {
            List<double> argumentList = new List<double>();

            if (_arguments.Any(a => a.Contains(argumentType)))
            {
                var arguments = _arguments.Find(a => a.Contains(argumentType)).Substring(argumentType.Length).Split(_valueSeperator).ToList();
                argumentList = arguments.Where(a => Double.TryParse(a, out double value)).Select(double.Parse).ToList();
            }            

            return argumentList;
        }

        public double GetTotal()
        {
            return (NumbersToAdd.Sum(n => n) - NumbersToSubtract.Sum(n => n));
        }
    }
}
