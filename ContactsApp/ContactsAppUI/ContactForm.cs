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
        /// <summary>
        /// Поле содержащее бэкап копию контакта
        /// </summary>
        private Contact _oldContact;
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
                    _oldContact = (Contact)_contact.Clone();
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
        /// <summary>
        /// Проверка на ввод корректного значения <see cref="Contact.VkID"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VkIdTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var vkID = VkIdTextBox.Text;
                StringValidator.AssertStringLength(null, 
                    vkID, Contact.MAXVKLETTERLENGTH);
                VkIdTextBox.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                VkIdTextBox.BackColor = Color.LightSalmon;
            }
        }
        /// <summary>
        /// Проверка на ввод коректного значения <see cref="Contact.Email"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var email = EmailTextBox.Text;
                StringValidator.AssertStringLength(null,
                    email, Contact.MAXLETTERLENGTH);
                EmailTextBox.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                EmailTextBox.BackColor = Color.LightSalmon;
            }
        }
        /// <summary>
        /// Проверка на вводе корректного значения <see cref="Contact.PhoneNumber"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhoneTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var phoneNumber = PhoneTextBox.Text;
                StringValidator.AssertNumber(Convert.
                    ToInt64(StringValidator.GetClearNumber(phoneNumber)),
                    PhoneNumber.NUMBERLENGHT);
                PhoneTextBox.BackColor = Color.White;
            }
            catch
            {
                PhoneTextBox.BackColor = Color.LightSalmon;
            }
        }
        /// <summary>
        /// Проверка на ввод корректного значения <see cref="Contact.Name"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var name = NameTextBox.Text;
                StringValidator.AssertStringLength(null,
                    name, Contact.MAXLETTERLENGTH);
                NameTextBox.BackColor = Color.White;
            }
            catch (ArgumentException)
            {
                NameTextBox.BackColor = Color.LightSalmon;
            }
        }
        /// <summary>
        /// Проверка на ввод корректного значения <see cref="Contact.Surname"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurnameTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var surname = SurnameTextBox.Text;
                StringValidator.AssertStringLength(null,
                    surname, Contact.MAXLETTERLENGTH);
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
                    Convert.ToInt64(StringValidator.GetClearNumber(PhoneTextBox.Text)));
                _contact = new Contact(NameTextBox.Text,
                    SurnameTextBox.Text, EmailTextBox.Text,
                    VkIdTextBox.Text, BirthdayDateTimePicker.Value,number);
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Wrong value!",
                    "Error", MessageBoxButtons.OK);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Contact = _oldContact;
            DialogResult = DialogResult.Cancel;
        }
    }
}
