using System;
using System.Globalization;


namespace ContactsApp
{
    /// <summary>
    /// Класс <see cref="Contact"/> содержит информацию о контакте
    /// </summary>
    public class Contact : ICloneable, IEquatable<Contact>
    {
        /// <summary>
        /// Содержит имя
        /// </summary>
        private string _name;

        /// <summary>
        /// Содержит фамилию
        /// </summary>
        private string _surname;

        /// <summary>
        /// Содержит email
        /// </summary>
        private string _email;

        /// <summary>
        /// Содержит vkID
        /// </summary>
        private string _vkID;

        /// <summary>
        /// Содержит дату рождения
        /// </summary>
        private DateTime _birthday;

        /// <summary>
        /// Содержит максимальную длинну имени, фамилии и email
        /// </summary>
        public const int MAXLETTERLENGTH = 50;

        /// <summary>
        /// Содержит максимальную длину vkID
        /// </summary>
        public const int MAXVKLETTERLENGTH = 15;

        /// <summary>
        /// Возвращает и задает имя <see cref="Name"/>
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                StringValidator.AssertStringLength(nameof(Name),value,
                    MAXLETTERLENGTH);
                _name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
            }
        }

        /// <summary>
        /// Возвращает и задает фамилию <see cref="Surname"/>
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {
                StringValidator.AssertStringLength(nameof(Surname),value,
                    MAXLETTERLENGTH);
                _surname = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
            }
        }

        /// <summary>
        /// Возвращает и задает email <see cref="Email"/>
        /// </summary>
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                StringValidator.AssertStringLength(nameof(Email),value,
                    MAXLETTERLENGTH);
                _email = value;
            }
        }

        ///<summary>
        ///Возвращает и задает ID вконтакте <see cref="VkID"/>
        /// </summary>
        public string VkID
        {
            get
            {
                return _vkID;
            }
            set
            {
               StringValidator.AssertStringLength(nameof(VkID),value,
                   MAXVKLETTERLENGTH);
               _vkID = value;
            }
        }

        /// <summary>
        /// Возвращает и задает дату рождения <see cref="Birthday"/>
        /// </summary>
        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                DateValidator.AssertDate(value);
                _birthday = value;
            }
        }

        /// <summary>
        /// Возвращает и задает телефонный номер <see cref="PhoneNumber"/>
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; }

        /// <summary>
        /// Конструктор объекта <see cref="Contact"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="email"></param>
        /// <param name="vkId"></param>
        /// <param name="birthday"></param>
        /// <param name="number"></param>
        public Contact(string name, string surname, string email, string vkId,
            DateTime birthday, PhoneNumber number)
        {
            Name = name;
            Surname = surname;
            Email = email;
            VkID = vkId;
            Birthday = birthday;
            PhoneNumber = number;
        }
        /// <summary>
        /// конструктор объекта <see cref="Contact"/> по умолчанию
        /// </summary>
        public Contact()
        {
            Name = "default";
            Surname = "default";
            Email = "default";
            VkID = "default";
            Birthday = DateTime.Now;
            PhoneNumber = new PhoneNumber(79999999999);
        }

        /// <summary>
        /// Создает клон объекта <see cref="Contact"/>
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return new Contact(Name, Surname, Email, VkID, 
                Birthday, new PhoneNumber(PhoneNumber.Number));
        }

        public bool Equals(Contact other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return _name == other._name 
                   && _surname == other._surname
                   && _email == other._email 
                   && _vkID == other._vkID 
                   && _birthday.Equals(other._birthday) 
                   && Equals(PhoneNumber, other.PhoneNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Contact) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (_name != null ? _name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_surname != null ? _surname.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_email != null ? _email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (_vkID != null ? _vkID.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ _birthday.GetHashCode();
                hashCode = (hashCode * 397) ^ (PhoneNumber != null ? PhoneNumber.GetHashCode() : 0);
                return hashCode;
            }
        }
    }
}

