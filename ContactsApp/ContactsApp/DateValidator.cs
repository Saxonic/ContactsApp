﻿using System;

namespace ContactsApp
{
    public static class DateValidator
    {
        public static void AssertDate(DateTime checkDate)
        {
            if (DateTime.Today < checkDate)
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
