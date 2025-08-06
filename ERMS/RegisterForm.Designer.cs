namespace ERMS
{
    partial class RegisterForm
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
            PnlRegister = new Panel();
            PbLogo = new PictureBox();
            PbEmailIcon = new PictureBox();
            TxtConfirmPassword = new TextBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            TxtName = new TextBox();
            TxtEmail = new TextBox();
            PbPasswordIcon = new PictureBox();
            PbUserIcon = new PictureBox();
            TxtPassword = new TextBox();
            BtnLoginForm = new Button();
            CbShowPassword = new CheckBox();
            BtnRegisterForm = new Button();
            BtnRegister = new Button();
            TxtUsername = new TextBox();
            PnlRegister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PbEmailIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PbPasswordIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PbUserIcon).BeginInit();
            SuspendLayout();
            // 
            // PnlRegister
            // 
            PnlRegister.Controls.Add(PbLogo);
            PnlRegister.Controls.Add(PbEmailIcon);
            PnlRegister.Controls.Add(TxtConfirmPassword);
            PnlRegister.Controls.Add(pictureBox2);
            PnlRegister.Controls.Add(pictureBox1);
            PnlRegister.Controls.Add(TxtName);
            PnlRegister.Controls.Add(TxtEmail);
            PnlRegister.Controls.Add(PbPasswordIcon);
            PnlRegister.Controls.Add(PbUserIcon);
            PnlRegister.Controls.Add(TxtPassword);
            PnlRegister.Controls.Add(BtnLoginForm);
            PnlRegister.Controls.Add(CbShowPassword);
            PnlRegister.Controls.Add(BtnRegisterForm);
            PnlRegister.Controls.Add(BtnRegister);
            PnlRegister.Controls.Add(TxtUsername);
            PnlRegister.Dock = DockStyle.Fill;
            PnlRegister.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PnlRegister.Location = new Point(0, 0);
            PnlRegister.Margin = new Padding(0);
            PnlRegister.Name = "PnlRegister";
            PnlRegister.Size = new Size(1879, 1061);
            PnlRegister.TabIndex = 2;
            PnlRegister.Paint += PnlRegister_Paint;
            // 
            // PbLogo
            // 
            PbLogo.BackgroundImage = Properties.Resources.logo;
            PbLogo.BackgroundImageLayout = ImageLayout.Zoom;
            PbLogo.ErrorImage = Properties.Resources.logo;
            PbLogo.Location = new Point(980, 0);
            PbLogo.Name = "PbLogo";
            PbLogo.Size = new Size(218, 161);
            PbLogo.TabIndex = 10;
            PbLogo.TabStop = false;
            // 
            // PbEmailIcon
            // 
            PbEmailIcon.BackgroundImage = Properties.Resources.business;
            PbEmailIcon.BackgroundImageLayout = ImageLayout.Zoom;
            PbEmailIcon.Image = Properties.Resources.business;
            PbEmailIcon.Location = new Point(384, 489);
            PbEmailIcon.Name = "PbEmailIcon";
            PbEmailIcon.Size = new Size(45, 36);
            PbEmailIcon.TabIndex = 15;
            PbEmailIcon.TabStop = false;
            // 
            // TxtConfirmPassword
            // 
            TxtConfirmPassword.BackColor = Color.Gray;
            TxtConfirmPassword.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            TxtConfirmPassword.ForeColor = Color.White;
            TxtConfirmPassword.Location = new Point(435, 579);
            TxtConfirmPassword.Name = "TxtConfirmPassword";
            TxtConfirmPassword.PlaceholderText = "Confirm Password";
            TxtConfirmPassword.Size = new Size(462, 39);
            TxtConfirmPassword.TabIndex = 14;
            TxtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.rotation_lock;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Image = Properties.Resources.rotation_lock;
            pictureBox2.Location = new Point(384, 579);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(45, 36);
            pictureBox2.TabIndex = 13;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.profile;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Image = Properties.Resources.profile;
            pictureBox1.Location = new Point(384, 399);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(45, 36);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // TxtName
            // 
            TxtName.BackColor = Color.Gray;
            TxtName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            TxtName.ForeColor = Color.White;
            TxtName.Location = new Point(435, 396);
            TxtName.Name = "TxtName";
            TxtName.PlaceholderText = "Name";
            TxtName.Size = new Size(462, 39);
            TxtName.TabIndex = 11;
            // 
            // TxtEmail
            // 
            TxtEmail.BackColor = Color.Gray;
            TxtEmail.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            TxtEmail.ForeColor = Color.White;
            TxtEmail.Location = new Point(435, 486);
            TxtEmail.Name = "TxtEmail";
            TxtEmail.PlaceholderText = "Email";
            TxtEmail.Size = new Size(462, 39);
            TxtEmail.TabIndex = 10;
            // 
            // PbPasswordIcon
            // 
            PbPasswordIcon.BackgroundImage = Properties.Resources.rotation_lock;
            PbPasswordIcon.BackgroundImageLayout = ImageLayout.Zoom;
            PbPasswordIcon.Image = Properties.Resources.rotation_lock;
            PbPasswordIcon.Location = new Point(384, 534);
            PbPasswordIcon.Name = "PbPasswordIcon";
            PbPasswordIcon.Size = new Size(45, 36);
            PbPasswordIcon.TabIndex = 8;
            PbPasswordIcon.TabStop = false;
            // 
            // PbUserIcon
            // 
            PbUserIcon.BackgroundImage = Properties.Resources.profile;
            PbUserIcon.BackgroundImageLayout = ImageLayout.Zoom;
            PbUserIcon.Image = Properties.Resources.profile;
            PbUserIcon.Location = new Point(384, 444);
            PbUserIcon.Name = "PbUserIcon";
            PbUserIcon.Size = new Size(45, 36);
            PbUserIcon.TabIndex = 7;
            PbUserIcon.TabStop = false;
            // 
            // TxtPassword
            // 
            TxtPassword.BackColor = Color.Gray;
            TxtPassword.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            TxtPassword.ForeColor = Color.White;
            TxtPassword.Location = new Point(435, 531);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PlaceholderText = "Password";
            TxtPassword.Size = new Size(462, 39);
            TxtPassword.TabIndex = 5;
            TxtPassword.UseSystemPasswordChar = true;
            TxtPassword.TextChanged += TxtPassword_TextChanged;
            // 
            // BtnLoginForm
            // 
            BtnLoginForm.BackColor = Color.Gray;
            BtnLoginForm.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            BtnLoginForm.ForeColor = Color.White;
            BtnLoginForm.Location = new Point(498, 828);
            BtnLoginForm.Name = "BtnLoginForm";
            BtnLoginForm.Size = new Size(162, 60);
            BtnLoginForm.TabIndex = 4;
            BtnLoginForm.Text = "Login";
            BtnLoginForm.UseVisualStyleBackColor = false;
            BtnLoginForm.Click += BtnLoginForm_Click;
            // 
            // CbShowPassword
            // 
            CbShowPassword.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            CbShowPassword.ForeColor = SystemColors.ControlText;
            CbShowPassword.Location = new Point(435, 622);
            CbShowPassword.Name = "CbShowPassword";
            CbShowPassword.Size = new Size(187, 28);
            CbShowPassword.TabIndex = 3;
            CbShowPassword.Text = "Show Password";
            CbShowPassword.UseVisualStyleBackColor = true;
            CbShowPassword.CheckedChanged += CbShowPassword_CheckedChanged;
            // 
            // BtnRegisterForm
            // 
            BtnRegisterForm.BackColor = Color.FromArgb(128, 64, 0);
            BtnRegisterForm.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            BtnRegisterForm.ForeColor = Color.White;
            BtnRegisterForm.Location = new Point(666, 828);
            BtnRegisterForm.Name = "BtnRegisterForm";
            BtnRegisterForm.Size = new Size(162, 60);
            BtnRegisterForm.TabIndex = 2;
            BtnRegisterForm.Text = "Register";
            BtnRegisterForm.UseVisualStyleBackColor = false;
            // 
            // BtnRegister
            // 
            BtnRegister.BackColor = Color.Gray;
            BtnRegister.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            BtnRegister.ForeColor = Color.White;
            BtnRegister.Location = new Point(579, 673);
            BtnRegister.Name = "BtnRegister";
            BtnRegister.Size = new Size(162, 60);
            BtnRegister.TabIndex = 1;
            BtnRegister.Text = "Register";
            BtnRegister.UseVisualStyleBackColor = false;
            BtnRegister.Click += BtnRegister_Click;
            // 
            // TxtUsername
            // 
            TxtUsername.BackColor = Color.Gray;
            TxtUsername.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            TxtUsername.ForeColor = Color.White;
            TxtUsername.Location = new Point(435, 441);
            TxtUsername.Name = "TxtUsername";
            TxtUsername.PlaceholderText = "Username";
            TxtUsername.Size = new Size(462, 39);
            TxtUsername.TabIndex = 0;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1879, 1061);
            Controls.Add(PnlRegister);
            Name = "RegisterForm";
            Text = "RegisterForm";
            PnlRegister.ResumeLayout(false);
            PnlRegister.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PbLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)PbEmailIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)PbPasswordIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)PbUserIcon).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel PnlRegister;
        private PictureBox PbPasswordIcon;
        private PictureBox PbUserIcon;
        private TextBox TxtPassword;
        private Button BtnLoginForm;
        private CheckBox CbShowPassword;
        private Button BtnRegisterForm;
        private Button BtnRegister;
        private TextBox TxtUsername;
        private TextBox TxtName;
        private TextBox TxtEmail;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private TextBox TxtConfirmPassword;
        private PictureBox PbEmailIcon;
        private PictureBox PbLogo;
    }
}