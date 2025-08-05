namespace ERMS
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TxtUsername = new TextBox();
            BtnLogin = new Button();
            BtnRegisterForm = new Button();
            CbShowPassword = new CheckBox();
            BtnLoginForm = new Button();
            TxtPassword = new TextBox();
            PbUserIcon = new PictureBox();
            PbPasswordIcon = new PictureBox();
            PbLogo = new PictureBox();
            PnlLogin = new Panel();
            ((System.ComponentModel.ISupportInitialize)PbUserIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PbPasswordIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PbLogo).BeginInit();
            PnlLogin.SuspendLayout();
            SuspendLayout();
            // 
            // TxtUsername
            // 
            TxtUsername.BackColor = Color.Gray;
            TxtUsername.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            TxtUsername.ForeColor = Color.White;
            TxtUsername.Location = new Point(435, 520);
            TxtUsername.Name = "TxtUsername";
            TxtUsername.PlaceholderText = "Username";
            TxtUsername.Size = new Size(462, 39);
            TxtUsername.TabIndex = 0;
            TxtUsername.TextChanged += TxtUsername_TextChanged;
            // 
            // BtnLogin
            // 
            BtnLogin.BackColor = Color.Gray;
            BtnLogin.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            BtnLogin.ForeColor = Color.White;
            BtnLogin.Location = new Point(579, 673);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(162, 60);
            BtnLogin.TabIndex = 1;
            BtnLogin.Text = "Login";
            BtnLogin.UseVisualStyleBackColor = false;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // BtnRegisterForm
            // 
            BtnRegisterForm.BackColor = Color.Gray;
            BtnRegisterForm.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            BtnRegisterForm.ForeColor = Color.White;
            BtnRegisterForm.Location = new Point(666, 828);
            BtnRegisterForm.Name = "BtnRegisterForm";
            BtnRegisterForm.Size = new Size(162, 60);
            BtnRegisterForm.TabIndex = 2;
            BtnRegisterForm.Text = "Register";
            BtnRegisterForm.UseVisualStyleBackColor = false;
            BtnRegisterForm.Click += BtnRegisterForm_Click;
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
            // BtnLoginForm
            // 
            BtnLoginForm.BackColor = Color.FromArgb(128, 64, 0);
            BtnLoginForm.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            BtnLoginForm.ForeColor = Color.White;
            BtnLoginForm.Location = new Point(498, 828);
            BtnLoginForm.Name = "BtnLoginForm";
            BtnLoginForm.Size = new Size(162, 60);
            BtnLoginForm.TabIndex = 4;
            BtnLoginForm.Text = "Login";
            BtnLoginForm.UseVisualStyleBackColor = false;
            // 
            // TxtPassword
            // 
            TxtPassword.BackColor = Color.Gray;
            TxtPassword.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            TxtPassword.ForeColor = Color.White;
            TxtPassword.Location = new Point(435, 577);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PlaceholderText = "Password";
            TxtPassword.Size = new Size(462, 39);
            TxtPassword.TabIndex = 5;
            TxtPassword.UseSystemPasswordChar = true;
            // 
            // PbUserIcon
            // 
            PbUserIcon.BackgroundImage = Properties.Resources.profile;
            PbUserIcon.BackgroundImageLayout = ImageLayout.Zoom;
            PbUserIcon.Image = Properties.Resources.profile;
            PbUserIcon.Location = new Point(384, 523);
            PbUserIcon.Name = "PbUserIcon";
            PbUserIcon.Size = new Size(45, 36);
            PbUserIcon.TabIndex = 7;
            PbUserIcon.TabStop = false;
            // 
            // PbPasswordIcon
            // 
            PbPasswordIcon.BackgroundImage = Properties.Resources.rotation_lock;
            PbPasswordIcon.BackgroundImageLayout = ImageLayout.Zoom;
            PbPasswordIcon.Image = Properties.Resources.rotation_lock;
            PbPasswordIcon.Location = new Point(384, 580);
            PbPasswordIcon.Name = "PbPasswordIcon";
            PbPasswordIcon.Size = new Size(45, 36);
            PbPasswordIcon.TabIndex = 8;
            PbPasswordIcon.TabStop = false;
            // 
            // PbLogo
            // 
            PbLogo.BackgroundImage = Properties.Resources.logo;
            PbLogo.BackgroundImageLayout = ImageLayout.Zoom;
            PbLogo.ErrorImage = Properties.Resources.logo;
            PbLogo.Location = new Point(980, 0);
            PbLogo.Name = "PbLogo";
            PbLogo.Size = new Size(218, 161);
            PbLogo.TabIndex = 9;
            PbLogo.TabStop = false;
            // 
            // PnlLogin
            // 
            PnlLogin.Controls.Add(PbLogo);
            PnlLogin.Controls.Add(PbPasswordIcon);
            PnlLogin.Controls.Add(PbUserIcon);
            PnlLogin.Controls.Add(TxtPassword);
            PnlLogin.Controls.Add(BtnLoginForm);
            PnlLogin.Controls.Add(CbShowPassword);
            PnlLogin.Controls.Add(BtnRegisterForm);
            PnlLogin.Controls.Add(BtnLogin);
            PnlLogin.Controls.Add(TxtUsername);
            PnlLogin.Dock = DockStyle.Fill;
            PnlLogin.Location = new Point(0, 0);
            PnlLogin.Margin = new Padding(0);
            PnlLogin.Name = "PnlLogin";
            PnlLogin.Size = new Size(1924, 1061);
            PnlLogin.TabIndex = 1;
            PnlLogin.Paint += PnlLogin_Paint;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1061);
            Controls.Add(PnlLogin);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoginForm";
            Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)PbUserIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)PbPasswordIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)PbLogo).EndInit();
            PnlLogin.ResumeLayout(false);
            PnlLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox TxtUsername;
        private Button BtnLogin;
        private Button BtnRegisterForm;
        private CheckBox CbShowPassword;
        private Button BtnLoginForm;
        private TextBox TxtPassword;
        private PictureBox PbUserIcon;
        private PictureBox PbPasswordIcon;
        private PictureBox PbLogo;
        private Panel PnlLogin;
    }
}
