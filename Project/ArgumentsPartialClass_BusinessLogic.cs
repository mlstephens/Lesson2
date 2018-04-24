using System;
using System.Linq;

namespace Lesson2
{
    public partial class ArgumentsPartialClass
    {
        private const char _valueSeperator = ',';

        private double[] GetNumbers(string argumentType)
        {
            double[] argumentArray = Array.Empty<double>();

            //if we have arguments then build an array of just the numeric values for specified argument type
            if (Arguments.Any(a => a.Contains(argumentType)))
            {
                argumentArray = Arguments.First(a => a.Contains(argumentType))
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
            return Math.Round(NumbersToAdd.Sum(n => n) - NumbersToSubtract.Sum(n => n), 4);
        }
    }
}
