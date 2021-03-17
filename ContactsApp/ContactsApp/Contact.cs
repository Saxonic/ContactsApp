using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    public class Contact
    {
        /// <summary>
        /// Возвращает и задает имя
        /// </summary>
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name.Length > 50)
                {
                    throw new ArgumentException("Длина имени не может превышать 50 символов");
                }
                if (_name.Length == 0)
                {
                    throw new ArgumentException("Поле имени не может быть пустым");
                }
                _name = value;
            }
        }

        /// <summary>
        /// Возвращает и задает фамилию
        /// </summary>
        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (_lastName.Length > 50)
                {
                    throw new ArgumentException("Длина имени не может превышать 50 символов");
                }
                if (_lastName.Length == 0)
                {
                    throw new ArgumentException("Поле имени не может быть пустым");
                }
                _lastName = value;
            }
        }
        /// <summary>
        /// Возвращает и задает дату рождения
        /// </summary>
        private DateTime _birthday;
        public DateTime Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                if (_birthday.Year < 1900)
                {
                    throw new ArgumentException("Дата рождения не может быть раньше 1900 года");
                }
            }
        }


    }
}

