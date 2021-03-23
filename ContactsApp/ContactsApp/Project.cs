using System.Collections.Generic;


namespace ContactsApp
{
    public class Project
    {
        /// <summary>
        /// Содержит информацию о всех <see cref="Contacts"/>
        /// </summary>
        public List<Contact> Contacts { get; set; } = new List<Contact>();

    }
}
