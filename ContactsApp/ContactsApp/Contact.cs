using System;
using System.Globalization;


namespace ContactsApp
{
    /// <summary>
    /// Класс <see cref="Contact"/> содержит информацию о контакте
    /// </summary>
    public class Contact : ICloneable
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
        public const int MAXVKLETTERLENGHT = 15;

        /// <summary>
        /// Возвращает и задает имя <see cref="Name"/>
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                StringValidator.AssertStringLength(nameof(Name),value,MAXLETTERLENGTH);
                _name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
            }
        }

        /// <summary>
        /// Возвращает и задает фамилию <see cref="Surname"/>
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                StringValidator.AssertStringLength(nameof(Surname),value,MAXLETTERLENGTH);
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
                StringValidator.AssertStringLength(nameof(Email),value,MAXLETTERLENGTH);
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
               StringValidator.AssertStringLength(nameof(VkID),value,MAXVKLETTERLENGHT);
            }
        }

        /// <summary>
        /// Возвращает и задает дату рождения <see cref="Birthday"/>
        /// </summary>
        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                DateValidator.AssertDate(value);
                _birthday = value;
            }
        }
        /// <summary>
        /// Возвращает и задает телефонный номер
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; }

        public Contact(string name, string surname, string email, string vkId, DateTime birthday,
            PhoneNumber number)
        {
            this.Name = name;
            this.Surname = Surname;
            this.Email = email;
            this.VkID = vkId;
            this.Birthday = birthday;
            this.PhoneNumber = number;
        }
        public object Clone()
        {
            return new Contact(this.Name, this.Surname, this.Email, this.VkID, this.Birthday,
                new PhoneNumber(this.PhoneNumber.Number));
        }
    }
}

