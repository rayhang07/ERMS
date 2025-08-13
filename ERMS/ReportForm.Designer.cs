namespace ERMS
{
    partial class ReportForm
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
            TxtTeachersComment = new TextBox();
            BtnShare = new Button();
            TxtSearch = new TextBox();
            BtnSearch = new Button();
            LblName = new Label();
            LblClassName = new Label();
            LblDate = new Label();
            CmbSelectClass = new ComboBox();
            DgvReports = new DataGridView();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)DgvReports).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // TxtTeachersComment
            // 
            TxtTeachersComment.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            TxtTeachersComment.BackColor = SystemColors.ScrollBar;
            TxtTeachersComment.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtTeachersComment.Location = new Point(18, 402);
            TxtTeachersComment.Multiline = true;
            TxtTeachersComment.Name = "TxtTeachersComment";
            TxtTeachersComment.PlaceholderText = "Teachers Comment:";
            TxtTeachersComment.ScrollBars = ScrollBars.Vertical;
            TxtTeachersComment.Size = new Size(668, 273);
            TxtTeachersComment.TabIndex = 0;
            // 
            // BtnShare
            // 
            BtnShare.Anchor = AnchorStyles.Top;
            BtnShare.BackColor = Color.FromArgb(128, 64, 0);
            BtnShare.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnShare.ForeColor = Color.White;
            BtnShare.Location = new Point(607, 12);
            BtnShare.Name = "BtnShare";
            BtnShare.Size = new Size(79, 33);
            BtnShare.TabIndex = 5;
            BtnShare.Text = "Share";
            BtnShare.UseVisualStyleBackColor = false;
            BtnShare.Click += BtnShare_Click;
            // 
            // TxtSearch
            // 
            TxtSearch.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtSearch.ForeColor = Color.Black;
            TxtSearch.Location = new Point(185, 14);
            TxtSearch.Name = "TxtSearch";
            TxtSearch.PlaceholderText = "Student";
            TxtSearch.Size = new Size(157, 35);
            TxtSearch.TabIndex = 6;
            TxtSearch.TextChanged += TxtSearch_TextChanged;
            // 
            // BtnSearch
            // 
            BtnSearch.BackColor = Color.FromArgb(128, 64, 0);
            BtnSearch.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnSearch.ForeColor = Color.White;
            BtnSearch.Location = new Point(362, 17);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(81, 33);
            BtnSearch.TabIndex = 7;
            BtnSearch.Text = "Search";
            BtnSearch.UseVisualStyleBackColor = false;
            BtnSearch.Click += BtnSearch_Click;
            // 
            // LblName
            // 
            LblName.Anchor = AnchorStyles.Top;
            LblName.AutoSize = true;
            LblName.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblName.ForeColor = Color.Black;
            LblName.Location = new Point(30, 64);
            LblName.Name = "LblName";
            LblName.Size = new Size(54, 20);
            LblName.TabIndex = 8;
            LblName.Text = "Name:";
            // 
            // LblClassName
            // 
            LblClassName.Anchor = AnchorStyles.Top;
            LblClassName.AutoSize = true;
            LblClassName.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblClassName.ForeColor = Color.Black;
            LblClassName.Location = new Point(319, 64);
            LblClassName.Name = "LblClassName";
            LblClassName.Size = new Size(46, 20);
            LblClassName.TabIndex = 9;
            LblClassName.Text = "Class:";
            // 
            // LblDate
            // 
            LblDate.Anchor = AnchorStyles.Top;
            LblDate.AutoSize = true;
            LblDate.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblDate.ForeColor = Color.Black;
            LblDate.Location = new Point(559, 64);
            LblDate.Name = "LblDate";
            LblDate.Size = new Size(45, 20);
            LblDate.TabIndex = 10;
            LblDate.Text = "Date:";
            // 
            // CmbSelectClass
            // 
            CmbSelectClass.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CmbSelectClass.FormattingEnabled = true;
            CmbSelectClass.Location = new Point(5, 12);
            CmbSelectClass.Name = "CmbSelectClass";
            CmbSelectClass.Size = new Size(147, 38);
            CmbSelectClass.TabIndex = 11;
            CmbSelectClass.Text = "Select Class";
            // 
            // DgvReports
            // 
            DgvReports.Anchor = AnchorStyles.Top;
            DgvReports.BackgroundColor = Color.White;
            DgvReports.ColumnHeadersHeight = 40;
            DgvReports.Location = new Point(67, 115);
            DgvReports.Name = "DgvReports";
            DgvReports.RowHeadersWidth = 95;
            DgvReports.Size = new Size(563, 244);
            DgvReports.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panel1.BackColor = SystemColors.Window;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(LblName);
            panel1.Controls.Add(DgvReports);
            panel1.Controls.Add(LblClassName);
            panel1.Controls.Add(LblDate);
            panel1.Controls.Add(BtnShare);
            panel1.Controls.Add(TxtTeachersComment);
            panel1.Location = new Point(48, 72);
            panel1.Name = "panel1";
            panel1.Size = new Size(703, 693);
            panel1.TabIndex = 13;
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 788);
            Controls.Add(panel1);
            Controls.Add(CmbSelectClass);
            Controls.Add(BtnSearch);
            Controls.Add(TxtSearch);
            Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "ReportForm";
            Text = " ";
            ((System.ComponentModel.ISupportInitialize)DgvReports).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TxtTeachersComment;
        private Button BtnShare;
        private TextBox TxtSearch;
        private Button BtnSearch;
        private Label LblName;
        private Label LblClassName;
        private Label LblDate;
        private ComboBox CmbSelectClass;
        private DataGridView DgvReports;
        private Panel panel1;
    }
}