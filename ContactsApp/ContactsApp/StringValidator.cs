using System;

namespace ContactsApp
{
    /// <summary>
    /// Класс <see cref="StringValidator"/> выполняет проверку всех полей
    /// с типом данных <see cref="String"/>
    /// </summary>
    public static class StringValidator
    {
        /// <summary>
        /// Проверка на соответсвие указанной длине <see cref="maxLength"/>>
        /// </summary>
        /// <param name="stringName"></param>
        /// <param name="checkString"></param>
        /// <param name="maxLength"></param>
        public static void AssertStringLength(string stringName, string checkString, int maxLength)
        {
            if (checkString.Length > maxLength || checkString.Length == 0)
            {
                throw new ArgumentException(stringName + " must be no longer that "+maxLength);
            }
        }

        public static string GetClearNumber(string number)
        {
            string clearNumber = "";
            foreach (var i in number)
            {
                if (i >= '0' && i <= '9')
                {
                    clearNumber += i;
                }
            }
            return clearNumber;
        }

        /// <summary>
        /// Проверяет правильность введенного номера
        /// </summary>
        /// <param name="number"></param>
        /// <param name="requiredLength"></param>
        public static void AssertNumber(long number, int requiredLength)
        {
            if (number.ToString().Length != requiredLength)
            {
                throw new ArgumentException("Invalid number length");
            }

            if (number.ToString().ToCharArray()[0] != '7')
            {
                throw new ArgumentException("number must start from 7");
            }
        }
    }
}
