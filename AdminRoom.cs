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
    public partial class AdminRoom : Form
    {
        TextBox[] label1;
        TextBox[] label2;
        TextBox[] label3;
        TextBox[] label4;
        ComboBox[] label5;
        TextBox[] label6;
        TextBox[] label7;
        TextBox[] label8;

        public AdminRoom()
        {
            InitializeComponent();
        }

        private void SetObjects()
        {
            tableLayoutPanel1.Controls.Clear();

            tableLayoutPanel1.Controls.Add(this.labelId);
            tableLayoutPanel1.Controls.Add(this.labelName);
            tableLayoutPanel1.Controls.Add(this.labelPrice);
            tableLayoutPanel1.Controls.Add(this.labelPicture);
            tableLayoutPanel1.Controls.Add(this.labelManufacturer);
            tableLayoutPanel1.Controls.Add(this.labelQuantity);
            tableLayoutPanel1.Controls.Add(this.labelDescription);

            DatabaseContext db = new();
            Product[] prd = db.Products.ToArray();


            label1 = new TextBox[prd.Length];
            label2 = new TextBox[prd.Length];
            label3 = new TextBox[prd.Length];
            label4 = new TextBox[prd.Length];
            label5 = new ComboBox[prd.Length];
            label6 = new TextBox[prd.Length];
            label7 = new TextBox[prd.Length];
            label8 = new TextBox[prd.Length];

            for(int i = 1;i < prd.Length; i++)
            {
                label1[i] = new TextBox();
                label2[i] = new TextBox();
                label3[i] = new TextBox();
                label4[i] = new TextBox();
                label5[i] = new ComboBox();
                label6[i] = new TextBox();
                label7[i] = new TextBox();

                label1[i].Text = $"{prd[i].Id}";

                label2[i].Text = $"{prd[i].Name}";

                label3[i].Text = $"{prd[i].Price}";

                label4[i].Text = $"{prd[i].Picture}";


                Manufacturer[] mnf = db.Manufacturers.ToArray();
                for(int x = 0; x < mnf.Length; x++)
                {
                    label5[i].Items.Add(mnf[x].Name);
                }

                label5[i].SelectedItem = db.Manufacturers.Find(prd[i].Manufacturer).Name;

                //label5[i].Text = $"{prd[i].Manufacturer}";
                //label5[i].Name = $"Manufacturer-{i}";

                label6[i].Text = $"{prd[i].Description}";
                label6[i].Name = $"Description-{i}";

                label7[i].Text = $"{prd[i].Quantity}";
                label7[i].Name = $"Quantity-{i}";


                tableLayoutPanel1.Controls.Add(label1[i], 0, i + 1);
                tableLayoutPanel1.Controls.Add(label2[i], 1, i + 1);
                tableLayoutPanel1.Controls.Add(label3[i], 2, i + 1);
                tableLayoutPanel1.Controls.Add(label4[i], 3, i + 1);
                tableLayoutPanel1.Controls.Add(label5[i], 4, i + 1);
                tableLayoutPanel1.Controls.Add(label6[i], 5, i + 1);
                tableLayoutPanel1.Controls.Add(label7[i], 6, i + 1);
            }

        }
        private void AdminRoom_Load(object sender, EventArgs e)
        {
            SetObjects();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DatabaseContext db = new();
            Product[] prd = db.Products.ToArray();
            

            for(int i = 1; i < prd.Length;i++)
            {
                try
                {
                    prd[i].Id = Convert.ToInt64(label1[i].Text);
                    prd[i].Name = label2[i].Text;
                    prd[i].Price = Convert.ToInt64(label3[i].Text);
                    prd[i].Picture = label4[i].Text;

                    var mnf = db.Manufacturers.FirstOrDefault(p => p.Name == label5[i].SelectedItem);
                    if(mnf != null)
                    {
                        prd[i].Manufacturer = mnf.Id;
                    }
                    else
                    {
                        MessageBox.Show($"Неправильно указан внешний ключ!");
                    }
                    
                    prd[i].Description = label6[i].Text;
                    prd[i].Quantity = Convert.ToInt64(label7[i].Text);
                }
                catch(Exception a)
                {
                    MessageBox.Show(a.Message);
                    SetObjects();
                    return;
                }
                


            }
            db.SaveChanges();
            MessageBox.Show("Данные сохранены!");
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Form1 frm = new();
            frm.Show();
            this.Hide();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Product prd = new Product() {Price = 0, Manufacturer = 1, Quantity = 1};
            DatabaseContext db = new();
            db.Products.Add(prd);
            db.SaveChanges();
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

            var usr = db.Products.FirstOrDefault(p => p.Id == id);

            

            if (usr != null)
            {
                while(db.Sales.FirstOrDefault(p => p.Product == usr.Id) != null)
                {
                    var sls = db.Sales.FirstOrDefault(p => p.Product == usr.Id);
                    sls.Product = null;
                    db.SaveChanges();
                }

                db.Products.Remove(usr);
                db.SaveChanges();
                SetObjects();
            }
            else
            {
                MessageBox.Show("Такой индекс не найден!");
            }
        }

        private void buttonManufacturer_Click(object sender, EventArgs e)
        {
            ManufacturerTable mnf = new ManufacturerTable();
            mnf.ShowDialog();
        }
    }
}
