using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class Calculator
    {
        private readonly char[] _defaultDelimiters;

        public Calculator()
        {
            _defaultDelimiters = new[] { ',', '\n' };
        }

        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            // check if there is a custom delimiter present
            var hasCustomDelimeter = numbers.StartsWith("//");

            // determine which delimiters to use and the numbers we require to split by those delimiters
            var numbersToAdd = hasCustomDelimeter ? numbers.Split('\n')[1] : numbers;

            // split the number string by the determined delimiters
            var numbersSplitByDelimiter = hasCustomDelimeter
                ? numbersToAdd.Split(GetCustomDelimeters(numbers.Split('\n')[0]), StringSplitOptions.RemoveEmptyEntries).Select(ToNumber).ToList()
                : numbersToAdd.Split(_defaultDelimiters).Select(ToNumber).ToList();

            // throw exception if negative numbers have been supplied
            if (numbersSplitByDelimiter.Any(number => number.IsNegative))
            {
                throw new Exception($"Negatives not allowed: { string.Join(",", numbersSplitByDelimiter.Where(number => number.IsNegative).Select(number => number.NumberString)) }");
            }

            // sum each parsed string number, less than or equal to 1000
            return numbersSplitByDelimiter.Where(number => number.IsLessThanOrEqualToOneThousand).Sum(number => number.ParsedNumber);
        }

        public Number ToNumber(string number)
        {
            return new Number
            {
                NumberString = number
            };
        }

        private static char[] GetCustomDelimeters(string delimiters)
        {
            return Regex.Replace(delimiters.Split('\n')[0], @"[/\[\]]", string.Empty).ToArray();
        }
    }
}
