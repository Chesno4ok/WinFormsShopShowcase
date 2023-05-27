using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopProject
{
    public partial class Registration : Form
    {
        bool IsValid;

        public Registration()
        {
            InitializeComponent();

            IsValid = false;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();

            frm.Show();
            this.Hide();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            string passwordRepeat = textBoxPasswordRepeat.Text;

            int counter = 0;

            labelLoginWarn.Text = "";
            labelPasswordWarn.Text = "";
            labelPasswordRepeatWarn.Text = "";

            DatabaseContext db = new();

            if(password != passwordRepeat)
            {
                labelPasswordRepeatWarn.Text += " Пароли не совпадают!";
            }
            else
            {
                counter++;
            }


            if (password.Length > 6
                && password.Any(s => char.IsDigit(s))
                && password.Any(s => char.IsUpper(s))
                && password.Any(s => char.IsLower(s))
                && password.Any(s => char.IsPunctuation(s))
                && password.Any(s => s != '\t'))
            {
                counter++;
            }
            else
            {
                labelPasswordWarn.Text += " Неправильный формат пароля!";
            }

            var lgn = db.Users.FirstOrDefault(p => p.Login == login);

            if(lgn != null)
            {
                labelLoginWarn.Text += " Такой логин уже существует!";
            }
            else
            {
                counter++;
            }

            lgn = db.Users.FirstOrDefault(p => p.Password == password);
            
            if(lgn != null)
            {
                labelPasswordWarn.Text += $"\n Такой пароль уже существует у пользователя {lgn.Login}";
            }
            else
            {
                counter++;
            }

            if(counter == 4)
            {
                IsValid = true;
            }
            else
            {
                IsValid = false;
            }

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                DatabaseContext db = new();

                string login = textBoxLogin.Text.ToLower();
                string password = textBoxPassword.Text;

                User usr = new User() { Login = login, Password = password, Status = "User" };

                db.Users.Add(usr);
                db.SaveChanges();

                Form1 frm = new();
                frm.Show();
                this.Hide();
            }
        }
    }
}
