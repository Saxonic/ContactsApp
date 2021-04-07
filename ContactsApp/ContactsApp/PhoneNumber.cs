﻿
namespace ContactsApp
{
    /// <summary>
    /// Класс <see cref="PhoneNumber"> содержит телефонный номер контакта
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Содержит номер телефона
        /// </summary>
        private long _number;

        /// <summary>
        /// Содержит необходимую длину номера телефона
        /// </summary>
        public const int NUMBERLENGHT = 11;

        /// <summary>
        /// Возвращает и задает номер телефона
        /// </summary>
        public long Number
        {
            get
            {
                return _number;
            }
            set
            {
                StringValidator.AssertNumber(value,NUMBERLENGHT);
                _number = value;
            }
        }

        /// <summary>
        /// <see cref="PhoneNumber"/> конструктор
        /// </summary>
        /// <param name="number"></param>
        public PhoneNumber(long number)
        {
            this.Number = number;
        }
    }
}
