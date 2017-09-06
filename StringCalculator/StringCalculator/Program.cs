using System;
using System.Collections.Generic;

namespace StringCalculator
{
    internal class Program
    {
        private static void Main()
        {
            var numbers = new List<string> {
                "1",
                "1, 2",
                "1, 2, 5",
                "1, 2, 5, 1",
                "1, 2, 5, 1, 11",
                "1\n2, 3",
                "//;\n1;2",
                "2, 1001",
                "//[***]\n1***2***3",
                "//[*][%]\n1*2%3"
            };

            var calculator = new Calculator();
            Console.WriteLine("Calculating numbers...");
            foreach (var number in numbers)
            {
                Console.WriteLine(calculator.Add(number));
            }
            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }
    }
}
