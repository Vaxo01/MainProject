using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;
            string reEnterPassword = ReEnterPasswordTextBox.Text;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(reEnterPassword))
            {
                MessageBox.Show("Please fill out all inputs!");
                return;
            }

            bool isFirstNameValid = !firstName.Any(char.IsDigit);
            bool isLastNameValid = !lastName.Any(char.IsDigit);

            bool isEmailValid = email.Contains("@") && email.Length >= 11 && !email.All(c => c == '@');

            bool isPasswordValid = password.Any(char.IsUpper) && password.Length >= 10;

            bool isReEnterPasswordValid = password == reEnterPassword;

            if (IsEmailInUse(email))
            {
                MessageBox.Show("This email is already in use. Please use a different one.");
                return;
            }

            if (isFirstNameValid && isLastNameValid && isEmailValid && isPasswordValid && isReEnterPasswordValid)
            {
                MessageBox.Show("All validations passed. Registering user!");
            }
            else
            {
                MessageBox.Show("Some validations failed. Please check your inputs.");
            }

            if (isFirstNameValid && isLastNameValid && isEmailValid && isPasswordValid && isReEnterPasswordValid)
            {
                string accountInfo = $"Email: {email}, Password: {password}{Environment.NewLine}";
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Information.txt");

                try
                {
                    File.AppendAllText(filePath, accountInfo);

                    MessageBox.Show("Account registered and information saved!");
                    Form4 form4 = new Form4();
                    form4.Show();
                    this.Hide();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving information: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Some validations failed. Please check your inputs.");
            }
        }

        private bool IsEmailInUse(string email)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Information.txt");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    if (line.Contains($"Email: {email}"))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
