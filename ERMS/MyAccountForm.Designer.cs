namespace ERMS
{
    partial class MyAccountForm
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
            LblMyDetails = new Label();
            LblChangeLoginDetails = new Label();
            TxtName = new TextBox();
            TxtUsername = new TextBox();
            TxtEmail = new TextBox();
            TxtCurrentPassword = new TextBox();
            TxtNewPassword = new TextBox();
            TxtConfirmPassword = new TextBox();
            CbShowPassword = new CheckBox();
            BtnSaveNewPassword = new Button();
            SuspendLayout();
            // 
            // LblMyDetails
            // 
            LblMyDetails.AutoSize = true;
            LblMyDetails.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblMyDetails.ForeColor = Color.Black;
            LblMyDetails.Location = new Point(50, 9);
            LblMyDetails.Name = "LblMyDetails";
            LblMyDetails.Size = new Size(116, 30);
            LblMyDetails.TabIndex = 25;
            LblMyDetails.Text = "My Details";
            // 
            // LblChangeLoginDetails
            // 
            LblChangeLoginDetails.Anchor = AnchorStyles.Top;
            LblChangeLoginDetails.AutoSize = true;
            LblChangeLoginDetails.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblChangeLoginDetails.ForeColor = Color.Black;
            LblChangeLoginDetails.Location = new Point(441, 9);
            LblChangeLoginDetails.Name = "LblChangeLoginDetails";
            LblChangeLoginDetails.Size = new Size(221, 30);
            LblChangeLoginDetails.TabIndex = 34;
            LblChangeLoginDetails.Text = "Change Login Details";
            // 
            // TxtName
            // 
            TxtName.BackColor = Color.White;
            TxtName.Enabled = false;
            TxtName.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtName.Location = new Point(50, 62);
            TxtName.Name = "TxtName";
            TxtName.PlaceholderText = "Name";
            TxtName.Size = new Size(219, 33);
            TxtName.TabIndex = 35;
            // 
            // TxtUsername
            // 
            TxtUsername.BackColor = Color.White;
            TxtUsername.Enabled = false;
            TxtUsername.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtUsername.Location = new Point(50, 111);
            TxtUsername.Name = "TxtUsername";
            TxtUsername.PlaceholderText = "Username";
            TxtUsername.Size = new Size(219, 33);
            TxtUsername.TabIndex = 36;
            // 
            // TxtEmail
            // 
            TxtEmail.BackColor = Color.White;
            TxtEmail.Enabled = false;
            TxtEmail.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtEmail.Location = new Point(50, 160);
            TxtEmail.Name = "TxtEmail";
            TxtEmail.PlaceholderText = "Email";
            TxtEmail.Size = new Size(219, 33);
            TxtEmail.TabIndex = 37;
            // 
            // TxtCurrentPassword
            // 
            TxtCurrentPassword.Anchor = AnchorStyles.Top;
            TxtCurrentPassword.BackColor = Color.White;
            TxtCurrentPassword.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtCurrentPassword.Location = new Point(441, 62);
            TxtCurrentPassword.Name = "TxtCurrentPassword";
            TxtCurrentPassword.PlaceholderText = "Current Password";
            TxtCurrentPassword.Size = new Size(228, 33);
            TxtCurrentPassword.TabIndex = 38;
            TxtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // TxtNewPassword
            // 
            TxtNewPassword.Anchor = AnchorStyles.Top;
            TxtNewPassword.BackColor = Color.White;
            TxtNewPassword.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtNewPassword.Location = new Point(441, 111);
            TxtNewPassword.Name = "TxtNewPassword";
            TxtNewPassword.PlaceholderText = "New Password";
            TxtNewPassword.Size = new Size(228, 33);
            TxtNewPassword.TabIndex = 39;
            TxtNewPassword.UseSystemPasswordChar = true;
            // 
            // TxtConfirmPassword
            // 
            TxtConfirmPassword.Anchor = AnchorStyles.Top;
            TxtConfirmPassword.BackColor = Color.White;
            TxtConfirmPassword.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtConfirmPassword.Location = new Point(441, 160);
            TxtConfirmPassword.Name = "TxtConfirmPassword";
            TxtConfirmPassword.PlaceholderText = "Confirm Password";
            TxtConfirmPassword.Size = new Size(228, 33);
            TxtConfirmPassword.TabIndex = 40;
            TxtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // CbShowPassword
            // 
            CbShowPassword.Anchor = AnchorStyles.Top;
            CbShowPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CbShowPassword.ForeColor = SystemColors.ControlText;
            CbShowPassword.Location = new Point(441, 199);
            CbShowPassword.Name = "CbShowPassword";
            CbShowPassword.Size = new Size(187, 28);
            CbShowPassword.TabIndex = 41;
            CbShowPassword.Text = "Show Password";
            CbShowPassword.UseVisualStyleBackColor = true;
            CbShowPassword.CheckedChanged += CbShowPassword_CheckedChanged;
            // 
            // BtnSaveNewPassword
            // 
            BtnSaveNewPassword.Anchor = AnchorStyles.Top;
            BtnSaveNewPassword.BackColor = Color.FromArgb(128, 64, 0);
            BtnSaveNewPassword.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnSaveNewPassword.ForeColor = Color.White;
            BtnSaveNewPassword.Location = new Point(517, 233);
            BtnSaveNewPassword.Name = "BtnSaveNewPassword";
            BtnSaveNewPassword.Size = new Size(94, 38);
            BtnSaveNewPassword.TabIndex = 42;
            BtnSaveNewPassword.Text = "Save";
            BtnSaveNewPassword.UseVisualStyleBackColor = false;
            BtnSaveNewPassword.Click += BtnSaveNewPassword_Click;
            // 
            // MyAccountForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 766);
            Controls.Add(BtnSaveNewPassword);
            Controls.Add(CbShowPassword);
            Controls.Add(TxtConfirmPassword);
            Controls.Add(TxtNewPassword);
            Controls.Add(TxtCurrentPassword);
            Controls.Add(TxtEmail);
            Controls.Add(TxtUsername);
            Controls.Add(TxtName);
            Controls.Add(LblChangeLoginDetails);
            Controls.Add(LblMyDetails);
            Name = "MyAccountForm";
            Text = "MyAccountForm";
            Load += MyAccountForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblMyDetails;
        private Label LblChangeLoginDetails;
        private TextBox TxtName;
        private TextBox TxtUsername;
        private TextBox TxtEmail;
        private TextBox TxtCurrentPassword;
        private TextBox TxtNewPassword;
        private TextBox TxtConfirmPassword;
        private CheckBox CbShowPassword;
        private Button BtnSaveNewPassword;
    }
}