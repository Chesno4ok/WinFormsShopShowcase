using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopProject
{
    public partial class Shop : Form
    {
        private long UserId;
        Button[] button1;

        Product[] prd;

        bool? IsPriceSorted = false;
        bool? IsQuantitySorted = false;


        public Shop(long id)
        {
            UserId = id;
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
        private void SetObjects()
        {
            flowLayoutPanel1.Controls.Clear();

            DatabaseContext db = new();


            Panel[] panel1 = new Panel[prd.Length];
            Label[] labelName = new Label[prd.Length];
            Label[] labelManifacturer = new Label[prd.Length];
            PictureBox[] pictureBox1 = new PictureBox[prd.Length];
            Label[] labelDescription = new Label[prd.Length];
            Label[] label1 = new Label[prd.Length];
            button1 = new Button[prd.Length];
            Label[] labelAmount = new Label[prd.Length];

            for (int i = 0; i < prd.Length; i++)
            {
                panel1[i] = new System.Windows.Forms.Panel();
                labelName[i] = new System.Windows.Forms.Label();
                labelManifacturer[i] = new System.Windows.Forms.Label();
                pictureBox1[i] = new System.Windows.Forms.PictureBox();
                labelDescription[i] = new System.Windows.Forms.Label();
                label1[i] = new System.Windows.Forms.Label(); // Price
                button1[i] = new System.Windows.Forms.Button();
                labelAmount[i] = new System.Windows.Forms.Label();

                // 
                // panel1
                // 
                panel1[i].Controls.Add(labelAmount[i]);
                panel1[i].Controls.Add(button1[i]);
                panel1[i].Controls.Add(label1[i]);
                panel1[i].Controls.Add(labelDescription[i]);
                panel1[i].Controls.Add(pictureBox1[i]);
                panel1[i].Controls.Add(labelManifacturer[i]);
                panel1[i].Controls.Add(labelName[i]);
                panel1[i].BackColor = Color.Wheat;
                panel1[i].Location = new System.Drawing.Point(3, 3);
                panel1[i].Name = "panel1";
                panel1[i].Size = new System.Drawing.Size(687, 238);
                panel1[i].TabIndex = 0;
                // 
                // labelName
                // 
                labelName[i].AutoSize = true;
                labelName[i].Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                labelName[i].Location = new System.Drawing.Point(3, 0);
                labelName[i].Name = "labelName";
                labelName[i].Size = new System.Drawing.Size(136, 37);
                labelName[i].TabIndex = 0;
                labelName[i].Text = prd[i].Name;
                // 
                // labelManifacturer
                // 
                labelManifacturer[i].AutoSize = true;
                labelManifacturer[i].Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                labelManifacturer[i].Location = new System.Drawing.Point(3, 37);
                labelManifacturer[i].Name = "labelManifacturer";
                labelManifacturer[i].Size = new System.Drawing.Size(147, 25);
                labelManifacturer[i].TabIndex = 1;
                var mnfctr = db.Manufacturers.Find(prd[i].Manufacturer);
                labelManifacturer[i].Text = mnfctr.Name;
                // 
                // pictureBox1
                // 
                pictureBox1[i].BackColor = System.Drawing.SystemColors.ActiveCaption;
                pictureBox1[i].Location = new System.Drawing.Point(3, 65);
                pictureBox1[i].Name = "pictureBox1";
                pictureBox1[i].Size = new System.Drawing.Size(250, 169);
                pictureBox1[i].TabIndex = 2;
                pictureBox1[i].TabStop = false;
                pictureBox1[i].SizeMode = PictureBoxSizeMode.StretchImage;
                try
                {
                    pictureBox1[i].Image = Image.FromFile($"pictures\\{prd[i].Picture}");
                }
                catch
                {

                }
                
                // 
                // labelDescription
                // 
                labelDescription[i].Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                labelDescription[i].Location = new System.Drawing.Point(259, 0);
                labelDescription[i].MaximumSize = new System.Drawing.Size(900, 300);
                labelDescription[i].Name = "labelDescription";
                labelDescription[i].Size = new System.Drawing.Size(425, 191);
                labelDescription[i].TabIndex = 3;
                labelDescription[i].Text = prd[i].Description;
                // 
                // label1
                // 
                label1[i].AutoSize = true;
                label1[i].Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                label1[i].Location = new System.Drawing.Point(518, 200);
                label1[i].Name = "label1";
                label1[i].Size = new System.Drawing.Size(62, 25);
                label1[i].TabIndex = 4;
                label1[i].Text = $"{prd[i].Price}$";
                // 
                // button1
                // 
                button1[i].Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                button1[i].Location = new System.Drawing.Point(586, 196);
                button1[i].Name = $"{prd[i].Id}";
                button1[i].Size = new System.Drawing.Size(88, 38);
                button1[i].TabIndex = 5;
                button1[i].Text = "Купить";
                button1[i].UseVisualStyleBackColor = true;
                button1[i].Click += Shop_Click;
                if (prd[i].Quantity <= 0)
                {
                    button1[i].Enabled = false;
                }
                else
                {
                    button1[i].Enabled = true;
                }

                // 
                // flowLayoutPanel1
                // 
                this.flowLayoutPanel1.Controls.Add(panel1[i]);
                // label amount
                labelAmount[i].AutoSize = true;
                labelAmount[i].Location = new System.Drawing.Point(259, 208);
                labelAmount[i].Name = "labelAmount";
                labelAmount[i].Size = new System.Drawing.Size(89, 15);
                labelAmount[i].TabIndex = 6;
                labelAmount[i].Text = $"В наличии: {prd[i].Quantity}";
            }




        }

        private void Shop_Click(object? sender, EventArgs e)
        {
            Button btn = (Button)sender;

            Sale sl = new Sale() { User = UserId, Product = Convert.ToInt64(btn.Name), Date = DateTime.Now.ToString("dd.MM.yyyy") };
            DatabaseContext db = new();
            db.Sales.Add(sl);

            var prdct = db.Products.Find(Convert.ToInt64(btn.Name));
            prdct.Quantity--;

            db.SaveChanges();

            prd = db.Products.ToArray();
            SetObjects();

            MessageBox.Show("Спасибо за покупку!");
        }

        private void Shop_Load(object sender, EventArgs e)
        {
            DatabaseContext db = new();
            prd = db.Products.ToArray();

            SetObjects();
        }

        private void Shop_SizeChanged(object sender, EventArgs e)
        {
            flowLayoutPanel1.Size = this.Size;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string srch = textBoxSearch.Text;
            DatabaseContext db = new();

            if (srch == "")
            {
                prd = db.Products.ToArray();
                SetObjects();
                return;
            }

          
            
            List<Product> Names = db.Products.Where(p => EF.Functions.Like(p.Name, $"%{srch}%")).ToList<Product>();
            List<Product> Descriptions = db.Products.Where(p => EF.Functions.Like(p.Description, $"%{srch}%")).ToList<Product>();

            List<Product> Manufacturers = new List<Product>();
            Regex reg = new Regex(@$"{srch}");
            foreach (Product a in db.Products.ToArray())
            {
                if (reg.IsMatch(db.Manufacturers.Find(a.Manufacturer).Name))
                {
                    Manufacturers.Add(a);
                }

            }

            List<Product> preRes = new List<Product>();
            preRes.AddRange(Names);

            foreach(Product a in Descriptions)
            {
                if(preRes.FirstOrDefault(p => p == a) == null)
                {
                    preRes.Add(a);
                }
            }

            foreach (Product a in Manufacturers)
            {
                if (preRes.FirstOrDefault(p => p == a) == null)
                {
                    preRes.Add(a);
                }
            }

            prd = preRes.ToArray();

            SetObjects();
        }

        private void buttonSortPrice_Click(object sender, EventArgs e)
        {
            DatabaseContext db = new();
            if (IsPriceSorted == false)
            {
                IsPriceSorted = true;

                prd = prd.OrderBy(p => p.Price).ToArray();

                buttonSortPrice.Text = "Цена по возр.";
                buttonSortQuantity.Text = "Наличие";
            }
            else if(IsPriceSorted == true)
            {
                IsPriceSorted = false;

                prd = prd.OrderByDescending(p => p.Price).ToArray();

                buttonSortPrice.Text = "Цена по убыв.";
                buttonSortQuantity.Text = "Наличие";
            }

            SetObjects();
        }

        private void buttonSortQuantity_Click(object sender, EventArgs e)
        {
            DatabaseContext db = new();
            if (IsQuantitySorted == false)
            {
                IsQuantitySorted = true;

                prd = prd.OrderBy(p => p.Quantity).ToArray();

                buttonSortQuantity.Text = "Наличие по возр.";
                buttonSortPrice.Text = "Цена";
            }
            else if (IsQuantitySorted == true)
            {
                IsQuantitySorted = false;

                prd = prd.OrderByDescending(p => p.Quantity).ToArray();

                buttonSortQuantity.Text = "Наличие по убыв.";
                buttonSortPrice.Text = "Цена";
            }

            SetObjects();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }
    }
}
