using System;
using System.Linq;

namespace Lesson2
{
    public partial class Arguments
    {
        private const char _valueSeperator = ',';

        private double[] GetNumbers(string argumentNameValue)
        {
            double[] argumentKeyValues = Array.Empty<double>();

            //build array of numeric keyvalues
            argumentKeyValues = ArgumentsArray.SkipWhile(a => a != argumentNameValue)
                .Skip(1)
                .DefaultIfEmpty(string.Empty)
                .First()
                .Split(_valueSeperator)
                .Where(a => Double.TryParse(a, out double value))
                .Select(Double.Parse)
                .ToArray();

            return argumentKeyValues;
        }

        public double GetTotal()
        {
            return Math.Round(NumbersToAdd.Sum(n => n) - NumbersToSubtract.Sum(n => n), 4);
        }
    }
}
