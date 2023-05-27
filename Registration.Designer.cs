namespace ShopProject
{
    partial class Registration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.labelLogin = new System.Windows.Forms.Label();
            this.textBoxPasswordRepeat = new System.Windows.Forms.TextBox();
            this.labelPasswordRepeat = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelLoginWarn = new System.Windows.Forms.Label();
            this.labelPasswordWarn = new System.Windows.Forms.Label();
            this.labelPasswordRepeatWarn = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(37, 159);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(143, 23);
            this.textBoxPassword.TabIndex = 7;
            this.toolTip1.SetToolTip(this.textBoxPassword, "Введите пароль");
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPassword.Location = new System.Drawing.Point(59, 91);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(96, 32);
            this.labelPassword.TabIndex = 6;
            this.labelPassword.Text = "Пароль";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Location = new System.Drawing.Point(37, 44);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(143, 23);
            this.textBoxLogin.TabIndex = 5;
            this.toolTip1.SetToolTip(this.textBoxLogin, "Введите логин");
            // 
            // labelLogin
            // 
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelLogin.Location = new System.Drawing.Point(59, 9);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(81, 32);
            this.labelLogin.TabIndex = 4;
            this.labelLogin.Text = "Логин";
            // 
            // textBoxPasswordRepeat
            // 
            this.textBoxPasswordRepeat.Location = new System.Drawing.Point(37, 243);
            this.textBoxPasswordRepeat.Name = "textBoxPasswordRepeat";
            this.textBoxPasswordRepeat.Size = new System.Drawing.Size(143, 23);
            this.textBoxPasswordRepeat.TabIndex = 9;
            this.toolTip1.SetToolTip(this.textBoxPasswordRepeat, "Повторите пароль");
            // 
            // labelPasswordRepeat
            // 
            this.labelPasswordRepeat.AutoSize = true;
            this.labelPasswordRepeat.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelPasswordRepeat.Location = new System.Drawing.Point(0, 208);
            this.labelPasswordRepeat.Name = "labelPasswordRepeat";
            this.labelPasswordRepeat.Size = new System.Drawing.Size(233, 32);
            this.labelPasswordRepeat.TabIndex = 8;
            this.labelPasswordRepeat.Text = "Повоторите пароль";
            // 
            // buttonRegister
            // 
            this.buttonRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonRegister.Location = new System.Drawing.Point(23, 291);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(170, 48);
            this.buttonRegister.TabIndex = 10;
            this.buttonRegister.Text = "Зарегистрироватсья";
            this.toolTip1.SetToolTip(this.buttonRegister, "Завершить регистрацию");
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonExit.Location = new System.Drawing.Point(23, 345);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(170, 46);
            this.buttonExit.TabIndex = 11;
            this.buttonExit.Text = "Выйти";
            this.toolTip1.SetToolTip(this.buttonExit, "Выйти из окна регистрации");
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelLoginWarn
            // 
            this.labelLoginWarn.AutoSize = true;
            this.labelLoginWarn.ForeColor = System.Drawing.Color.Red;
            this.labelLoginWarn.Location = new System.Drawing.Point(37, 76);
            this.labelLoginWarn.Name = "labelLoginWarn";
            this.labelLoginWarn.Size = new System.Drawing.Size(38, 15);
            this.labelLoginWarn.TabIndex = 12;
            this.labelLoginWarn.Text = "label1";
            // 
            // labelPasswordWarn
            // 
            this.labelPasswordWarn.AutoSize = true;
            this.labelPasswordWarn.ForeColor = System.Drawing.Color.Red;
            this.labelPasswordWarn.Location = new System.Drawing.Point(37, 185);
            this.labelPasswordWarn.Name = "labelPasswordWarn";
            this.labelPasswordWarn.Size = new System.Drawing.Size(38, 15);
            this.labelPasswordWarn.TabIndex = 13;
            this.labelPasswordWarn.Text = "label1";
            // 
            // labelPasswordRepeatWarn
            // 
            this.labelPasswordRepeatWarn.AutoSize = true;
            this.labelPasswordRepeatWarn.ForeColor = System.Drawing.Color.Red;
            this.labelPasswordRepeatWarn.Location = new System.Drawing.Point(37, 269);
            this.labelPasswordRepeatWarn.Name = "labelPasswordRepeatWarn";
            this.labelPasswordRepeatWarn.Size = new System.Drawing.Size(38, 15);
            this.labelPasswordRepeatWarn.TabIndex = 14;
            this.labelPasswordRepeatWarn.Text = "label1";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(0, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 33);
            this.label1.TabIndex = 15;
            this.label1.Text = "Длиннее 6 символов, 1 большая буква, 1 спец символ и 1 пунктуация, 1 цифра\r\n";
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 428);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelPasswordRepeatWarn);
            this.Controls.Add(this.labelPasswordWarn);
            this.Controls.Add(this.labelLoginWarn);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.textBoxPasswordRepeat);
            this.Controls.Add(this.labelPasswordRepeat);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelLogin);
            this.Name = "Registration";
            this.Text = "Registration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxPassword;
        private Label labelPassword;
        private TextBox textBoxLogin;
        private Label labelLogin;
        private TextBox textBoxPasswordRepeat;
        private Label labelPasswordRepeat;
        private Button buttonRegister;
        private Button buttonExit;
        private Label labelLoginWarn;
        private Label labelPasswordWarn;
        private Label labelPasswordRepeatWarn;
        private System.Windows.Forms.Timer timer;
        private ToolTip toolTip1;
        private Label label1;
    }
}