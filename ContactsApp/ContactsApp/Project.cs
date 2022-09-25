using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsApp
{
    /// <summary>
    /// Класс <see cref="Project"/> содержит данные о проекте 
    /// </summary>
    public class Project
    {
        /// <summary>
        /// Содержит информацию о всех <see cref="Contacts"/>
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();

        /// <summary>
        /// Сортирует список контактов по фамилиям в алфавитном порядке
        /// </summary>
        /// <returns>
        /// Сортированный список
        /// </returns>
        public List<Contact> OrderBySurname()
        {
            return Contacts.OrderBy(contact => contact.Surname).ToList();
        }

        /// <summary>
        /// Выдает список контактов, в которых содержится передаваемся строка
        /// </summary>
        /// <param name="substring"></param>
        /// <returns></returns>
        public List<Contact> FindByNameAndSurname(string substring)
        {
            var sorted = OrderBySurname();
            return sorted.Where(contact => contact.Surname.Contains(substring) 
            || contact.Name.Contains(substring)).ToList();
        }

        /// <summary>
        /// Выполняет поиск именинников на указанную дату
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<Contact> FindBirthdayContacts(DateTime date)
        {
            return Contacts.Where(contact => contact.Birthday.Day == date.Day
            && contact.Birthday.Month == date.Month).ToList();
        }
    }
}
