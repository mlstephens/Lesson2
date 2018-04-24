using System;
using System.Linq;

namespace Lesson2
{
    public partial class ArgumentsPartialClass
    {
        private const char _valueSeperator = ',';

        /// <summary>
        /// GetNumbers: creates an array of numeric argument values
        /// </summary>
        /// <param name="argumentNameValue">the argument name value</param>
        /// <returns>an array of numeric doubles</returns>
        private double[] GetNumbers(string argumentNameValue)
        {
            double[] argumentArray = Array.Empty<double>();

            //if we have arguments then build an array of just the numeric values for specified argument type
            if (Arguments.Any(a => a.Contains(argumentNameValue)))
            {
                argumentArray = Arguments.First(a => a.Contains(argumentNameValue))
                    .Substring(argumentNameValue.Length)
                    .Split(_valueSeperator)
                    .Where(a => Double.TryParse(a, out double value))
                    .Select(double.Parse)
                    .ToArray();
            }

            return argumentArray;
        }

        /// <summary>
        /// GetTotal: returns the total for the numeric argument values
        /// </summary>
        /// <returns></returns>
        public double GetTotal()
        {
            return Math.Round(NumbersToAdd.Sum(n => n) - NumbersToSubtract.Sum(n => n), 4);
        }
    }
}
