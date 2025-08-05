namespace ERMS
{
    partial class ResultsAnalyticsForm
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
            CmbSelectClass = new ComboBox();
            CmbSelectAssessment = new ComboBox();
            CmbSelectSubject = new ComboBox();
            BtnSearch = new Button();
            TxtSearch = new TextBox();
            SuspendLayout();
            // 
            // CmbSelectClass
            // 
            CmbSelectClass.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CmbSelectClass.FormattingEnabled = true;
            CmbSelectClass.Location = new Point(12, 12);
            CmbSelectClass.Name = "CmbSelectClass";
            CmbSelectClass.Size = new Size(135, 38);
            CmbSelectClass.TabIndex = 0;
            CmbSelectClass.Text = "Select Class";
            // 
            // CmbSelectAssessment
            // 
            CmbSelectAssessment.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CmbSelectAssessment.FormattingEnabled = true;
            CmbSelectAssessment.Location = new Point(321, 12);
            CmbSelectAssessment.Name = "CmbSelectAssessment";
            CmbSelectAssessment.Size = new Size(201, 38);
            CmbSelectAssessment.TabIndex = 1;
            CmbSelectAssessment.Text = "Select Assessment";
            // 
            // CmbSelectSubject
            // 
            CmbSelectSubject.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CmbSelectSubject.FormattingEnabled = true;
            CmbSelectSubject.Location = new Point(153, 12);
            CmbSelectSubject.Name = "CmbSelectSubject";
            CmbSelectSubject.Size = new Size(162, 38);
            CmbSelectSubject.TabIndex = 2;
            CmbSelectSubject.Text = "Select Subject";
            // 
            // BtnSearch
            // 
            BtnSearch.BackColor = Color.FromArgb(128, 64, 0);
            BtnSearch.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnSearch.ForeColor = Color.White;
            BtnSearch.Location = new Point(712, 15);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(79, 33);
            BtnSearch.TabIndex = 4;
            BtnSearch.Text = "Search";
            BtnSearch.UseVisualStyleBackColor = false;
            // 
            // TxtSearch
            // 
            TxtSearch.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtSearch.ForeColor = Color.Black;
            TxtSearch.Location = new Point(549, 15);
            TxtSearch.Name = "TxtSearch";
            TxtSearch.PlaceholderText = "Student";
            TxtSearch.Size = new Size(157, 35);
            TxtSearch.TabIndex = 5;
            // 
            // ResultsAnalyticsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 766);
            Controls.Add(TxtSearch);
            Controls.Add(BtnSearch);
            Controls.Add(CmbSelectSubject);
            Controls.Add(CmbSelectAssessment);
            Controls.Add(CmbSelectClass);
            Name = "ResultsAnalyticsForm";
            Text = "ResultsAnalyticsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CmbSelectClass;
        private ComboBox CmbSelectAssessment;
        private ComboBox CmbSelectSubject;
        private Button BtnSearch;
        private TextBox TxtSearch;
    }
}