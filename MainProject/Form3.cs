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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            if (IsLoginValid(email, password))
            {
                MessageBox.Show("Login successful!");
                Form4 form4 = new Form4();
                form4.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid email or password. Please try again.");
            }
        }

        private bool IsLoginValid(string email, string password)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Information.txt");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains($"Email: {email}"))
                    {
                        if (i + 1 < lines.Length && lines[i + 1].Contains($"Password: {password}"))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

    }
}
