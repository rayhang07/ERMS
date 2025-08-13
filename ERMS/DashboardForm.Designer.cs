namespace ERMS
{
    partial class DashboardForm
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
            LblWelcomeBackMessage = new Label();
            LblDateTime = new Label();
            LblImportantDates = new Label();
            LblTopPerformers = new Label();
            LblTopClasses = new Label();
            LblExamDate2 = new Label();
            LblExamDate1 = new Label();
            LblTopPerformer1 = new Label();
            LblTopPerformer2 = new Label();
            LblTopClass1 = new Label();
            LblTopClass2 = new Label();
            PbLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PbLogo).BeginInit();
            SuspendLayout();
            // 
            // LblWelcomeBackMessage
            // 
            LblWelcomeBackMessage.Anchor = AnchorStyles.Top;
            LblWelcomeBackMessage.AutoSize = true;
            LblWelcomeBackMessage.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblWelcomeBackMessage.ForeColor = Color.Black;
            LblWelcomeBackMessage.Location = new Point(179, 9);
            LblWelcomeBackMessage.Name = "LblWelcomeBackMessage";
            LblWelcomeBackMessage.Size = new Size(433, 50);
            LblWelcomeBackMessage.TabIndex = 0;
            LblWelcomeBackMessage.Text = "Welcome Back {name} !";
            // 
            // LblDateTime
            // 
            LblDateTime.Anchor = AnchorStyles.Top;
            LblDateTime.AutoSize = true;
            LblDateTime.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblDateTime.ForeColor = Color.Black;
            LblDateTime.Location = new Point(339, 326);
            LblDateTime.Name = "LblDateTime";
            LblDateTime.Size = new Size(103, 50);
            LblDateTime.TabIndex = 1;
            LblDateTime.Text = "Date";
            LblDateTime.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LblImportantDates
            // 
            LblImportantDates.Anchor = AnchorStyles.Bottom;
            LblImportantDates.AutoSize = true;
            LblImportantDates.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            LblImportantDates.ForeColor = Color.Black;
            LblImportantDates.Location = new Point(68, 629);
            LblImportantDates.Name = "LblImportantDates";
            LblImportantDates.Size = new Size(202, 32);
            LblImportantDates.TabIndex = 2;
            LblImportantDates.Text = "Important Dates";
            LblImportantDates.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LblTopPerformers
            // 
            LblTopPerformers.Anchor = AnchorStyles.Bottom;
            LblTopPerformers.AutoSize = true;
            LblTopPerformers.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            LblTopPerformers.ForeColor = Color.Black;
            LblTopPerformers.Location = new Point(350, 629);
            LblTopPerformers.Name = "LblTopPerformers";
            LblTopPerformers.Size = new Size(191, 32);
            LblTopPerformers.TabIndex = 3;
            LblTopPerformers.Text = "Top Performers";
            LblTopPerformers.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LblTopClasses
            // 
            LblTopClasses.Anchor = AnchorStyles.Bottom;
            LblTopClasses.AutoSize = true;
            LblTopClasses.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            LblTopClasses.ForeColor = Color.Black;
            LblTopClasses.Location = new Point(590, 629);
            LblTopClasses.Name = "LblTopClasses";
            LblTopClasses.Size = new Size(144, 32);
            LblTopClasses.TabIndex = 4;
            LblTopClasses.Text = "Top Classes";
            LblTopClasses.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LblExamDate2
            // 
            LblExamDate2.Anchor = AnchorStyles.Bottom;
            LblExamDate2.AutoSize = true;
            LblExamDate2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            LblExamDate2.ForeColor = Color.Black;
            LblExamDate2.Location = new Point(68, 714);
            LblExamDate2.Name = "LblExamDate2";
            LblExamDate2.Size = new Size(53, 25);
            LblExamDate2.TabIndex = 5;
            LblExamDate2.Text = "Date";
            LblExamDate2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LblExamDate1
            // 
            LblExamDate1.Anchor = AnchorStyles.Bottom;
            LblExamDate1.AutoSize = true;
            LblExamDate1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            LblExamDate1.ForeColor = Color.Black;
            LblExamDate1.Location = new Point(68, 684);
            LblExamDate1.Name = "LblExamDate1";
            LblExamDate1.Size = new Size(53, 25);
            LblExamDate1.TabIndex = 6;
            LblExamDate1.Text = "Date";
            LblExamDate1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LblTopPerformer1
            // 
            LblTopPerformer1.Anchor = AnchorStyles.Bottom;
            LblTopPerformer1.AutoSize = true;
            LblTopPerformer1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            LblTopPerformer1.ForeColor = Color.Black;
            LblTopPerformer1.Location = new Point(350, 684);
            LblTopPerformer1.Name = "LblTopPerformer1";
            LblTopPerformer1.Size = new Size(141, 25);
            LblTopPerformer1.TabIndex = 7;
            LblTopPerformer1.Text = "Top Performer";
            LblTopPerformer1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LblTopPerformer2
            // 
            LblTopPerformer2.Anchor = AnchorStyles.Bottom;
            LblTopPerformer2.AutoSize = true;
            LblTopPerformer2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            LblTopPerformer2.ForeColor = Color.Black;
            LblTopPerformer2.Location = new Point(350, 714);
            LblTopPerformer2.Name = "LblTopPerformer2";
            LblTopPerformer2.Size = new Size(141, 25);
            LblTopPerformer2.TabIndex = 8;
            LblTopPerformer2.Text = "Top Performer";
            LblTopPerformer2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LblTopClass1
            // 
            LblTopClass1.Anchor = AnchorStyles.Bottom;
            LblTopClass1.AutoSize = true;
            LblTopClass1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            LblTopClass1.ForeColor = Color.Black;
            LblTopClass1.Location = new Point(590, 684);
            LblTopClass1.Name = "LblTopClass1";
            LblTopClass1.Size = new Size(93, 25);
            LblTopClass1.TabIndex = 9;
            LblTopClass1.Text = "Top Class";
            LblTopClass1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LblTopClass2
            // 
            LblTopClass2.Anchor = AnchorStyles.Bottom;
            LblTopClass2.AutoSize = true;
            LblTopClass2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            LblTopClass2.ForeColor = Color.Black;
            LblTopClass2.Location = new Point(590, 714);
            LblTopClass2.Name = "LblTopClass2";
            LblTopClass2.Size = new Size(93, 25);
            LblTopClass2.TabIndex = 10;
            LblTopClass2.Text = "Top Class";
            LblTopClass2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PbLogo
            // 
            PbLogo.Anchor = AnchorStyles.Top;
            PbLogo.BackgroundImage = Properties.Resources.logo;
            PbLogo.BackgroundImageLayout = ImageLayout.Zoom;
            PbLogo.Location = new Point(209, 128);
            PbLogo.Name = "PbLogo";
            PbLogo.Size = new Size(357, 173);
            PbLogo.TabIndex = 11;
            PbLogo.TabStop = false;
            PbLogo.Click += PbLogo_Click;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 766);
            Controls.Add(PbLogo);
            Controls.Add(LblTopClass2);
            Controls.Add(LblTopClass1);
            Controls.Add(LblTopPerformer2);
            Controls.Add(LblTopPerformer1);
            Controls.Add(LblExamDate1);
            Controls.Add(LblExamDate2);
            Controls.Add(LblTopClasses);
            Controls.Add(LblTopPerformers);
            Controls.Add(LblImportantDates);
            Controls.Add(LblDateTime);
            Controls.Add(LblWelcomeBackMessage);
            Name = "DashboardForm";
            Text = "DashboardForm";
            Load += DashboardForm_Load;
            ((System.ComponentModel.ISupportInitialize)PbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblWelcomeBackMessage;
        private Label LblDateTime;
        private Label LblImportantDates;
        private Label LblTopPerformers;
        private Label LblTopClasses;
        private Label LblExamDate2;
        private Label LblExamDate1;
        private Label LblTopPerformer1;
        private Label LblTopPerformer2;
        private Label LblTopClass1;
        private Label LblTopClass2;
        private PictureBox PbLogo;
    }
}