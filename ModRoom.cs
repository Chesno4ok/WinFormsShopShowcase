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
    public partial class ModRoom : Form
    {
        TextBox[] labelId;
        TextBox[] labelLogin;
        TextBox[] labelPassword;
        TextBox[] labelStatus;

        public ModRoom()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SetObjects()
        {
            tableLayoutPanel1.Controls.Clear();
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label, 0, 0);

            DatabaseContext db = new();

            User[] prd = db.Users.ToArray();

            labelId = new TextBox[prd.Length];
            labelLogin = new TextBox[prd.Length];
            labelPassword = new TextBox[prd.Length];
            labelStatus = new TextBox[prd.Length];



            for (int i = 0; i < prd.Length; i++)
            {
                labelId[i] = new System.Windows.Forms.TextBox();
                labelLogin[i] = new System.Windows.Forms.TextBox();
                labelPassword[i] = new System.Windows.Forms.TextBox();
                labelStatus[i] = new System.Windows.Forms.TextBox();

                labelId[i].Text = $"{prd[i].Id}";
                labelId[i].AutoSize = true;

                labelLogin[i].Text = $"{prd[i].Login}";
                labelLogin[i].AutoSize = true;

                labelPassword[i].AutoSize = true;
                labelPassword[i].Text = $"{prd[i].Password}";

                labelStatus[i].AutoSize = true;
                labelStatus[i].Text = $"{prd[i].Status}";

                tableLayoutPanel1.Controls.Add(labelId[i], 0, i + 1);
                tableLayoutPanel1.Controls.Add(labelLogin[i], 1, i + 1);
                tableLayoutPanel1.Controls.Add(labelPassword[i], 2, i + 1);
                tableLayoutPanel1.Controls.Add(labelStatus[i], 3, i + 1);
            }
        }

        private void ModRoom_Load(object sender, EventArgs e)
        {
            SetObjects();

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DatabaseContext db = new();

            User[] prd = db.Users.ToArray();

            for(int i = 0; i < prd.Length; i++)
            {
                try
                {
                    prd[i].Id = Convert.ToInt64(labelId[i].Text);
                    prd[i].Login = labelLogin[i].Text;
                    prd[i].Password = labelPassword[i].Text;
                    prd[i].Status = labelStatus[i].Text;
                }
                catch
                {
                    MessageBox.Show("Неправильный формат поля!");
                    SetObjects();
                    return;
                }
                
            }
            
            db.SaveChanges();
            MessageBox.Show("Данные успешно сохранены!");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            User usr = new User() { Login = "", Password = "", Status = ""};
            DatabaseContext db = new();
            db.Users.Add(usr);
            db.SaveChanges();
            SetObjects();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int id;
            if (!Int32.TryParse(textBoxDelete.Text,out id))
            {
                textBoxDelete.Text = "";
                return;
            }
                
            textBoxDelete.Text = "";
            DatabaseContext db = new();

            var usr = db.Users.FirstOrDefault(p => p.Id == id);
            

            if(usr != null)
            {
                var sales = db.Sales.Where(p => p.User == usr.Id);
                db.Sales.RemoveRange(sales);

                db.Users.Remove(usr);
                
                db.SaveChanges();
                SetObjects();
            }
            else
            {
                MessageBox.Show("Такой индекс не найден!");
            }


        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
