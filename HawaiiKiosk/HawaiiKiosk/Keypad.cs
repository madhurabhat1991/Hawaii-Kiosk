using System;
using System.Collections.Generic;
using System.Text;

namespace HawaiiKiosk
{
    public class Keypad
    {
        public long ReadValue()
        {
            string str = Console.ReadLine();
            long value;

            if (!long.TryParse(str, out value))
            {
                throw new ArgumentException($"The value {str} is not a valid number.");
            }

            if (value < 0)
            {
                throw new ArgumentException($"The value {value} cannot be negative.");
            }

            return value;
        }

        public long ReadValue(int numberOfDigits)
        {
            long value = ReadValue();

            if (value.ToString().Length != numberOfDigits)
            {
                throw new ArgumentException($"The value {value} should be of length {numberOfDigits}.");
            }
            return value;
        }
    }
}
