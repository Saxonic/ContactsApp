using System;
using ContactsApp;
using System.Windows.Forms;

namespace ContactsAppUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var project = new Project();
            var contact = new Contact(
                "email.com",
                "sava", 
                "savavich",
                "123", 
                new DateTime(1999, 11, 21),
                new PhoneNumber(79996482693));

            project.Contacts.Add(contact);

            contact = new Contact(
                "emil.com",
                "swfv",
                "savich",
                "13",
                new DateTime(1919, 11, 21),
                new PhoneNumber(79966482693));
            project.Contacts.Add(contact);
            ProjectMeneger.Save(project,ProjectMeneger._filePath);
            project = ProjectMeneger.Load(ProjectMeneger._filePath);
        }
    }
}
