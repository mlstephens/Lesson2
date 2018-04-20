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
        private const char _seperator = '=';
        private List<string> _arguments = new List<string>();

        public ArgumentsClass(string[] arguments)
        {
            _arguments = arguments.ToList();
        }

        private List<double> NumbersToAdd { get => GetNumbers("added="); }
        private List<double> NumbersToSubtract { get => GetNumbers("subtracted="); }

        public bool IsCommandLineValid { get => _arguments.Any() && !_arguments.Any(a => a.Split(_seperator).Length != 2); }

        private List<double> GetNumbers( string type)
        {
            List<double> argumentList = new List<double>();

            if (_arguments.Any(a => a.Contains(type)))
            {
                var arguments = _arguments.Find(a => a.Contains(type)).Substring(type.Length).Split(',').ToList();
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
