using ContactsApp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ContactsAppUI
{
    public partial class ContactForm : Form
    {
        /// <summary>
        /// Поле содержащее информацию о контакте
        /// </summary>
        private Contact _contact = new Contact();

        /// <summary>
        /// Поле содержащее бэкап копию контакта
        /// </summary>
        private Contact _contactClone = new Contact();

        private readonly Color _rightValueColor = Color.White;
        private readonly Color _wrongValueColor = Color.LightSalmon;

        public ContactForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Возвращает и задает данные контакта
        /// </summary>
        public Contact Contact
        {
            get => _contact;
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
                    _contactClone = (Contact)_contact.Clone();
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
                _contactClone.Birthday = checkDate;
                BirthdayDateTimePicker.CalendarTitleBackColor
                    = _rightValueColor;
            }
            catch (ArgumentException)
            {
                BirthdayDateTimePicker.CalendarTitleBackColor
                    = _wrongValueColor;
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
                _contactClone.VkID = vkID;
                VkIdTextBox.BackColor = _rightValueColor;
            }
            catch (ArgumentException)
            {
                VkIdTextBox.BackColor = _wrongValueColor;
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
                _contactClone.Email = email;
                EmailTextBox.BackColor = _rightValueColor;
            }
            catch (ArgumentException)
            {
                EmailTextBox.BackColor = _wrongValueColor;
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
                _contactClone.PhoneNumber = new PhoneNumber
                    (long.Parse(StringValidator.GetClearNumber(phoneNumber)));
                PhoneTextBox.BackColor = _rightValueColor;
            }
            catch
            {
                PhoneTextBox.BackColor = _wrongValueColor;
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
                _contactClone.Name = name;
                NameTextBox.BackColor = _rightValueColor;
            }
            catch (ArgumentException)
            {
                NameTextBox.BackColor = _wrongValueColor;
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
                _contactClone.Surname = surname;
                SurnameTextBox.BackColor = _rightValueColor;
            }
            catch (ArgumentException)
            {
                SurnameTextBox.BackColor = _wrongValueColor;
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                PhoneNumber number = new PhoneNumber
                    (long.Parse(StringValidator.GetClearNumber(PhoneTextBox.Text)));
                _contact = new Contact(NameTextBox.Text, SurnameTextBox.Text, EmailTextBox.Text,
                    VkIdTextBox.Text, BirthdayDateTimePicker.Value,number);
            }
            catch(ArgumentException exception)
            {
                MessageBox.Show(exception.Message,
                    "Error", MessageBoxButtons.OK);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            _contact = _contactClone;
            DialogResult = DialogResult.Cancel;
        }
    }
}
