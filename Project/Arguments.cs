using System.Linq;

namespace Lesson2
{
    public partial class Arguments
    {
        private const char _nameSeperator = '=';        
        private const string _addNameValue = "-added";
        private const string _subtractNameValue = "-subtracted";

        public Arguments(string[] arguments)
        {
            ArgumentsArray = arguments;
        }

        private string[] ArgumentsArray { get; }

        public bool IsCommandLineValid { get => ArgumentsArray.Any() && (ArgumentsArray.Any(a => a == _addNameValue) || ArgumentsArray.Any(a => a == _subtractNameValue)); }

        private double[] NumbersToAdd { get => GetNumbers(_addNameValue); }

        private double[] NumbersToSubtract { get => GetNumbers(_subtractNameValue); }

        
    }
}
