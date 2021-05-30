using ContactsApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsAppUI
{
    public partial class ContactForm : Form
    {
        /// <summary>
        /// Поле содержащее информацию о контакте
        /// </summary>
        private Contact _contact;
        public ContactForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Возвращает и задает данные контакта
        /// </summary>
        public Contact Contact
        {
            get { return _contact; }
            set
            {
                _contact = value;
                if(_contact !=null)
                {
                    NameTextBox.Text = _contact.Name;
                    SurnameTextBox.Text = _contact.Surname;
                    BirthdayDateTimePicker.Value = _contact.Birthday;
                    PhoneTextBox.Text = _contact.PhoneNumber
                        .Number.ToString();
                    EmailTextBox.Text = _contact.Email;
                    VkIdTextBox.Text = _contact.VkID;
                }
            }
        }
        /// <summary>
        /// Проверка на вход корректных значений <see cref="Contact.Birthday"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BirthdayDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var checkDate = BirthdayDateTimePicker.Value;
                DateValidator.AssertDate(checkDate);
                BirthdayDateTimePicker.CalendarTitleBackColor
                    = Color.White;
            }
            catch (ArgumentException)
            {
                BirthdayDateTimePicker.CalendarTitleBackColor
                    = Color.LightSalmon;
            }
        }

        private void VkIdTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var vkID = VkIdTextBox.Text;
                StringValidator.AssertStringLength(null, 
                    vkID, Contact.MAXVKLETTERLENGHT);
                VkIdTextBox.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                VkIdTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var email = EmailTextBox.Text;
                StringValidator.AssertStringLength(null,
                    email, Contact.MAXVKLETTERLENGHT);
                EmailTextBox.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                EmailTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var phoneNumber = PhoneTextBox.Text;
                StringValidator.AssertNumber(Convert.ToInt64(phoneNumber),
                    PhoneNumber.NUMBERLENGHT);
                PhoneTextBox.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                PhoneTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var name = NameTextBox.Text;
                StringValidator.AssertStringLength(null,
                    name, Contact.MAXVKLETTERLENGHT);
                NameTextBox.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                NameTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var surname = SurnameTextBox.Text;
                StringValidator.AssertStringLength(null,
                    surname, Contact.MAXVKLETTERLENGHT);
                SurnameTextBox.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                SurnameTextBox.BackColor = Color.LightSalmon;
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                PhoneNumber number = new PhoneNumber(
                    Convert.ToInt64(PhoneTextBox.Text));
                _contact = new Contact(NameTextBox.Text,
                    SurnameTextBox.Text, EmailTextBox.Text,
                    VkIdTextBox.Text, BirthdayDateTimePicker.Value,number);
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Указаны недопустимые значения",
                    "Ошибка", MessageBoxButtons.OK);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
