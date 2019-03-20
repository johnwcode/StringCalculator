using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public static int Add(string numbers)
        {
            string[] delimiters = GetDelimiters(numbers);
            string[] strings = numbers.Split(delimiters, StringSplitOptions.None);
            List<int> numberList = new List<int>();
            foreach (var s in strings)
            {
                if (int.TryParse(s, out int number))
                {
                    numberList.Add(number);
                }
            }

            CheckForNegativeNumbers(numberList);
            numberList.RemoveAll(x => x > 1000);
            return numberList.Sum();
        }

        public static int Subtract(string numbers)
        {
            string[] delimiters = GetDelimiters(numbers);
            string[] strings = numbers.Split(delimiters, StringSplitOptions.None);
            List<int> numberList = new List<int>();
            foreach (var s in strings)
            {
                if (int.TryParse(s, out int number))
                {
                    numberList.Add(number);
                }
            }

            CheckForNegativeNumbers(numberList);
            numberList.RemoveAll(x => x > 1000);

            int total = numberList[0];
            for (int i = 1; i < numberList.Count; i++)
            {
                total -= numberList[i];
            }
            return total;
        }

        public static int Multiply(string numbers)
        {
            string[] delimiters = GetDelimiters(numbers);
            string[] strings = numbers.Split(delimiters, StringSplitOptions.None);
            List<int> numberList = new List<int>();
            foreach (var s in strings)
            {
                if (int.TryParse(s, out int number))
                {
                    numberList.Add(number);
                }
            }

            CheckForNegativeNumbers(numberList);
            numberList.RemoveAll(x => x > 1000);

            int total = numberList[0];
            for (int i = 1; i < numberList.Count; i++)
            {
                total *= numberList[i];
            }
            return total;
        }

        public static int Divide(string numbers)
        {
            string[] delimiters = GetDelimiters(numbers);
            string[] strings = numbers.Split(delimiters, StringSplitOptions.None);
            List<int> numberList = new List<int>();
            foreach (var s in strings)
            {
                if (int.TryParse(s, out int number))
                {
                    numberList.Add(number);
                }
            }

            CheckForNegativeNumbers(numberList);
            numberList.RemoveAll(x => x > 1000);

            int total = numberList[0];
            for (int i = 1; i < numberList.Count; i++)
            {
                total /= numberList[i];
            }
            return total;
        }

        private static void CheckForNegativeNumbers(List<int> numberList)
        {
            var negativeNumbers = numberList.Where(x => x < 0).ToList();
            if (negativeNumbers.Count > 0)
            {
                throw new NegativesNotAllowedException(negativeNumbers);
            }
        }

        private static string[] GetDelimiters(string numbers)
        {
            var delimiters = new List<string> { ",", "\n" };
            if (numbers.StartsWith("//"))
            {
                // "//[|||]\n"
                string customDelim = numbers.Split('\n').First().Substring(2);
                if (customDelim.StartsWith('['))
                {
                    delimiters.Add(customDelim.Substring(1, customDelim.Length - 2));
                }
                else
                {
                    delimiters.Add(customDelim);
                }
                
            }

            return delimiters.ToArray();
        }
    }
}
