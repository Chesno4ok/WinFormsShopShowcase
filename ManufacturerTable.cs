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
    public partial class ManufacturerTable : Form
    {
        TextBox[] labelID;
        TextBox[] labelNaming;


        public ManufacturerTable()
        {
            InitializeComponent();
        }

        void SetObjects()
        {
            tableLayoutPanel1.Controls.Clear();

            tableLayoutPanel1.Controls.Add(labelId);
            tableLayoutPanel1.Controls.Add(labelName);

            var db = new DatabaseContext();

            Manufacturer[] mnf = db.Manufacturers.ToArray();

            labelID = new TextBox[mnf.Length];
            labelNaming = new TextBox[mnf.Length];

            for (int i = 0; i < mnf.Length; i++)
            {
                labelID[i] = new TextBox();
                labelNaming[i] = new TextBox();

                labelID[i].Text = $"{mnf[i].Id}";

                labelNaming[i].Text = mnf[i].Name;

                tableLayoutPanel1.Controls.Add(labelID[i], 0, i + 1);
                tableLayoutPanel1.Controls.Add(labelNaming[i], 1, i + 1);
            }
        }

        private void ManufacturerTable_Load(object sender, EventArgs e)
        {
            SetObjects();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int id;
            if (!Int32.TryParse(textBoxDelete.Text, out id))
            {
                textBoxDelete.Text = "";
                return;
            }

            textBoxDelete.Text = "";
            DatabaseContext db = new();

            var usr = db.Manufacturers.FirstOrDefault(p => p.Id == id);

            if (usr != null)
            {
                db.Manufacturers.Remove(usr);

                try
                {
                    db.SaveChanges();
                    
                }
                catch
                {
                    MessageBox.Show("Не удалось сохранить данные!");
                }
                SetObjects();
            }
            else
            {
                MessageBox.Show("Такой индекс не найден!");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DatabaseContext db = new();
            Manufacturer[] mnf = db.Manufacturers.ToArray();


            for (int i = 0; i < mnf.Length; i++)
            {
                try
                {
                    mnf[i].Id = Convert.ToInt64(labelID[i].Text);
                    mnf[i].Name = labelNaming[i].Text;
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    SetObjects();
                    return;
                }



            }


            try
            {
                db.SaveChanges();
                MessageBox.Show("Данные сохранены!");
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить данные");
                SetObjects();
            }
            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Manufacturer mnf = new Manufacturer();
            DatabaseContext db = new();
            db.Add(mnf);
            db.SaveChanges();
            SetObjects();
        }
    }
}
