using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson2
{
    public partial class ArgumentsPartialClass
    {
        private const char _valueSeperator = ',';

        /// <summary>
        /// GetNumbers: creates an list of numeric argument key values
        /// </summary>
        /// <param name="argumentNameValue">the argument name value</param>
        /// <returns>an list of numeric doubles</returns>
        private List<double> GetNumbers(string argumentNameValue)
        {
            List<double> argumentKeyValues = new List<double>();

            //find that namevalue
            argumentKeyValues = ArgumentsList.SkipWhile(a => a != argumentNameValue)
                .Skip(1)
                .DefaultIfEmpty(string.Empty).First()
                .Split(_valueSeperator)
                .Where(a => Double.TryParse(a, out double value))
                .Select(Double.Parse)
                .ToList();

            return argumentKeyValues;
        }

        /// <summary>
        /// GetTotal: returns the total for the numeric argument key values
        /// </summary>
        /// <returns>double numeric total</returns>
        public double GetTotal()
        {
            return Math.Round(NumbersToAdd.Sum(n => n) - NumbersToSubtract.Sum(n => n), 4);
        }
    }
}
