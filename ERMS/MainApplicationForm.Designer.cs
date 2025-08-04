namespace ERMS
{
    partial class MainApplicationForm
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
            PnlSideMenu = new Panel();
            BtnMyAccount = new Button();
            BtnStudentRankings = new Button();
            BtnReport = new Button();
            PnlGradeBookSubMenu = new Panel();
            BtnResultsAnalytics = new Button();
            BtnExamResults = new Button();
            BtnGradeBook = new Button();
            PnlClassesSubMenu = new Panel();
            BtnManageClass = new Button();
            BtnCreateClass = new Button();
            BtnMyClasses = new Button();
            BtnClasses = new Button();
            BtnDashboard = new Button();
            PnlMenuIcon = new Panel();
            PnlContainer = new Panel();
            PnlSideMenu.SuspendLayout();
            PnlGradeBookSubMenu.SuspendLayout();
            PnlClassesSubMenu.SuspendLayout();
            SuspendLayout();
            // 
            // PnlSideMenu
            // 
            PnlSideMenu.AutoScroll = true;
            PnlSideMenu.BackColor = Color.FromArgb(128, 64, 0);
            PnlSideMenu.Controls.Add(BtnMyAccount);
            PnlSideMenu.Controls.Add(BtnStudentRankings);
            PnlSideMenu.Controls.Add(BtnReport);
            PnlSideMenu.Controls.Add(PnlGradeBookSubMenu);
            PnlSideMenu.Controls.Add(BtnGradeBook);
            PnlSideMenu.Controls.Add(PnlClassesSubMenu);
            PnlSideMenu.Controls.Add(BtnClasses);
            PnlSideMenu.Controls.Add(BtnDashboard);
            PnlSideMenu.Controls.Add(PnlMenuIcon);
            PnlSideMenu.Dock = DockStyle.Left;
            PnlSideMenu.Location = new Point(0, 0);
            PnlSideMenu.Name = "PnlSideMenu";
            PnlSideMenu.Size = new Size(307, 659);
            PnlSideMenu.TabIndex = 0;
            // 
            // BtnMyAccount
            // 
            BtnMyAccount.Dock = DockStyle.Top;
            BtnMyAccount.FlatAppearance.BorderSize = 0;
            BtnMyAccount.FlatStyle = FlatStyle.Flat;
            BtnMyAccount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnMyAccount.Location = new Point(0, 582);
            BtnMyAccount.Name = "BtnMyAccount";
            BtnMyAccount.Size = new Size(307, 50);
            BtnMyAccount.TabIndex = 6;
            BtnMyAccount.Text = "My Account";
            BtnMyAccount.TextAlign = ContentAlignment.MiddleLeft;
            BtnMyAccount.UseVisualStyleBackColor = true;
            BtnMyAccount.Click += BtnMyAccount_Click;
            // 
            // BtnStudentRankings
            // 
            BtnStudentRankings.Dock = DockStyle.Top;
            BtnStudentRankings.FlatAppearance.BorderSize = 0;
            BtnStudentRankings.FlatStyle = FlatStyle.Flat;
            BtnStudentRankings.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnStudentRankings.Location = new Point(0, 532);
            BtnStudentRankings.Name = "BtnStudentRankings";
            BtnStudentRankings.Size = new Size(307, 50);
            BtnStudentRankings.TabIndex = 5;
            BtnStudentRankings.Text = "Student Rankings";
            BtnStudentRankings.TextAlign = ContentAlignment.MiddleLeft;
            BtnStudentRankings.UseVisualStyleBackColor = true;
            BtnStudentRankings.Click += BtnStudentRankings_Click;
            // 
            // BtnReport
            // 
            BtnReport.Dock = DockStyle.Top;
            BtnReport.FlatAppearance.BorderSize = 0;
            BtnReport.FlatStyle = FlatStyle.Flat;
            BtnReport.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnReport.Location = new Point(0, 482);
            BtnReport.Name = "BtnReport";
            BtnReport.Size = new Size(307, 50);
            BtnReport.TabIndex = 4;
            BtnReport.Text = "Report";
            BtnReport.TextAlign = ContentAlignment.MiddleLeft;
            BtnReport.UseVisualStyleBackColor = true;
            BtnReport.Click += BtnReport_Click;
            // 
            // PnlGradeBookSubMenu
            // 
            PnlGradeBookSubMenu.Controls.Add(BtnResultsAnalytics);
            PnlGradeBookSubMenu.Controls.Add(BtnExamResults);
            PnlGradeBookSubMenu.Dock = DockStyle.Top;
            PnlGradeBookSubMenu.Location = new Point(0, 387);
            PnlGradeBookSubMenu.Name = "PnlGradeBookSubMenu";
            PnlGradeBookSubMenu.Size = new Size(307, 95);
            PnlGradeBookSubMenu.TabIndex = 5;
            // 
            // BtnResultsAnalytics
            // 
            BtnResultsAnalytics.Dock = DockStyle.Top;
            BtnResultsAnalytics.FlatAppearance.BorderSize = 0;
            BtnResultsAnalytics.FlatStyle = FlatStyle.Flat;
            BtnResultsAnalytics.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnResultsAnalytics.ImageAlign = ContentAlignment.MiddleLeft;
            BtnResultsAnalytics.Location = new Point(0, 45);
            BtnResultsAnalytics.Name = "BtnResultsAnalytics";
            BtnResultsAnalytics.Padding = new Padding(35, 0, 0, 0);
            BtnResultsAnalytics.Size = new Size(307, 45);
            BtnResultsAnalytics.TabIndex = 1;
            BtnResultsAnalytics.Text = "Results Analytics";
            BtnResultsAnalytics.TextAlign = ContentAlignment.MiddleLeft;
            BtnResultsAnalytics.UseVisualStyleBackColor = true;
            BtnResultsAnalytics.Click += BtnResultsAnalytics_Click;
            // 
            // BtnExamResults
            // 
            BtnExamResults.Dock = DockStyle.Top;
            BtnExamResults.FlatAppearance.BorderSize = 0;
            BtnExamResults.FlatStyle = FlatStyle.Flat;
            BtnExamResults.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnExamResults.ImageAlign = ContentAlignment.MiddleLeft;
            BtnExamResults.Location = new Point(0, 0);
            BtnExamResults.Name = "BtnExamResults";
            BtnExamResults.Padding = new Padding(35, 0, 0, 0);
            BtnExamResults.Size = new Size(307, 45);
            BtnExamResults.TabIndex = 0;
            BtnExamResults.Text = "Exam Results";
            BtnExamResults.TextAlign = ContentAlignment.MiddleLeft;
            BtnExamResults.UseVisualStyleBackColor = true;
            BtnExamResults.Click += BtnExamResults_Click;
            // 
            // BtnGradeBook
            // 
            BtnGradeBook.Dock = DockStyle.Top;
            BtnGradeBook.FlatAppearance.BorderSize = 0;
            BtnGradeBook.FlatStyle = FlatStyle.Flat;
            BtnGradeBook.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnGradeBook.Location = new Point(0, 337);
            BtnGradeBook.Name = "BtnGradeBook";
            BtnGradeBook.Size = new Size(307, 50);
            BtnGradeBook.TabIndex = 3;
            BtnGradeBook.Text = "Gradebook";
            BtnGradeBook.TextAlign = ContentAlignment.MiddleLeft;
            BtnGradeBook.UseVisualStyleBackColor = true;
            BtnGradeBook.Click += BtnGradeBook_Click;
            // 
            // PnlClassesSubMenu
            // 
            PnlClassesSubMenu.Controls.Add(BtnManageClass);
            PnlClassesSubMenu.Controls.Add(BtnCreateClass);
            PnlClassesSubMenu.Controls.Add(BtnMyClasses);
            PnlClassesSubMenu.Dock = DockStyle.Top;
            PnlClassesSubMenu.Location = new Point(0, 195);
            PnlClassesSubMenu.Name = "PnlClassesSubMenu";
            PnlClassesSubMenu.Size = new Size(307, 142);
            PnlClassesSubMenu.TabIndex = 3;
            // 
            // BtnManageClass
            // 
            BtnManageClass.Dock = DockStyle.Top;
            BtnManageClass.FlatAppearance.BorderSize = 0;
            BtnManageClass.FlatStyle = FlatStyle.Flat;
            BtnManageClass.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnManageClass.ImageAlign = ContentAlignment.MiddleLeft;
            BtnManageClass.Location = new Point(0, 90);
            BtnManageClass.Name = "BtnManageClass";
            BtnManageClass.Padding = new Padding(35, 0, 0, 0);
            BtnManageClass.Size = new Size(307, 45);
            BtnManageClass.TabIndex = 2;
            BtnManageClass.Text = "Manage Class";
            BtnManageClass.TextAlign = ContentAlignment.MiddleLeft;
            BtnManageClass.UseVisualStyleBackColor = true;
            BtnManageClass.Click += BtnManageClass_Click;
            // 
            // BtnCreateClass
            // 
            BtnCreateClass.Dock = DockStyle.Top;
            BtnCreateClass.FlatAppearance.BorderSize = 0;
            BtnCreateClass.FlatStyle = FlatStyle.Flat;
            BtnCreateClass.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnCreateClass.ImageAlign = ContentAlignment.MiddleLeft;
            BtnCreateClass.Location = new Point(0, 45);
            BtnCreateClass.Name = "BtnCreateClass";
            BtnCreateClass.Padding = new Padding(35, 0, 0, 0);
            BtnCreateClass.Size = new Size(307, 45);
            BtnCreateClass.TabIndex = 1;
            BtnCreateClass.Text = "Create Class";
            BtnCreateClass.TextAlign = ContentAlignment.MiddleLeft;
            BtnCreateClass.UseVisualStyleBackColor = true;
            BtnCreateClass.Click += BtnCreateClass_Click;
            // 
            // BtnMyClasses
            // 
            BtnMyClasses.Dock = DockStyle.Top;
            BtnMyClasses.FlatAppearance.BorderSize = 0;
            BtnMyClasses.FlatStyle = FlatStyle.Flat;
            BtnMyClasses.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnMyClasses.ImageAlign = ContentAlignment.MiddleLeft;
            BtnMyClasses.Location = new Point(0, 0);
            BtnMyClasses.Name = "BtnMyClasses";
            BtnMyClasses.Padding = new Padding(35, 0, 0, 0);
            BtnMyClasses.Size = new Size(307, 45);
            BtnMyClasses.TabIndex = 0;
            BtnMyClasses.Text = "My Classes";
            BtnMyClasses.TextAlign = ContentAlignment.MiddleLeft;
            BtnMyClasses.UseVisualStyleBackColor = true;
            BtnMyClasses.Click += BtnMyClasses_Click;
            // 
            // BtnClasses
            // 
            BtnClasses.Dock = DockStyle.Top;
            BtnClasses.FlatAppearance.BorderSize = 0;
            BtnClasses.FlatStyle = FlatStyle.Flat;
            BtnClasses.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnClasses.Location = new Point(0, 145);
            BtnClasses.Name = "BtnClasses";
            BtnClasses.Size = new Size(307, 50);
            BtnClasses.TabIndex = 2;
            BtnClasses.Text = "Classes";
            BtnClasses.TextAlign = ContentAlignment.MiddleLeft;
            BtnClasses.UseVisualStyleBackColor = true;
            BtnClasses.Click += BtnClasses_Click;
            // 
            // BtnDashboard
            // 
            BtnDashboard.Dock = DockStyle.Top;
            BtnDashboard.FlatAppearance.BorderSize = 0;
            BtnDashboard.FlatStyle = FlatStyle.Flat;
            BtnDashboard.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnDashboard.Location = new Point(0, 95);
            BtnDashboard.Name = "BtnDashboard";
            BtnDashboard.Size = new Size(307, 50);
            BtnDashboard.TabIndex = 1;
            BtnDashboard.Text = "Dashboard";
            BtnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            BtnDashboard.UseVisualStyleBackColor = true;
            BtnDashboard.Click += BtnDashboard_Click;
            // 
            // PnlMenuIcon
            // 
            PnlMenuIcon.Dock = DockStyle.Top;
            PnlMenuIcon.Location = new Point(0, 0);
            PnlMenuIcon.Name = "PnlMenuIcon";
            PnlMenuIcon.Size = new Size(307, 95);
            PnlMenuIcon.TabIndex = 0;
            // 
            // PnlContainer
            // 
            PnlContainer.Dock = DockStyle.Fill;
            PnlContainer.Location = new Point(307, 0);
            PnlContainer.Name = "PnlContainer";
            PnlContainer.Size = new Size(810, 659);
            PnlContainer.TabIndex = 1;
            // 
            // MainApplicationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1117, 659);
            Controls.Add(PnlContainer);
            Controls.Add(PnlSideMenu);
            ForeColor = Color.White;
            MinimumSize = new Size(950, 600);
            Name = "MainApplicationForm";
            Text = "MainApplicationForm";
            Load += MainApplicationForm_Load;
            PnlSideMenu.ResumeLayout(false);
            PnlGradeBookSubMenu.ResumeLayout(false);
            PnlClassesSubMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PnlSideMenu;
        private Button BtnDashboard;
        private Panel PnlMenuIcon;
        private Panel PnlClassesSubMenu;
        private Button BtnClasses;
        private Button BtnMyClasses;
        private Button BtnManageClass;
        private Button BtnCreateClass;
        private Panel PnlGradeBookSubMenu;
        private Button BtnResultsAnalytics;
        private Button BtnExamResults;
        private Button BtnGradeBook;
        private Button BtnMyAccount;
        private Button BtnStudentRankings;
        private Button BtnReport;
        private Panel PnlContainer;
    }
}