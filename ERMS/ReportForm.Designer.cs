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
            SuspendLayout();
            // 
            // TxtTeachersComment
            // 
            TxtTeachersComment.Anchor = AnchorStyles.Bottom;
            TxtTeachersComment.Location = new Point(148, 483);
            TxtTeachersComment.Multiline = true;
            TxtTeachersComment.Name = "TxtTeachersComment";
            TxtTeachersComment.PlaceholderText = "Teachers Comment:";
            TxtTeachersComment.ScrollBars = ScrollBars.Vertical;
            TxtTeachersComment.Size = new Size(484, 212);
            TxtTeachersComment.TabIndex = 0;
            // 
            // BtnShare
            // 
            BtnShare.BackColor = Color.FromArgb(128, 64, 0);
            BtnShare.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnShare.ForeColor = Color.White;
            BtnShare.Location = new Point(625, 12);
            BtnShare.Name = "BtnShare";
            BtnShare.Size = new Size(79, 33);
            BtnShare.TabIndex = 5;
            BtnShare.Text = "Share";
            BtnShare.UseVisualStyleBackColor = false;
            // 
            // TxtSearch
            // 
            TxtSearch.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtSearch.ForeColor = Color.Black;
            TxtSearch.Location = new Point(12, 12);
            TxtSearch.Name = "TxtSearch";
            TxtSearch.PlaceholderText = "Student";
            TxtSearch.Size = new Size(157, 35);
            TxtSearch.TabIndex = 6;
            // 
            // BtnSearch
            // 
            BtnSearch.BackColor = Color.FromArgb(128, 64, 0);
            BtnSearch.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnSearch.ForeColor = Color.White;
            BtnSearch.Location = new Point(175, 15);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(79, 33);
            BtnSearch.TabIndex = 7;
            BtnSearch.Text = "Search";
            BtnSearch.UseVisualStyleBackColor = false;
            // 
            // LblName
            // 
            LblName.AutoSize = true;
            LblName.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblName.ForeColor = Color.Black;
            LblName.Location = new Point(115, 86);
            LblName.Name = "LblName";
            LblName.Size = new Size(54, 20);
            LblName.TabIndex = 8;
            LblName.Text = "Name:";
            // 
            // LblClassName
            // 
            LblClassName.AutoSize = true;
            LblClassName.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblClassName.ForeColor = Color.Black;
            LblClassName.Location = new Point(328, 86);
            LblClassName.Name = "LblClassName";
            LblClassName.Size = new Size(91, 20);
            LblClassName.TabIndex = 9;
            LblClassName.Text = "Class Name:";
            // 
            // LblDate
            // 
            LblDate.AutoSize = true;
            LblDate.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblDate.ForeColor = Color.Black;
            LblDate.Location = new Point(550, 86);
            LblDate.Name = "LblDate";
            LblDate.Size = new Size(45, 20);
            LblDate.TabIndex = 10;
            LblDate.Text = "Date:";
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 766);
            Controls.Add(LblDate);
            Controls.Add(LblClassName);
            Controls.Add(LblName);
            Controls.Add(BtnSearch);
            Controls.Add(TxtSearch);
            Controls.Add(BtnShare);
            Controls.Add(TxtTeachersComment);
            Name = "ReportForm";
            Text = "ReportForm";
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
    }
}