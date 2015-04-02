using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace atoiProject
{
    public static class atoiUtilities
    {
        /// <summary>
        /// Following function converts an array of charecters to an integer. 
        /// </summary>
        /// <param name="inputString">
        /// Charecter array to be converted; It support only contiguous numeric string. 
        /// </param>
        /// <returns>
        /// Converted integer; 
        /// If the converted integer is more than Int32.Max, it throws an FormatException();
        /// If the converted integer is less than Int32.Min, it throws an FormatException(); 
        /// </returns>
        /// <exception>
        /// ArgumentException
        /// FormatException
        /// </exception>
        public static int atoi(char[] inputString)
        {
            bool isNegative = false;
            long returnNumber = 0;
            int countNumericDigits = 0;

            if ((inputString == null) || (inputString.Count() == 0))
            {
                throw new ArgumentException("Input string should not be null or empty");
            }

            bool numericStringStarted = false;
            bool numericStringEnded = false;

            for (int i = 0; i < inputString.Count(); i++)
            {
                if (inputString[i] == ' ')
                {
                    // Ignore any space at the beginning and end of the numeric string
                    if (numericStringStarted == true)
                    {
                        numericStringEnded = true;
                    }
                    continue;
                }
                else if (inputString[i] == '-')
                {
                    if ((numericStringStarted == true) || (numericStringEnded == true) ||
                        (isNegative == true))
                    {
                        // '-' should be only once before starting any numeric number 
                        throw new FormatException("- sign is allowed only once before starting any numeric number");
                    }
                    else
                    {
                        isNegative = true;
                        numericStringStarted = true;
                    }
                }
                else
                {

                    if ((inputString[i] >= '0') && (inputString[i] <= '9'))
                    {
                        countNumericDigits++;
                        if (numericStringEnded == true)
                        {
                            // There is a space within the numeric string;
                            throw new FormatException("There should not be an space between two numeric numbers");
                        }
                        numericStringStarted = true;
                        int number = inputString[i] - '0';
                        returnNumber = (returnNumber * 10) + number;
                    }
                    else
                    {
                        // nonnumeric character; throw an exception 
                        throw new FormatException("Non-numeric charecter are not allowed");
                    }
                }
            }
            if (countNumericDigits == 0)
            {
                // there should be atleast one numeric number 
                throw new FormatException();
            }
            if (isNegative)
            {
                returnNumber *= (-1);
                // boundary check
                if (returnNumber < Int32.MinValue)
                {
                    throw new FormatException("Overflow error");
                }
            }
            else
            {
                // boundary check
                if (returnNumber > Int32.MaxValue)
                {
                    throw new FormatException("Overflow error");
                }
            }
            return ((int)returnNumber);
        }
    }
}
