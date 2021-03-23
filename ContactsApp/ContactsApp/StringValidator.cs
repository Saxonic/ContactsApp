using System;

namespace ContactsApp
{
    public static class StringValidator
    {
        /// <summary>
        /// Проверка на соответсвие указанной длинне <see cref="maxLength"/>>
        /// </summary>
        /// <param name="stringName"></param>
        /// <param name="checkString"></param>
        /// <param name="maxLength"></param>
        public static void AssertStringLength(string stringName, string checkString, int maxLength)
        {
            if (checkString.Length > maxLength || checkString.Length == 0)
            {
                throw new ArgumentException("incorrect value in: " + stringName);
            }
        }

        public static void AssertNumber(long number, int requiredLength)
        {
            if (number.ToString().Length != requiredLength)
            {
                throw new ArgumentException("Invalid number length");
            }

            if (number.ToString().ToCharArray()[0] != 7)
            {
                throw new ArgumentException("number must start from 7");
            }
        }
    }
}
