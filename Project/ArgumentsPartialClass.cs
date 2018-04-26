using System.Linq;

namespace Lesson2
{
    public partial class ArgumentsPartialClass
    {
        private const char _nameSeperator = '=';        
        private const string _addNameValue = "-added";
        private const string _subtractNameValue = "-subtracted";

        public ArgumentsPartialClass(string[] arguments)
        {
            Arguments = arguments;
        }

        private string[] Arguments { get; }

        public bool IsCommandLineValid { get => Arguments.Any() && (Arguments.Any(a => a == _addNameValue) || Arguments.Any(a => a == _subtractNameValue)); }

        private double[] NumbersToAdd { get => GetNumbers(_addNameValue); }

        private double[] NumbersToSubtract { get => GetNumbers(_subtractNameValue); }

        
    }
}
