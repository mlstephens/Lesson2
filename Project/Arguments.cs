using System;
using System.Linq;

namespace Lesson2
{
    public partial class Arguments
    {
        private const string _addNameValue = "-added";
        private const string _subtractNameValue = "-subtracted";
        private string[] _arguments = null;

        public Arguments(string[] arguments)
        {
            _arguments = arguments;
        }

        public bool IsCommandLineValid { get => _arguments.Any(a => String.Compare(a, _addNameValue, true) == 0) || _arguments.Any(a => String.Compare(a, _subtractNameValue, true) == 0); }

        private double[] NumbersToAdd { get => GetNumbers(_addNameValue); }

        private double[] NumbersToSubtract { get => GetNumbers(_subtractNameValue); }
        
    }
}
