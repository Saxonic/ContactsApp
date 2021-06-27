using System;
using ContactsApp;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace ContactsAppUI
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Содержит все данные о проекте
        /// </summary>
        private Project _project;
        /// <summary>
        /// Вспомогательный список для поиска
        /// </summary>
        private List<Contact> _contacts;
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
            BirthdayInfoLabel.Text = "Today birthday have:\n";
            var birthdayContacts = _project.FindBirthdayContacts(DateTime.Now);
            if (birthdayContacts.Count != 0)
            {
                for (int i = 0; i < birthdayContacts.Count - 1; i++)
                {
                    BirthdayInfoLabel.Text += birthdayContacts[i].Surname + ", ";
                }

                BirthdayInfoLabel.Text += birthdayContacts[birthdayContacts.Count - 1].Surname;
            }
            else
            {
                Controls.Remove(birthdayTableLayoutPanel);
            }
            UpdateListBox();
            ContactsListBox.ClearSelected();
        }

        private void SearchContact()
        {
            if(SearchTextBox.Text.Length == 0)
            {
                _contacts = _project.AlphabetSort();
            }
            else if (SearchTextBox.Text.Length !=0)
            {
                _contacts = _project.AlphabetSort(SearchTextBox.Text);
            }
        }
        /// <summary>
        /// Очищает поля textBox
        /// </summary>
        private void ClearTextBox()
        {
            SurnameTextBox.Clear();
            NameTextBox.Clear();
            BirthdayDateTimePicker.Value = BirthdayDateTimePicker.MinDate;
            PhoneMaskedTextBox.Clear();
            EmailTextBox.Clear();
            VkIdTextBox.Clear();
        }
        private void UpdateListBox()
        {
            SearchContact();
            ContactsListBox.DataSource = null;
            ContactsListBox.DataSource = _contacts;
            ContactsListBox.DisplayMember = nameof(Contact.Surname);
            ContactsListBox.ValueMember = nameof(Contact.PhoneNumber);
        }
        /// <summary>
        /// Обновляет поля TextBox на новые значения
        /// </summary>
        /// <param name="contact"></param>
        private void ChangeTextBox(Contact contact)
        {
            SurnameTextBox.Text = contact.Surname;
            NameTextBox.Text = contact.Name;
            BirthdayDateTimePicker.Value = contact.Birthday;
            PhoneMaskedTextBox.Text = contact.PhoneNumber.Number.ToString();
            EmailTextBox.Text = contact.Email;
            VkIdTextBox.Text = contact.VkID;
        }

        /// <summary>
        /// Удаляет контакт, выбранный в ContactsListBox
        /// </summary>
        private void DeleteContact()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }
            if (_project.Contacts.Count == 0)
            {
                return;
            }
            var contact = _project.Contacts[selectedIndex];
            DialogResult = MessageBox.Show("Do you really want to delete contact " +
                contact.Name + "  " + contact.Surname + "?",
                "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult == DialogResult.Yes)
            {
                var selectedContact = _contacts[selectedIndex];
                _project.Contacts.Remove(selectedContact);
                ProjectManager.Save(_project, ProjectManager._filePath);
                UpdateListBox();
                ContactsListBox.ClearSelected();
                ClearTextBox();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Удаляет контакт, выбранный в ContactsListBox
        /// </summary>
        private void EditContact()
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Nothing is checked!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedContact = _contacts[selectedIndex];
            ContactForm contactForm = new ContactForm()
            {
                Contact = selectedContact
            };
            DialogResult = contactForm.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                var editContact = contactForm.Contact;
                _project.Contacts.Remove(selectedContact);
                _project.Contacts.Add(editContact);
                ProjectManager.Save(_project, ProjectManager._filePath);
                ChangeTextBox(editContact);
                UpdateListBox();
                ContactsListBox.SelectedIndex = _contacts.IndexOf(editContact);
            }
        }
        /// <summary>
        /// Добавляет новый контакт
        /// </summary>
        private void AddContact()
        {
            ContactForm contactForm = new ContactForm();
            DialogResult = contactForm.ShowDialog();
            var newContact = contactForm.Contact;
            if (DialogResult == DialogResult.OK)
            {
                _project.Contacts.Add(newContact);
                ProjectManager.Save(_project, ProjectManager._filePath);
                UpdateListBox();
                ChangeTextBox(newContact);
                ContactsListBox.SelectedIndex = _contacts.IndexOf(newContact);
            }
        }
        /// <summary>
        /// Обновляет поле ListBox на новые значения
        /// </summary>
        /// <param name="contacts"></param>

        private void ContactsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndex = ContactsListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                return;
            }
            ChangeTextBox(_contacts[selectedIndex]);
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F1))
            {
                var about = new AboutForm();
                about.ShowDialog();
                return true;
            }
            if (keyData == (Keys.Delete))
            {
                DeleteContact();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }

        private void removeContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteContact();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void editContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditContact();
        }

        private void addContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddContact();
        }

        private void FIndTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
