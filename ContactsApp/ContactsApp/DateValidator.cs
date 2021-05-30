using System;

namespace ContactsApp
{
    /// <summary>
    /// Класс <see cref="DateValidator"/> выплняет проверку всех полей с
    /// типом данных <see cref="DateTime"/>
    /// </summary>
    public static class DateValidator
    {
        public static void AssertDate(DateTime checkDate)
        {
            if (DateTime.Now < checkDate)
            {
                throw new ArgumentException("birthday is later than today");
            }
            if (checkDate.Year < 1900)
            {
                throw new ArgumentException("birthday is earlier than 1900");
            }
        }
    }
}
