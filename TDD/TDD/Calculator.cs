using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            if (numbers is null)
            {
                throw new ArgumentNullException("Parameter is null");
            }

            if (numbers.Equals(string.Empty))
            {
                return 0;
            }

            int result = 0;
            int currrentNumber = 0;
            string defaultDelimiter = ",";
            StringBuilder builder = new StringBuilder("negatives not allowed - ");
            CheckDelimiter(ref numbers, ref defaultDelimiter);

            string[] array = numbers.Split(new string[] { defaultDelimiter, "\n" }, StringSplitOptions.None);
            foreach (string number in array)
            {
                if (number.Length > 4)
                {
                    Console.WriteLine(number[0]);
                    if (number[0] == '-')
                    {
                        builder.Append(number);
                    }

                    continue;
                }

                currrentNumber = Int32.Parse(number);
                if (currrentNumber < 0)
                {
                    builder.Append(number);
                }
                else
                {
                    if (currrentNumber <= 1000)
                    {
                        result += currrentNumber;
                    }
                }
            }

            if (builder.Length != 24)
            {
                throw new ArgumentException(builder.ToString());
            }

            return result; 
        }

        public static void CheckDelimiter(ref string numbers, ref string oldDelimiter)
        {
            if (numbers.Length < 2 || numbers[0] != '/')
            {
                return;
            }

            int lastBracketPlace = numbers.IndexOf(']');
            int delimiterLength = 1;
            if (numbers[2] != '[' || (lastBracketPlace == -1 && numbers[2] == '['))
            {
                oldDelimiter = numbers[2].ToString();
            }
            else
            {
                delimiterLength = lastBracketPlace - 1;
                oldDelimiter = numbers.Substring(3, lastBracketPlace - 3);
            }

            numbers = numbers.Substring(delimiterLength + 3);
        }
    }
}
