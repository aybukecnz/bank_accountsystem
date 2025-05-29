using System;
using System.IO;
using System.Windows.Forms;
using BankApp; // BankAccount sınıfını kullanabilmek için

namespace bankapptxt
{
    public partial class Form1 : Form
    {
        // Kullanıcı verilerini saklamak için dosya yolu
        string filePath = "users.txt";

        public Form1()
        {
            InitializeComponent();
            btnRegister.Click += BtnRegister_Click;
            btnLogin.Click += BtnLogin_Click;
        }

        // Kayıt butonuna tıklandığında çalışır
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Yeni kullanıcı 
            File.AppendAllText(filePath, $"{username}:{password}:0{Environment.NewLine}");
            MessageBox.Show("Registration Successful!");
        }

        // Giriş butonuna tıklandığında çalışır
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 3 && parts[0] == username && parts[1] == password)
                    {
                        decimal balance = decimal.Parse(parts[2]);

                        // BankAccount nesnesi 
                        BankAccount account = new BankAccount(username, password, balance);

                        // Dashboard'a gönder
                        MessageBox.Show("Login Succesfull!");
                        DashboardForm dashboard = new DashboardForm(account);
                        dashboard.Show();
                        this.Hide();
                        return;
                    }
                }
            }

            MessageBox.Show("Login failed. Please check your information.");
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void Username_Click(object sender, EventArgs e)
        {

        }
    }
}
