
using System;

namespace ContactsApp
{
    /// <summary>
    /// Класс <see cref="PhoneNumber"> содержит телефонный номер контакта
    /// </summary>
    public class PhoneNumber : IEquatable<PhoneNumber>
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
            get => _number;
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

        public bool Equals(PhoneNumber other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _number == other._number;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((PhoneNumber) obj);
        }

        public override int GetHashCode()
        {
            return _number.GetHashCode();
        }
    }
}
