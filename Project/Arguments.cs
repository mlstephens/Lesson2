using System;
using System.Linq;

namespace Lesson2
{
    public partial class Arguments
    {
        private const string _addNameValue = "-added";
        private const string _subtractNameValue = "-subtracted";

        public Arguments(string[] arguments)
        {
            ArgumentsArray = arguments;
        }

        private string[] ArgumentsArray { get; }

        public bool IsCommandLineValid { get => ArgumentsArray.Any(a => String.Compare(a, _addNameValue, true) == 0) || ArgumentsArray.Any(a => String.Compare(a, _subtractNameValue, true) == 0); }

        private double[] NumbersToAdd { get => GetNumbers(_addNameValue); }

        private double[] NumbersToSubtract { get => GetNumbers(_subtractNameValue); }
        
    }
}
