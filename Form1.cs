namespace ShopProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            locked = 3;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Registration frm = new Registration();
            frm.Show();
            this.Hide();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int locked;
        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            if(locked == 0)
            {
                File.WriteAllText("lock.txt", "1");
                timerLocker.Enabled = true;
                buttonLogIn.Enabled = false;
                buttonRegister.Enabled = false;
                labelLocked.Text = "Подождите 15 секунд!";
                return;
            }


            string login = textBoxLogin.Text.ToLower();
            string password = textBoxPassword.Text;

            DatabaseContext db = new();

            var usr = db.Users.FirstOrDefault(p => p.Login == login);

            
            if(usr != null)
            {
                if(usr.Password == password)
                {
                    if(usr.Status == "User")
                    {
                        Shop frm = new(usr.Id);
                        frm.Show();
                        this.Hide();
                    }
                    else if(usr.Status == "Admin")
                    {
                        AdminRoom frm = new();
                        frm.Show();
                        this.Hide();
                    }
                    else if(usr.Status == "Mod")
                    {
                        ModRoom frm = new();
                        frm.Show();
                        this.Hide();
                    }
                    return;
                }
            }

            labelLocked.Text = $"Осталось попыток: {locked}";

            textBoxLogin.BackColor = Color.Red;
            textBoxPassword.BackColor = Color.Red;
            locked--;
            timer1.Enabled = true;
        }

        bool IsHidden = true;
        private void buttonHide_Click(object sender, EventArgs e)
        {
            if (IsHidden)
            {
                buttonHide.Text = "---";
                textBoxPassword.PasswordChar = '0';
                IsHidden = false;
            }
            else
            {
                buttonHide.Text = "👁";
                textBoxPassword.PasswordChar = '*';
                IsHidden = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBoxLogin.BackColor = Color.White;
            textBoxPassword.BackColor = Color.White;
        }

        private void timerLocker_Tick(object sender, EventArgs e)
        {
            timerLocker.Enabled = false;
            Captcha cpt = new();
            cpt.ShowDialog();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(File.ReadAllText("lock.txt") == "0")
            {
                buttonLogIn.Enabled = true;
                buttonRegister.Enabled = true;
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.ReadAllText("lock.txt") == "1")
            {
                Captcha cpt = new();
                cpt.ShowDialog();
            }
        }
    }
}