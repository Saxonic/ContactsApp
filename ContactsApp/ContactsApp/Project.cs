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
        public List<Contact> AlphabetSort()
        {
            return Contacts.OrderBy(contact => contact.Surname).ToList();
        }

        public List<Contact> AlphabetSort(string substring)
        {
            var sorted = AlphabetSort();
            return sorted.Where(contact => contact.Surname.Contains(substring) 
            || contact.Name.Contains(substring)).ToList();
        }
        public List<Contact> FindBirthdayContacts(DateTime date)
        {
            return Contacts.Where(contact => contact.Birthday.Day == date.Day
            && contact.Birthday.Month == date.Month).ToList();
        }

    }
}
