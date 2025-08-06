namespace ERMS
{
    partial class MyClassesForm
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
            comboBox1 = new ComboBox();
            TxtSearch = new TextBox();
            BtnSearch = new Button();
            SuspendLayout();
            // 
            // CmbSelectClass
            // 
            CmbSelectClass.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CmbSelectClass.FormattingEnabled = true;
            CmbSelectClass.Location = new Point(12, 28);
            CmbSelectClass.Name = "CmbSelectClass";
            CmbSelectClass.Size = new Size(147, 38);
            CmbSelectClass.TabIndex = 0;
            CmbSelectClass.Text = "Select Class";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(174, 28);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(163, 38);
            comboBox1.TabIndex = 1;
            comboBox1.Text = "Select Subject";
            // 
            // TxtSearch
            // 
            TxtSearch.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtSearch.ForeColor = Color.Black;
            TxtSearch.Location = new Point(408, 31);
            TxtSearch.Name = "TxtSearch";
            TxtSearch.PlaceholderText = "Student";
            TxtSearch.Size = new Size(157, 35);
            TxtSearch.TabIndex = 2;
            // 
            // BtnSearch
            // 
            BtnSearch.BackColor = Color.FromArgb(128, 64, 0);
            BtnSearch.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnSearch.ForeColor = Color.White;
            BtnSearch.Location = new Point(571, 33);
            BtnSearch.Name = "BtnSearch";
            BtnSearch.Size = new Size(79, 33);
            BtnSearch.TabIndex = 3;
            BtnSearch.Text = "Search";
            BtnSearch.UseVisualStyleBackColor = false;
            // 
            // MyClassesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 766);
            Controls.Add(BtnSearch);
            Controls.Add(TxtSearch);
            Controls.Add(comboBox1);
            Controls.Add(CmbSelectClass);
            Name = "MyClassesForm";
            Text = "MyClasses";
            Load += MyClassesForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox CmbSelectClass;
        private ComboBox comboBox1;
        private TextBox TxtSearch;
        private Button BtnSearch;
    }
}