using System.Linq;

namespace Lesson2
{
    public partial class ArgumentsPartialClass
    {
        private const string _addArgumentName = "added=";
        private const string _subtractArgumentName = "subtracted=";
        private const char _nameSeperator = '=';

        public ArgumentsPartialClass(string[] arguments)
        {
            Arguments = arguments;
        }

        private string[] Arguments { get; }

        private double[] NumbersToAdd { get => GetNumbers(_addArgumentName); }

        private double[] NumbersToSubtract { get => GetNumbers(_subtractArgumentName); }        

        public bool IsCommandLineValid { get => Arguments.Any() && !Arguments.Any(a => a.Split(_nameSeperator).Length != 2); }
    }
}
