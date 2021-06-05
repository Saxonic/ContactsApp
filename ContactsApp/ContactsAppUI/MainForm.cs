using System;
using ContactsApp;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        private Project _project;
        public MainForm()
        {
            InitializeComponent();
            
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                _project = ProjectManager.Load(ProjectManager._filePath);
            }
            catch(AccessViolationException exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK);
                _project = new Project();
            }
            UpdateListBox(_project.Contacts);
        }

        private void ClearTextBox()
        {
            SurnameTextBox.Clear();
            NameTextBox.Clear();
            BirthdayDateTimePicker.Value = BirthdayDateTimePicker.MinDate;
            PhoneMaskedTextBox.Clear();
            EmailTextBox.Clear();
            VkIdTextBox.Clear();
        }

        private void UpdateListBox(List<Contact> contacts)
        {
            ContactsListBox.DataSource = null;
            ContactsListBox.DataSource = contacts;
            ContactsListBox.DisplayMember = "Surname";
            ContactsListBox.ValueMember = "PhoneNumber";
        }
        private void ChangeTextBox(Contact contact)
        {
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            BirthdayDateTimePicker.Value = contact.Birthday;
            PhoneMaskedTextBox.Text = contact.PhoneNumber.Number.ToString();
            EmailTextBox.Text = contact.Email;
            VkIdTextBox.Text = contact.VkID;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            ContactForm contactForm = new ContactForm();
            DialogResult = contactForm.ShowDialog();
            var contact = contactForm.Contact;
            if (DialogResult == DialogResult.OK)
            {
                _project.Contacts.Add(contact);
                ProjectManager.Save(_project, ProjectManager._filePath);
                UpdateListBox(_project.Contacts);
                ChangeTextBox(contact);
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Nothing is cheked!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedContact = _project.Contacts[selectedIndex];
            ContactForm contactForm = new ContactForm()
            {
                Contact = selectedContact
            };
            DialogResult = contactForm.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                var editContact = contactForm.Contact;
                _project.Contacts.RemoveAt(selectedIndex);
                _project.Contacts.Insert(selectedIndex, editContact);
                ProjectManager.Save(_project, ProjectManager._filePath);
                ChangeTextBox(editContact);
                UpdateListBox(_project.Contacts);
            }

        }

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }
            ChangeTextBox(_project.Contacts[selectedIndex]);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }
            if (_project.Contacts.Count ==0)
            {
                return;
            }
            var selectedContact = _project.Contacts[selectedIndex];
            DialogResult = MessageBox.Show("Do you realy want to delete contact " +
                selectedContact.Name+"  "+selectedContact.Surname+"?",
                "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
            _project.Contacts.RemoveAt(selectedIndex);
                ProjectManager.Save(_project, ProjectManager._filePath);
                UpdateListBox(_project.Contacts);
                ContactsListBox.ClearSelected();
                ClearTextBox();
            }
            else
            {
                return;
            }

            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ProjectManager.Save(_project,ProjectManager._filePath);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void about_Click(object sender, EventArgs e)
        {
            var about = new AboutForm();
            about.ShowDialog();
        }
    }
}
