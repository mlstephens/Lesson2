using System.Collections.Generic;
using System.Linq;

namespace Lesson2
{
    public partial class ArgumentsPartialClass
    {
        private const char _nameSeperator = '=';        
        private const string _addArgumentName = "-added";
        private const string _subtractArgumentName = "-subtracted";

        public ArgumentsPartialClass(string[] arguments)
        {
            ArgumentsList = arguments.ToList();
        }

        private List<string> ArgumentsList { get; }

        private List<double> NumbersToAdd { get => GetNumbers(_addArgumentName); }

        private List<double> NumbersToSubtract { get => GetNumbers(_subtractArgumentName); }

        public bool IsCommandLineValid { get => ArgumentsList.Any() && (ArgumentsList.Any(a => a == _addArgumentName) || ArgumentsList.Any(a => a == _subtractArgumentName)); }
    }
}
