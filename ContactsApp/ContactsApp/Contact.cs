using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    /// <summary>
    /// Класс <see cref="Contact"/> содержит информацию о контакте
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Содержит имя
        /// </summary>
        private string _name;

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
                if (value.Length > 50)
                {
                    throw new ArgumentException("Длина имени не может превышать 50 символов");
                }
                if (value.Length == 0)
                {
                    throw new ArgumentException("Поле имени не может быть пустым");
                }
                TextInfo text = CultureInfo.CurrentCulture.TextInfo;
                _name = text.ToTitleCase(value);
            }
        }

        /// <summary>
        /// Содержит фамилию
        /// </summary>
        private string _lastName;

        /// <summary>
        /// Возвращает и задает фамилию <see cref="LastName"/>
        /// </summary>
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException("Длина имени не может превышать 50 символов");
                }
                if (value.Length == 0)
                {
                    throw new ArgumentException("Поле имени не может быть пустым");
                }

                TextInfo text = CultureInfo.CurrentCulture.TextInfo;
                _lastName = text.ToTitleCase(value);
            }
        }

        /// <summary>
        /// Содержит email
        /// </summary>
        private string _email;

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
                if (value.Length > 50)
                {
                    throw new ArgumentException("Длинна email не может " +
                                                "превышать 50 симоволов");
                }
                _email = value;
            }
        }

        /// <summary>
        /// Содержит vkID
        /// </summary>
        private string _vkID;

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
                if (value.Length > 15)
                {
                    throw new ArgumentException("Длинна vkID не может превышать 15 символов");
                }
            }
        }

        /// <summary>
        /// Содержит дату рождения
        /// </summary>
        private DateTime _birthday;

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
                if (DateTime.Today > _birthday)
                {
                    throw new ArgumentException("Дата рождения не может быть позже текущей даты");
                }
                if (_birthday.Year < 1900)
                {
                    throw new ArgumentException("Дата рождения не может быть раньше 1900 года");
                }
            }
        }


    }
}

